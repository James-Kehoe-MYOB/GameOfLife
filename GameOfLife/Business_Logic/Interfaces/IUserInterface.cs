using System.Collections.Generic;
using GameOfLife.Business_Logic.Models;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Business_Logic.Interfaces {
    public interface IUserInterface {

        public void Write(string text);

        public void WriteLine(string text);

        public string Read();

        public void WriteBoard(IEnumerable<Cell> board, int height, int width);

        public void WriteChoices();

        public ISeedHandler ReadSelection(string selection);

    }
}