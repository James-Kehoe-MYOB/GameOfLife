using System.Linq;
using GameOfLife.Business_Logic;
using GameOfLife.Data;
using GameOfLife.Data_Access.Interfaces;

namespace GameOfLife.Data_Access {
    public class DefaultSeedHandler : ISeedHandler {
        private readonly SeedName _seedName;
        
        public DefaultSeedHandler(SeedName seedName) {
            _seedName = seedName;
        }

        public SeedName GetName() {
            return _seedName;
        }

        public int GetHeight() {
            return PresetSeeds.SeedList.Find(m => m.Name == _seedName).Height;
        }

        public int GetWidth() {
            return PresetSeeds.SeedList.Find(m => m.Name == _seedName).Width;
        }

        public string GetSeed() {
            return PresetSeeds.SeedList.Find(m => m.Name == _seedName).Seed;
        }
    }
}