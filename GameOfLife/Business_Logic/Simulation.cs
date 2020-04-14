using System;
using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLife.Business_Logic {
    public class Simulation : ISimulation {
        private const int StepTime = 200;
        private readonly IUserInterface _userInterface;
        
        public Simulation(IUserInterface userInterface) {
            _userInterface = userInterface;
        }

        public GameBoard GenerateGameBoard() {
            var properties = _userInterface.ReadSelection();
            return new GameBoard(properties, _userInterface);
        }

        public void Start() {
            _userInterface.WriteChoices();
            var gameBoard = GenerateGameBoard();
            Console.Clear();
            gameBoard.Step();
            
            while (true) {
                System.Threading.Thread.Sleep(StepTime);
                Console.Clear();
                gameBoard.Step();
            }
        }
    }
    
    
}