using System;

namespace GameOfLife.Business_Logic.Exceptions {
    public class SelectionOutOfRangeException : Exception {
        public SelectionOutOfRangeException() : base("Could not assign a seed handler to this selection") {
        }
    }
}