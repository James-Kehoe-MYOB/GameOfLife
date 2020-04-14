using System.Collections.Generic;
using GameOfLife.Business_Logic;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLifeTests {
    public class InvalidSeedSelectionInput : IUserInterface {
        public void Write(string text) {
            throw new System.NotImplementedException();
        }

        public void WriteLine(string text) {
            throw new System.NotImplementedException();
        }

        public string Read() {
            throw new System.NotImplementedException();
        }

        public void WriteBoard(IEnumerable<Cell> board, int height, int width) {
            throw new System.NotImplementedException();
        }

        public void WriteChoices() {
            return;
        }

        public ISeedHandler ReadSelection(string selection) {
            throw new System.NotImplementedException();
        }
    }
}