namespace GameOfLife.Business_Logic.Interfaces {
    public interface ISimulation {
        GameBoard GenerateGameBoard();
        void Start();
    }
}