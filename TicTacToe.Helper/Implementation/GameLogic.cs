using TicTacToe.Helper.Interface;

namespace TicTacToe.Helper.Implementation
{
    public class GameLogic : IGameLogic
    {
        public bool CheckWhoWon(char[] board, char currentPlayer)
        {
            // all possible wins on the board in 2d array
            var allPossibleWinningMoves = new int[,]
            {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };

            // loops through 2d array and checks all arrays to see if it has a matching set of 3, player who just made the move is deemed the winner
            for (int i = 0; i < allPossibleWinningMoves.GetLength(0); i++)
            {
                if (board[allPossibleWinningMoves[i, 0]] == currentPlayer &&
                    board[allPossibleWinningMoves[i, 1]] == currentPlayer &&
                    board[allPossibleWinningMoves[i, 2]] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDraw(char[] board)
        {
            // If thee board doesnt have any more '-' its a draw
            return !board.Any(x => x == '-');
        }
    }
}
