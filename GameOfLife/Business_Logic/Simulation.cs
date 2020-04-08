using System;
using System.Text;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;

namespace GameOfLife.Business_Logic {
    public class Simulation : ISimulation {

        private readonly IUserInterface _userInterface;
        
        public Simulation(IUserInterface userInterface) {
            _userInterface = userInterface;
        }

        public GameBoard GenerateGameBoard() {
            var properties = GetProperties();
            return new GameBoard(properties);
        }

        public void Start() {
            var gameBoard = GenerateGameBoard();
            gameBoard.InitBoard();
            gameBoard.Step();
            
            for (var i = 0; i < 100; i++) {
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                gameBoard.Step();
            }
        }
        private BoardProperties GetProperties() {
            
            var height = _userInterface.ReadHeight();
            
            var width = _userInterface.ReadWidth();
            
            var seed = _userInterface.ReadSeed();

            var boardData = ConvertSeedToData(height, width, seed);
            return new BoardProperties(height, width, boardData, _userInterface);
        }

        private string ConvertSeedToData(int height, int width, string seed) {
            var min_seed_length = height * width / 8;
            
            while (seed.Length <= min_seed_length) {
                var seedOriginal = seed;
                seed += seedOriginal;
            }
            var board_binary = StringToBinary(seed).Substring(StringToBinary(seed).Length-(height*width));
            return board_binary;
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