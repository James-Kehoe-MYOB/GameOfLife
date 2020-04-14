namespace GameOfLife.Business_Logic.Interfaces {
    public interface IValidator {

        public bool ValidSelection(string selection);

        public bool ValidHeight(string height);

        public bool ValidWidth(string width);

    }
}