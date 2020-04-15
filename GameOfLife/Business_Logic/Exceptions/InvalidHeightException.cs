using System;

namespace GameOfLife.Business_Logic.Exceptions {
    public class InvalidHeightException : Exception {
        public InvalidHeightException(string height) : base(string.Format($"'{height}' is not a valid height")){
        }
    }
}