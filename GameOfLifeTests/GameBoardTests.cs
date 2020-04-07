using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests {
    public class GameBoardTests {
        [Fact(DisplayName = "Can Convert Input Into Board Data")]
        public void CanConvertInputIntoBoardData() {
            var binary = "000" +
                         "101" +
                         "111";
            
            var cellData = new List<Cell> {
                new Cell(1,1,false),
                new Cell(2,1,false),
                new Cell(3,1,false),
                new Cell(1,2,true),
                new Cell(2,2,false),
                new Cell(3,2,true),
                new Cell(1,3,true),
                new Cell(2,3,true),
                new Cell(3,3,true)
            };
            
            var gb = new GameBoard(3, 3);

            gb.Start(binary);

            for (var i = 0; i < cellData.Count; i++) {
                Assert.True(cellData[i].Equals(gb.cellData[i]));
            }
        }

        [Fact(DisplayName = "Can Return Correct Amount of Alive Neighbours for a Given Cell")]
        public void CanReturnCorrectAmountOfAliveNeighboursForAGivenCell() {
            
            var gb = new GameBoard(3, 3);
            var binary = "000" +
                         "101" +
                         "111";
            
            gb.Start(binary);
            Assert.Equal(5, gb.cellData[4].aliveNeighbours);
            
        }
    }
}