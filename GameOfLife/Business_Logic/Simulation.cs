using System;
using System.Threading;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Business_Logic.Models;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Business_Logic {
    public class Simulation {
        private const int StepTime = 200;
        private readonly IUserInterface _userInterface;
        private readonly IValidator _validator;
        private GameBoard gameBoard;
        
        public Simulation(IUserInterface userInterface, IValidator validator) {
            _userInterface = userInterface;
            _validator = validator;
        }

        public void Start() {
            while (true) {
                var selection = "";
                _userInterface.WriteChoices();
                selection = _userInterface.Read();
                while (!_validator.ValidSelection(selection)) {
                    _userInterface.WriteLine("Invalid Selection!");
                    _userInterface.WriteChoices();
                    selection = _userInterface.Read();
                }

                try {
                    var seedHandler = SeedHandlerGenerator.ParseSelection(selection, _userInterface, _validator);
                    gameBoard = GenerateGameBoard(seedHandler);
                }
                catch (Exception e) {
                    _userInterface.WriteLine(e.Message);
                    return;
                }

                do {
                    while (!_userInterface.NoKeyPressed()) {
                        GameLoop();
                    }
                } while (_userInterface.ReadKey().Key != _userInterface.ExitKey);

                _userInterface.WriteLine("Press any key to exit, or R to reset");
                if (_userInterface.ReadKey().Key != _userInterface.ResetKey) return;
                _userInterface.Clear();
            }
        }
        
        private GameBoard GenerateGameBoard(ISeedHandler handler) {
            try {
                var name = handler.GetName();
                var height = handler.GetHeight();
                var width = handler.GetWidth();
                var seed = handler.GetSeed();
                var properties = new BoardProperties(name, height, width, seed);
                return new GameBoard(properties, _userInterface);
            }
            catch (Exception e) {
                _userInterface.WriteLine(e.Message);
                Environment.Exit(0);
            }

            return null;
        }

        private void GameLoop() {
            Thread.Sleep(StepTime);
            _userInterface.Clear();
            gameBoard.Step();
        }
    }
    
    
}