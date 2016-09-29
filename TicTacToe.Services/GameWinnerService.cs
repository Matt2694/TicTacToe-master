using System;

namespace TicTacToe.Services{

    public class GameWinnerService : IGameWinnerService{

        private const char SYMBOL_FOR_NO_WINNER = ' ';
        private const char SYMBOL = 'X';

        public char Validate(char[,] gameBoard){

            var currentWinningSymbol = CheckForThreeInARowInHorizontalRow(gameBoard);
            if (currentWinningSymbol != SYMBOL_FOR_NO_WINNER){
                return currentWinningSymbol;
            }
            currentWinningSymbol = CheckForThreeInARowInVerticalColumn(gameBoard);
            if (currentWinningSymbol != SYMBOL_FOR_NO_WINNER){
                return currentWinningSymbol;
            }
            currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);
            return currentWinningSymbol;
        }

        private static char CheckForThreeInARowInHorizontalRow(char[,] gameBoard){

            for (int i = 0; i < 3; i++){
                var columnOneChar = gameBoard[i, 0];
                var columnTwoChar = gameBoard[i, 1];
                var columnThreeChar = gameBoard[i, 2];
                if (columnOneChar == SYMBOL && columnTwoChar == SYMBOL && columnThreeChar == SYMBOL){
                    return columnOneChar;
                }
            }
            return SYMBOL_FOR_NO_WINNER;
        }

        private static char CheckForThreeInARowInVerticalColumn(char[,] gameBoard){

            for (int i = 0; i < 3; i++){
                var rowOneChar = gameBoard[0, i];
                var rowTwoChar = gameBoard[1, i];
                var rowThreeChar = gameBoard[2, i];
                if (rowOneChar == SYMBOL && rowTwoChar == SYMBOL && rowThreeChar == SYMBOL){
                    return rowOneChar;
                }
            }
            return SYMBOL_FOR_NO_WINNER;
        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard){

            var cellTwoChar = gameBoard[1, 1];
            int a = 0;
            for (int i = 0; i < 2; i++){
                var cellOneChar = gameBoard[0, a];
                if (i == 0) {
                    a += 2;
                }
                else {
                    a -= 2;
                }
                var cellThreeChar = gameBoard[2, a];
                if (cellOneChar == cellTwoChar && cellTwoChar == cellThreeChar){
                    return cellOneChar;
                }
            }
            return SYMBOL_FOR_NO_WINNER;
        }
    }
}

