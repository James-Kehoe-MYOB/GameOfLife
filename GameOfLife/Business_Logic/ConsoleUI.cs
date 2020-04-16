using System;
using System.Collections.Generic;
using GameOfLife.Business_Logic.Exceptions;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Data;
using GameOfLife.Data_Access;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Business_Logic {
    public class ConsoleUI : IUserInterface {
        public ConsoleKey ExitKey { get; } = ConsoleKey.Enter;
        public ConsoleKey ResetKey { get; } = ConsoleKey.R;

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
            Console.Write("╔");
            for (var i = 0; i < 2*width+1; i++) {
                Console.Write("═");
            }

            Console.Write("╗" + "\n║ ");
            foreach (var cell in board) {
                Console.Write(cell.Display + " ");
                split++;
                if (split == width && count != height-1) {
                    Console.Write("║\n║ ");
                    split = 0;
                    count++;
                } else if (split == width && count == height-1) {
                    Console.Write("║\n" + "╠");
                }
            }
            for (var i = 0; i < 2*width+1; i++) {
                Console.Write(i == 21 ? "╦" : "═");
            }
            Console.WriteLine(width == 10 ? "╣" : "╝");
            Console.WriteLine("║ Press Enter to Quit ║");
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

        public ISeedHandler ParseSelection(string selection) {
            return selection switch {
                "1" => new DefaultSeedHandler(SeedName.Glider),
                "2" => new DefaultSeedHandler(SeedName.SmallExploder),
                "3" => new CustomSeedHandler(this, new Validator()),
                _ => throw new SelectionOutOfRangeException()
            };
        }

        public void Clear() {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey() {
            return Console.ReadKey();
        }

        public bool NoKeyPressed() {
            return Console.KeyAvailable;
        }
    }
}