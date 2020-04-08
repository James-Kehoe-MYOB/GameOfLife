using System.Collections.Generic;

namespace GameOfLife.Business_Logic.Interfaces {
    public interface IUserInterface {

        public void Write(string text);

        public void WriteLine(string text);

        public string Read();

        public int ReadAsInt();

        public void WriteBoard(List<Cell> board, int height, int width);

        public int ReadHeight();

        public int ReadWidth();

        public string ReadSeed();

    }
}