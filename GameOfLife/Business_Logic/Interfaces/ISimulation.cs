using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Business_Logic.Interfaces {
    public interface ISimulation {
        GameBoard GenerateGameBoard(ISeedHandler selection);
        void Start();
    }
}