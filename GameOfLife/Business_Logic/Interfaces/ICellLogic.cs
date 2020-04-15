namespace GameOfLife.Business_Logic.Interfaces {
    public interface ICellLogic {
        public bool UpdateLivingStatus(int aliveNeighbours, bool isAlive);
    }
}