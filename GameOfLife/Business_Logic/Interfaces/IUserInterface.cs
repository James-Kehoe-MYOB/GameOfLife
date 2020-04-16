using System;
using System.Collections.Generic;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Business_Logic.Interfaces {
    public interface IUserInterface {

        public ConsoleKey ExitKey { get; }

        public ConsoleKey ResetKey { get; }

        public void Write(string text);

        public void WriteLine(string text);

        public string Read();

        public void WriteBoard(IEnumerable<Cell> board, int height, int width);

        public void WriteChoices();

        public void Clear();

        public ConsoleKeyInfo ReadKey();

        public bool NoKeyPressed();

    }
}