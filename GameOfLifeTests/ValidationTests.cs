using System;
using System.Collections.Generic;
using GameOfLife.Business_Logic;
using GameOfLife.Business_Logic.Exceptions;
using GameOfLife.Business_Logic.Interfaces;
using GameOfLife.Data_Access;
using GameOfLifeTests.Doubles;
using Moq;
using Xunit;

namespace GameOfLifeTests {
    public class ValidationTests {
        [Theory(DisplayName = "Cannot input invalid seed choice")]
        [InlineData("invalid")]
        [InlineData("4")]
        [InlineData("-2")]
        [InlineData("")]

        public void CannotInputInvalidSeedChoice(string input) {
            
            var validator = new FailCounterValidator();
            var mock = new Mock<IUserInterface>();

            mock.SetupSequence(f => f.Read())
                .Returns(input)
                .Returns("2")
                .Throws(new InvalidOperationException());
            
            mock.Setup(f => f.NoKeyPressed()).Returns(true);
            mock.Setup(f => f.ExitKey).Returns(new ConsoleUI().ExitKey);

            mock.Setup(f => f.ReadKey()).Returns(new ConsoleKeyInfo(' ', 
                new ConsoleUI().ExitKey, false, false,false));

            var sim = new Simulation(mock.Object, validator);
            
            sim.Start();
            
            Assert.Equal(1, validator.selectionfailcount);
        }

        [Theory(DisplayName = "Cannot input invalid height choice")]
        [InlineData("invalid")]
        [InlineData("-4")]
        [InlineData("")]
        public void CannotInputInvalidHeightChoice(string input) {
            
            var mock = new Mock<IUserInterface>();

            mock.SetupSequence(f => f.Read())
                .Returns(input)
                .Returns("10")
                .Throws(new InvalidOperationException());
            
            var validator = new FailCounterValidator();
            
            var handler = new CustomSeedHandler(mock.Object, validator);
            handler.GetHeight();
            
            Assert.Equal(1, validator.heightfailcount);
        }
        
        [Theory(DisplayName = "Cannot input invalid width choice")]
        [InlineData("invalid")]
        [InlineData("-4")]
        [InlineData("")]
        public void CannotInputInvalidWidthChoice(string input) {
            
            var mock = new Mock<IUserInterface>();

            mock.SetupSequence(f => f.Read())
                .Returns(input)
                .Returns("10")
                .Throws(new InvalidOperationException());
            
            var validator = new FailCounterValidator();
            
            var handler = new CustomSeedHandler(mock.Object, validator);
            handler.GetWidth();
            
            Assert.Equal(1, validator.widthfailcount);
        }
        
        [Fact(DisplayName = "Parsing a seed selection outside of range throws an error")]
        public void ParsingASeedSelectionOutsideOfRangeThrowsAnError() {
            var input = "4";
            
            var UI = new ConsoleUI();

            Assert.Throws<SelectionOutOfRangeException>(() => UI.ParseSelection(input));
        }
    }
}