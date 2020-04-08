namespace GameOfLife.Business_Logic {
    public class Cell {
        
        public const char Alive = '1';
        public const char Dead = '0';

        public bool IsAlive { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Display { get; private set; }
        public int AliveNeighbours { get; set; }
        

        public Cell(int x, int y, bool isAlive) {
            X = x;
            Y = y;
            IsAlive = isAlive;
            Display = isAlive ? Alive : Dead;
        }

        public void Update() {
            UpdateLivingStatus();
            
            Display = IsAlive ? Alive : Dead;
        }

        private void UpdateLivingStatus() {
            if (AliveNeighbours < 2) {
                IsAlive = false;
            }
            if (AliveNeighbours == 3) {
                if (!IsAlive) {
                    IsAlive = true;
                }
            }

            if (AliveNeighbours > 3) {
                if (IsAlive) {
                    IsAlive = false;
                }
            }
        }

        public bool Equals(Cell cell) {
            return cell.X == X && cell.Y == Y && cell.IsAlive == IsAlive &&
                   cell.Display == Display;
        }

    }
}