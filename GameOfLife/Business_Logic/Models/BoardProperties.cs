using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLife.Business_Logic.Models {
    public class BoardProperties {
        public SeedName Name { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public string Seed { get; private set; }

        public BoardProperties(SeedName name, int height, int width, string seed) {
            Name = name;
            Height = height;
            Width = width;
            Seed = seed;
        }
    }
}