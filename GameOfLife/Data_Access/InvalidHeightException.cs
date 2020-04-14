using System;

namespace GameOfLife.Data {
    public class InvalidHeightException : Exception {
        public InvalidHeightException(string height) : base(string.Format($"'{height}' is not a valid height")){
        }
    }
}