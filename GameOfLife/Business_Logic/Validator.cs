using GameOfLife.Business_Logic.Interfaces;

namespace GameOfLife.Business_Logic {
    public class Validator : IValidator {
        public bool ValidSelection(string selection) {
            return int.TryParse(selection, out var number) && (number >= 1 && number <= 3);
        }

        public bool ValidHeight(string height) {
            return int.TryParse(height, out var number) && number > 0;
        }

        public bool ValidWidth(string width) {
            return int.TryParse(width, out var number) && number > 0;
        }
    }
}