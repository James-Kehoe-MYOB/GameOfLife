using System;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests {
    public class CellTests {
        [Theory (DisplayName = "Cell Displays Correct Symbol When Alive or Dead")]
        [InlineData(true, Cell.Alive)]
        [InlineData(false, Cell.Dead)]
        public void CellDisplaysCorrectSymbolWhenAliveOrDead(bool isAlive, char display) {
            var cell = new Cell(1,1, isAlive);
            
            Assert.Equal(display, cell.display);
        }

        [Theory(DisplayName = "Alive Cell Updates Correctly With Given Amount of Alive Neighbours")]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void AliveCellUpdatesCorrectlyWithGivenAmountOfAliveNeighbours(int aliveNeighbours, bool isAlive) {
            var cell = new Cell(1,1, true);
            cell.Update(aliveNeighbours);
            
            Assert.Equal(isAlive, cell.isAlive);
        }
        
        [Theory(DisplayName = "Dead Cell Updates Correctly With Given Amount of Alive Neighbours")]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void DeadCellUpdatesCorrectlyWithGivenAmountOfAliveNeighbours(int aliveNeighbours, bool isAlive) {
            var cell = new Cell(1,1, false);
            cell.Update(aliveNeighbours);
            
            Assert.Equal(isAlive, cell.isAlive);
        }
    }
}