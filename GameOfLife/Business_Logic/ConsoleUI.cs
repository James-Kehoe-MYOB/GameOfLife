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
            for (var i = 0; i < 2*width; i++) {
                Console.Write("-");
            }

            Console.WriteLine("");
            foreach (var cell in board) {
                Console.Write(cell.Display + " ");
                split++;
                if (split == width) {
                    Console.Write("\n");
                    split = 0;
                }
            }
            for (var i = 0; i < 2*width; i++) {
                Console.Write("-");
            }
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