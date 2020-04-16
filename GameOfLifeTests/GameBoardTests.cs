using System;
using System.Collections.Generic;
using GameOfLife.Business_Logic;
using GameOfLife.Business_Logic.Exceptions;
using GameOfLife.Business_Logic.Models;
using GameOfLife.Data;
using Xunit;

namespace GameOfLifeTests {
    public class GameBoardTests {
        [Fact(DisplayName = "Can Convert Input Into Board Data")]
        public void CanConvertInputIntoBoardData() {
            var rawData = "000" +
                         "101" +
                         "111";
            
            var cellData = new List<Cell> {
                new Cell(1,1,false, new BaseCellLogic()),
                new Cell(2,1,false,new BaseCellLogic()),
                new Cell(3,1,false,new BaseCellLogic()),
                new Cell(1,2,true, new BaseCellLogic()),
                new Cell(2,2,false,new BaseCellLogic()),
                new Cell(3,2,true, new BaseCellLogic()),
                new Cell(1,3,true, new BaseCellLogic()),
                new Cell(2,3,true, new BaseCellLogic()),
                new Cell(3,3,true, new BaseCellLogic())
            };
            
            var gb = new GameBoard(new BoardProperties(SeedName.Custom, 3, 3, rawData), new ConsoleUI());

            for (var i = 0; i < cellData.Count; i++) {
                Assert.True(cellData[i].Equals(gb.CellData[i]));
            }
        }

        [Fact(DisplayName = "Can Return Correct Amount of Alive Neighbours for a Given Cell")]
        public void CanReturnCorrectAmountOfAliveNeighboursForAGivenCell() {

            var rawData = "000" +
                         "101" +
                         "111";
            var gb = new GameBoard(new BoardProperties(SeedName.Custom, 3, 3, rawData), new ConsoleUI());
            gb.Step();
            Assert.Equal(5, gb.CellData[4].AliveNeighbours);
        }
        
        [Fact(DisplayName = "Can Return Correct Amount of Alive Neighbours for an Edge Cell")]
        public void CanReturnCorrectAmountOfAliveNeighboursForAnEdgeCell() {

            var rawData = "000" +
                          "101" +
                          "111";
            var gb = new GameBoard(new BoardProperties(SeedName.Custom, 3, 3, rawData), new ConsoleUI());
            gb.Step();
            Assert.Equal(4, gb.CellData[3].AliveNeighbours);
        }

        [Fact(DisplayName = "Returns Correct Result After 1 Step")]
        public void ReturnsCorrectResultAfter1Step() {

            var rawData = "00000" +
                         "00100" +
                         "00010" +
                         "01110" +
                         "00000";

            var dataAfterOneStep = "00000" +
                                     "00000" +
                                     "01010" +
                                     "00110" +
                                     "00100";
            
            var gb1 = new GameBoard(new BoardProperties(SeedName.Custom, 5,5,rawData), new ConsoleUI());
            var gb2 = new GameBoard(new BoardProperties(SeedName.Custom, 5,5,dataAfterOneStep), new ConsoleUI());

            gb1.Step();
            
            for (var i = 0; i < gb1.CellData.Count; i++) {
                Assert.Equal(gb2.CellData[i].Display, gb1.CellData[i].Display);
            }
        }

        [Fact(DisplayName = "Attempting to Fill a GameBoard With Insufficient Data Throws an Exception")]

        public void AttemptingToFillAGameBoardWithInsufficientDataThrowsAnException() {
            const string insufficientData = "010";

            Assert.Throws<InsufficientBoardDataException>(() => new GameBoard(new BoardProperties(SeedName.Custom, 5, 5, insufficientData),
                new ConsoleUI()));
        }
        
        [Theory(DisplayName = "Attempting to Fill a GameBoard With an Invalid Data Format Throws an Exception")]
        [InlineData("_INVALID_")]
        [InlineData("123456789")]
        public void AttemptingToFillAGameBoardWithAnInvalidDataFormatThrowsAnException(string data) {

            Assert.Throws<InvalidBoardDataFormatException>(() => new GameBoard(new BoardProperties(SeedName.Custom, 3, 3, data),
                new ConsoleUI()));
        }
        
    }
}