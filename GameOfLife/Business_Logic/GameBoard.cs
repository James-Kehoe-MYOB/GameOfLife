using System;
using System.Collections.Generic;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;

namespace GameOfLife.Business_Logic {
    public class GameBoard : IGameBoard {
        private BoardProperties BoardProperties { get; set; }
        private IUserInterface UI { get; set; }
        public readonly List<Cell> CellData = new List<Cell>();

        public GameBoard(BoardProperties boardProperties, IUserInterface UI) {
            BoardProperties = boardProperties;
            this.UI = UI;
            InitBoard();
        }

        public void InitBoard() {
            var x = 1;
            var y = 1;
            foreach (var c in BoardProperties.Seed) {
                var isAlive = c switch {
                    '0' => false,
                    '1' => true,
                    _ => throw new Exception()
                };
                CellData.Add(new Cell(x, y, isAlive));
                if (x < BoardProperties.Width) {
                    x++;
                } else if (x == BoardProperties.Width) {
                    x = 1;
                    y++;
                }
            }
        }

        public void Step() {
            UpdateBoard();
            UI.WriteBoard(CellData, BoardProperties.Height, BoardProperties.Width);
        }

        public void UpdateBoard() {
            foreach (var cell in CellData) {
                var neighbours = GetNumberOfAliveNeighbours(cell);
                cell.AliveNeighbours = neighbours;
            }
            RefreshDisplay();
        }

        private void RefreshDisplay() {
            foreach (var cell in CellData) {
                cell.Update();
            }
        }

        private int GetNumberOfAliveNeighbours(Cell cell) {
            var aliveNeighbours = 0;
            var x = cell.X - 1;
            var y = cell.Y - 1;
                
            for (int j = 0; j < 3; j++) {
                for (int i = 0; i < 3; i++) {
                    if (x < 1) {
                        x = BoardProperties.Width;
                    }
                    if (x > BoardProperties.Width) {
                        x = 1;
                    }
                    if (y < 1) {
                        y = BoardProperties.Height;
                    }
                    if (y > BoardProperties.Height) {
                        y = 1;
                    }

                    if (x == cell.X && y == cell.Y) {
                        x++;
                        continue;
                    }
                    if (CellData.Find(c => c.X == x && c.Y == y).IsAlive) {
                        aliveNeighbours++;
                    }
                    x++;
                }
                x = cell.X - 1;
                y++;
            }

            return aliveNeighbours;
        }
    }
}