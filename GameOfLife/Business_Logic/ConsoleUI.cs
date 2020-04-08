using System;
using System.Collections.Generic;
using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLife.Business_Logic {
    public class ConsoleUI : IUserInterface {
        public void Write(string text) {
            Console.Write(text);
        }

        public void WriteLine(string text) {
            Console.WriteLine(text);
        }

        public string Read() {
            return Console.ReadLine();
        }

        public int ReadAsInt() {
            return int.Parse(Console.ReadLine());
        }

        public void WriteBoard(List<Cell> board, int height, int width) {
            var split = 0;
            foreach (var cell in board) {
                Console.Write(cell.Display);
                split++;
                if (split == width) {
                    Console.Write("\n");
                    split = 0;
                }
            }
        }

        public int ReadHeight() {
            Console.Write("What is the height of the grid? ");
            var height = int.Parse(Console.ReadLine());
            return height;
        }

        public int ReadWidth() {
            Console.Write("What is the width of the grid? ");
            var width = int.Parse(Console.ReadLine());
            return width;
        }

        public string ReadSeed() {
            Console.Write("Choose a seed: \n" +
                          "1. Glider\n" +
                          "2. Small Exploder\n" +
                          "3. Custom\n" +
                          "Your Selection: ");
            return Console.ReadLine();
        }
    }
}