using System;
using System.Text;
using GameOfLife.Business_Logic;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Data;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Data_Access {
    public class CustomSeedHandler : ISeedHandler {
        private readonly IUserInterface _userInterface;
        private readonly IValidator _validator;
        private int _height;
        private int _width;

        public CustomSeedHandler(IUserInterface userInterface, IValidator validator) {
            _validator = validator;
            _userInterface = userInterface;
        }
        public SeedName GetName() {
            return SeedName.Custom;
        }

        public int GetHeight() {
            _userInterface.Write("What is the height of the grid? ");
            var height = _userInterface.Read();
            if (_validator.ValidHeight(height)) {
                _height = int.Parse(height);
                return _height;
            }
            else {
                _userInterface.WriteLine("Invalid Height!");
                throw new InvalidHeightException(height);
            }
        }

        public int GetWidth() {
            _userInterface.Write("What is the width of the grid? ");
            var width = _userInterface.Read();
            if (_validator.ValidWidth(width)) {
                _width = int.Parse(width);
                return _width;
            }
            else {
                _userInterface.WriteLine("Invalid Width!");
                throw new InvalidHeightException(width);
            }
            
        }

        public string GetSeed() {
            Console.Write("Input Custom Seed: ");
            var input = Console.ReadLine();
            var customseed = ConvertSeedToData(_height, _width, input);
            return customseed;
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
    }
}