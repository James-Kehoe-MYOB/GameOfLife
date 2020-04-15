using System;
using GameOfLife.Business_Logic;
using Xunit;

namespace GameOfLifeTests {
    public class ValidationTests {
        [Fact(DisplayName = "Cannot input invalid seed choice")]
        public void CannotInputInvalidSeedChoice() {
            string input = "4";

            var validator = new Validator();
            
            Assert.False(validator.ValidSelection(input));
        }
    }
}