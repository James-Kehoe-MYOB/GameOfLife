using System;
using System.Diagnostics;
using System.Net.Mime;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Business_Logic {
    public class Simulation : ISimulation {
        private const int StepTime = 200;
        private readonly IUserInterface _userInterface;
        private readonly IValidator _validator;
        private GameBoard gameBoard;
        
        public Simulation(IUserInterface userInterface, IValidator validator) {
            _userInterface = userInterface;
            _validator = validator;
        }

        public GameBoard GenerateGameBoard(ISeedHandler handler) {
            try {
                var name = handler.GetName();
                var height = handler.GetHeight();
                var width = handler.GetWidth();
                var seed = handler.GetSeed();
                var properties = new BoardProperties(name, height, width, seed);
                return new GameBoard(properties, _userInterface);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            return null;
        }

        public void Start() {
            _userInterface.WriteChoices();
            var selection = _userInterface.Read();
            if (_validator.ValidSelection(selection)) {
                gameBoard = GenerateGameBoard(_userInterface.ReadSelection(selection));
            }
            else {
                Console.WriteLine("Invalid Selection");
                return;
            }

            do {
                while (! Console.KeyAvailable) {
                    GameLoop();
                }
            } while (Console.ReadKey(false).Key != ConsoleKey.Enter);
        }

        private void GameLoop() {
            System.Threading.Thread.Sleep(StepTime);
            Console.Clear();
            gameBoard.Step();
        }
    }
    
    
}