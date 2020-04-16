using GameOfLife.Business_Logic;

namespace GameOfLife {
    class EntryPoint {
        static void Main(string[] args) {
            
            var sim = new Simulation(new ConsoleUI(), new Validator());
            sim.Start();

        }
    }
}