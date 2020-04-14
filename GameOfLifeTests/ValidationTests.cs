using System;
using GameOfLife.Business_Logic;
using Xunit;

namespace GameOfLifeTests {
    public class ValidationTests {
        [Fact(DisplayName = "Cannot input invalid seed selection")]
        public void CannotInputInvalidSeedSelection() {

            var sim = new Simulation(new InvalidSeedSelectionInput(), new Validator());

            Assert.Throws<Exception>(sim.Start);
        }
    }
}