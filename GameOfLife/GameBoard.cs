using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace GameOfLife {
    public class GameBoard {

        public int height;
        public int width;
        public List<Cell> cellData = new List<Cell>();

        public GameBoard(int height, int width) {
            this.height = height;
            this.width = width;
        }

        public void Start(string seed) {
            FillBoard(seed);
            UpdateCellData();
        }

        private void FillBoard(string seed) {
            var x = 1;
            var y = 1;
            bool isAlive;
            foreach (var c in seed) {
                isAlive = c switch {
                    Cell.Dead => false,
                    Cell.Alive => true
                };
                cellData.Add(new Cell(x, y, isAlive));
                if (x < width) {
                    x++;
                } else if (x == width) {
                    x = 1;
                    y++;
                }
            }
        }

        private void UpdateCellData() {
            foreach (var cell in cellData) {
                var neighbours = GetNumberOfAliveNeighbours(cell);
                cell.aliveNeighbours = neighbours;
            }
        }

        private int GetNumberOfAliveNeighbours(Cell cell) {
            var aliveNeighbours = 0;
            var x = cell.x - 1;
            var y = cell.y - 1;
                
            for (int j = 0; j < 3; j++) {
                for (int i = 0; i < 3; i++) {
                    if (x < 1) {
                        x = width;
                    }
                    if (x > width) {
                        x = 1;
                    }
                    if (y < 1) {
                        y = height;
                    }
                    if (y > height) {
                        y = 1;
                    }
                    
                    if (cellData.Find(c => c.x == x && c.y == y).isAlive) {
                        aliveNeighbours++;
                    }
                    x++;
                }
                x = cell.x - 1;
                y++;
            }

            return aliveNeighbours;
        }
    }
}