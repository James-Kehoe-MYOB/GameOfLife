using GameOfLife.Business_Logic;
using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLifeTests.Doubles {
    public class FailCounterValidator : IValidator {
        public int selectionfailcount { get; private set; }
        public int heightfailcount { get; private set; }
        public int widthfailcount { get; private set; }
        
        
        Validator _validator = new Validator();
        public bool ValidSelection(string selection) {
            if (!_validator.ValidSelection(selection)) {
                selectionfailcount++;
            }
            return _validator.ValidSelection(selection);
        }

        public bool ValidHeight(string height) {
            if (!_validator.ValidHeight(height)) {
                heightfailcount++;
            }
            return _validator.ValidHeight(height);
        }

        public bool ValidWidth(string width) {
            if (!_validator.ValidWidth(width)) {
                widthfailcount++;
            }
            return _validator.ValidWidth(width);
        }
    }
}