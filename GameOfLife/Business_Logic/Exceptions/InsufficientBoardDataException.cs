using System;

namespace GameOfLife.Business_Logic.Exceptions {
    public class InsufficientBoardDataException : Exception {
        public InsufficientBoardDataException() : base("ERROR: Insufficient amount of board data to fill board"){
            
        }
    }
}