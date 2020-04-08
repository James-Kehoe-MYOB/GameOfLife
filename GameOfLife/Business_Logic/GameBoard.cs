using System;
using System.Collections.Generic;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;

namespace GameOfLife.Business_Logic {
    public class GameBoard : IGameBoard {

        private readonly BoardProperties _boardProperties;
        public readonly List<Cell> CellData = new List<Cell>();

        public GameBoard(BoardProperties boardProperties) {
            _boardProperties = boardProperties;
        }

        public void InitBoard() {
            var x = 1;
            var y = 1;
            foreach (var c in _boardProperties.Seed) {
                var isAlive = c switch {
                    '0' => false,
                    '1' => true,
                    _ => throw new Exception()
                };
                CellData.Add(new Cell(x, y, isAlive));
                if (x < _boardProperties.Width) {
                    x++;
                } else if (x == _boardProperties.Width) {
                    x = 1;
                    y++;
                }
            }
        }

        public void Step() {
            UpdateCellData();
            UpdateCellDisplay();
            _boardProperties.UserInterface.WriteBoard(CellData, _boardProperties.Height, _boardProperties.Width);
        }

        public void UpdateCellData() {
            foreach (var cell in CellData) {
                var neighbours = GetNumberOfAliveNeighbours(cell);
                cell.AliveNeighbours = neighbours;
            }
        }

        private void UpdateCellDisplay() {
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
                        x = _boardProperties.Width;
                    }
                    if (x > _boardProperties.Width) {
                        x = 1;
                    }
                    if (y < 1) {
                        y = _boardProperties.Height;
                    }
                    if (y > _boardProperties.Height) {
                        y = 1;
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
        
        
        // private void UpdateDisplay() {
        //     foreach (var cell in cellData) {
        //         cell.Update();
        //     }
        // }
    }
}