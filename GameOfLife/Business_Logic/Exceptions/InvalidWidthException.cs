using System;

namespace GameOfLife.Business_Logic.Exceptions {
    public class InvalidWidthException : Exception {
        public InvalidWidthException(string width) : base ("Invalid width!") {
            throw new NotImplementedException();
        }
    }
}