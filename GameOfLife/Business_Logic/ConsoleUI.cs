using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;
using GameOfLife.Data;

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
        
        private int ReadHeight() {
            Console.Write("What is the height of the grid? ");
            var height = int.Parse(Console.ReadLine());
            return height;
        }

        private int ReadWidth() {
            Console.Write("What is the width of the grid? ");
            var width = int.Parse(Console.ReadLine());
            return width;
        }

        public void WriteChoices() {
            Console.Write("Choose a seed: \n" +
                          "1. Glider\n" +
                          "2. Small Exploder\n" +
                          "3. Custom\n" +
                          "Your Selection: ");
        }
        
        private static string ConvertSeedToData(int height, int width, string seed) {
            var minSeedLength = Math.Ceiling(height * width / 8.0);
            
            while (seed.Length <= minSeedLength) {
                var seedOriginal = seed;
                seed += seedOriginal;
            }

            var boardBinary = StringToBinary(seed).Remove(height * width);
            return boardBinary;
        }
        
        private static string StringToBinary(string data)
        {
            var sb = new StringBuilder();
 
            foreach (var c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public BoardProperties ReadSelection() {
            var selection = Console.ReadLine();
            switch (selection) {
                case "1":
                    return new BoardProperties(SeedData.GliderHeight, SeedData.GliderWidth, SeedData.Glider);
                case "2":
                    return new BoardProperties(SeedData.SmallExploderHeight, SeedData.SmallExploderWidth, SeedData.SmallExploder);
                case "3": {
                    var height = ReadHeight();
                    var width = ReadWidth();
                    Console.Write("Input Custom Seed: ");
                    var input = Console.ReadLine();
                    var customseed = ConvertSeedToData(height, width, input);
                    return new BoardProperties(height, width, customseed);
                }
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }

            return null; //Maybe throw exception
        }
    }
}