using GameOfLife.Business_Logic;
using GameOfLife.Data;

namespace GameOfLife.Data_Access.Interfaces {
    public interface ISeedHandler {

        public SeedName GetName();
        public int GetHeight();

        public int GetWidth();

        public string GetSeed();
    }
}