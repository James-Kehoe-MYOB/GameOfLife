using System;

namespace GameOfLife.Business_Logic.Exceptions {
    public class InvalidBoardDataFormatException : Exception {
        public InvalidBoardDataFormatException() : base("ERROR: Board Data is not in the correct format"){
            
        }
    }
}