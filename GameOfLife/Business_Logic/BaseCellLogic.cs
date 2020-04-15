using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLife.Business_Logic {
    public class BaseCellLogic : ICellLogic {

        public bool UpdateLivingStatus(int aliveNeighbours, bool isAlive) {
            if (aliveNeighbours < 2) {
                return false;
            }
            if (aliveNeighbours == 3) {
                return true;
            }
            if (aliveNeighbours > 3) {
                return false;
            }

            return isAlive;
        }
    }
}