using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLife.Business_Logic.Models {
    public class BoardProperties {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public string Seed { get; private set; }
        public IUserInterface UserInterface { get; private set; }

        public BoardProperties(int height, int width, string seed, IUserInterface userInterface) {
            Height = height;
            Width = width;
            Seed = seed;
            UserInterface = userInterface;
        }
    }
}