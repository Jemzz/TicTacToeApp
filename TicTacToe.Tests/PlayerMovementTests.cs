namespace TicTacToe.Tests
{
    public class PlayerMovementTests
    {
        [Fact]
        public void TicTacToe_TestValidMove()
        {
            // Arrange
            char[] board = ['-', '-', '-', '-', '-', '-', '-', '-', '-'];
            int position = 0;
            char currentPlayer = 'X';

            // Act
            var result = PlayerMove(board, position, currentPlayer);

            // Assert
            Assert.True(result);
            Assert.Equal('X', board[position]);
        }

        [Fact]
        public void TicTacToe_TestInvalidMove()
        {
            // Arrange
            char[] board = ['-', '-', '-', '-', '-', '-', '-', '-', '-'];
            int position = 0;
            char currentPlayer = 'X';

            // Act
            PlayerMove(board, position, currentPlayer);
            //move to same position
            var result = PlayerMove(board, position, currentPlayer);

            // Assert
            Assert.False(result);
            Assert.Equal('X', board[position]);
        }

        // Just simulating player movement
        static bool PlayerMove(char[] board, int position, char player)
        {
            if (board[position] == '-')
            {
                board[position] = player;
                return true;
            }
            return false;
        }
    }
}