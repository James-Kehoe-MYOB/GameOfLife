using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;
using GameOfLife.Data;
using GameOfLife.Data_Access;
using GameOfLife.Data_Access.Interfaces;

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

        public void WriteBoard(IEnumerable<Cell> board, int height, int width) {
            var split = 0;
            var count = 0;
            Console.Write("\u2554");
            for (var i = 0; i < 2*width+1; i++) {
                Console.Write("\u2550");
            }

            Console.Write("\u2557" + "\n\u2551 ");
            foreach (var cell in board) {
                Console.Write(cell.Display + " ");
                split++;
                if (split == width && count != height-1) {
                    Console.Write("\u2551\n\u2551 ");
                    split = 0;
                    count++;
                } else if (split == width && count == height-1) {
                    Console.Write("\u2551\n" + "\u2560");
                }
            }
            for (var i = 0; i < 2*width+1; i++) {
                Console.Write(i == 21 ? "\u2566" : "\u2550");
            }
            Console.WriteLine(width == 10 ? "\u2563" : "\u255D");
            Console.WriteLine("\u2551 Press Enter to Quit \u2551");
            Console.Write("╚═════════════════════╝");
            Console.CursorVisible = false;
        }

        public void WriteChoices() {
            Console.Write("Choose a seed: \n" +
                          "1. Glider\n" +
                          "2. Small Exploder\n" +
                          "3. Custom\n" +
                          "Your Selection: ");
        }

        public ISeedHandler ReadSelection(string selection) {
            return selection switch {
                "1" => new DefaultSeedHandler(SeedName.Glider),
                "2" => new DefaultSeedHandler(SeedName.SmallExploder),
                "3" => new CustomSeedHandler(this, new Validator()),
                _ => throw new Exception()
            };
        }
    }
}