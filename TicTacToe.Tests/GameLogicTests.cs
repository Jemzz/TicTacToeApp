namespace TicTacToe.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using TicTacToe.Helper.Implementation;
    using TicTacToe.Helper.Interface;

    public class GameLogicTests
    {
        private readonly IGameLogic? _gameLogic;

        public GameLogicTests()
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IGameLogic, GameLogic>()
            .BuildServiceProvider();

            _gameLogic = serviceProvider.GetService<IGameLogic>();
        }

        [Fact]
        public void TicTacToe_TestNoWin()
        {
            // Arrange
            char[] board = ['X', 'O', 'X', 'O', '-', '-', '-', '-', '-'];
            char currentPlayer = 'X';

            // Act
            var result = _gameLogic!.CheckWhoWon(board, currentPlayer);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TicTacToe_TestWin()
        {
            // Arrange
            char[] board = ['X', 'X', 'X', 'O', 'O', '-', '-', '-', '-'];
            char currentPlayer = 'X';

            // Act
            var result = _gameLogic!.CheckWhoWon(board, currentPlayer);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TicTacToe_TestNoDraw()
        {
            // Arrange
            char[] board = ['X', 'O', 'X', 'O', '-', '-', '-', '-', '-'];

            // Act
            var result = _gameLogic!.IsDraw(board);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TicTacToe_TestDraw()
        {
            // Arrange
            char[] board = ['X', 'O', 'X', 'O', 'O', 'X', 'X', 'X', 'O'];

            // Act
            var result = _gameLogic!.IsDraw(board);

            // Assert
            Assert.True(result);
        }
    }
}