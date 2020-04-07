namespace GameOfLife {
    public class Cell {
        
        public const char Alive = '1';
        public const char Dead = '0';

        public bool isAlive { get; set; }
        public int x;
        public int y;
        public char display;
        public int aliveNeighbours;

        public Cell(int x, int y, bool isAlive) {
            this.x = x;
            this.y = y;
            this.isAlive = isAlive;
            display = isAlive ? Alive : Dead;
        }

        public void Update(int aliveNeighbours) {
            this.aliveNeighbours = aliveNeighbours;

            UpdateLivingStatus();
            
            display = isAlive ? Alive : Dead;
        }

        private void UpdateLivingStatus() {
            if (aliveNeighbours < 2) {
                isAlive = false;
            }
            if (aliveNeighbours == 3) {
                if (!isAlive) {
                    isAlive = true;
                }
            }

            if (aliveNeighbours > 3) {
                if (isAlive) {
                    isAlive = false;
                }
            }
        }

        public bool Equals(Cell cell) {
            return cell.x == x && cell.y == y && cell.isAlive == isAlive &&
                   cell.display == display;
        }

    }
}