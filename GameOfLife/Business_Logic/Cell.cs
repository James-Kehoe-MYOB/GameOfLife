using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLife.Business_Logic {
    public class Cell {
        
        public const char Alive = '\u27D7';
        public const char Dead = ' ';

        public bool IsAlive { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        
        private ICellLogic Logic { get; set; }
        public char Display { get; private set; }
        public int AliveNeighbours { get; set; }
        

        public Cell(int x, int y, bool isAlive, ICellLogic logic) {
            X = x;
            Y = y;
            IsAlive = isAlive;
            Logic = logic;
            Display = isAlive ? Alive : Dead;
        }

        public void Update() {
            IsAlive = Logic.UpdateLivingStatus(AliveNeighbours, IsAlive);
            Display = IsAlive ? Alive : Dead;
        }

        public bool Equals(Cell cell) {
            return cell.X == X && cell.Y == Y && cell.IsAlive == IsAlive &&
                   cell.Display == Display;
        }

    }
}