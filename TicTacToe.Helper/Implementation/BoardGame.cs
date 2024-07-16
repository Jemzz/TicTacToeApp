using TicTacToe.Helper.Interface;

namespace TicTacToe.Helper.Implementation
{
    public class BoardGame(IBoard board, IGameLogic gameLogic, IPlayerMovement playerMovement) : IBoardGame
    {
        private readonly IBoard _board = board;
        private readonly IGameLogic _gameLogic = gameLogic;
        private readonly IPlayerMovement _playerMovement = playerMovement;
        char[] tictacboard = ['-', '-', '-', '-', '-', '-', '-', '-', '-'];
        char currentPlayer = 'X';

        public void SetUp()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Welcome to your friendly neighbourhood Tic Tac Toe, Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"RULES");
            Console.WriteLine($"-------------------------------------------------------------------------------");
            Console.WriteLine($"Each square represents the number 1-9. i.e Top left to top right is 1-3 and etc");
            Console.WriteLine($"");
            Console.WriteLine($"To WIN if you're X or O match 3 Vertically, Horizontally or Diagonally");
            Console.WriteLine($"");
            Console.WriteLine($"If the grid is full and no player has 3 in a row, its a DRAW");
            Console.WriteLine($"Press any key to begin...");
            Console.ReadKey();

            while (true)
            {
                Console.ResetColor();
                // introduction
                Console.Clear();

                // Draw the board
                _board.DrawBoard(tictacboard);

                // Handle player input for move
                _playerMovement.HandlePlayerMovement(tictacboard, currentPlayer);

                //check if theres a winner, if so show who won
                if (_gameLogic.CheckWhoWon(tictacboard, currentPlayer))
                {
                    Console.Clear();
                    _board.DrawBoard(tictacboard);
                    Console.WriteLine("");
                    Console.WriteLine($"Player {(currentPlayer == 'X' ? 1 : 2)} has won!");
                    break;
                }
                else if (_gameLogic.IsDraw(tictacboard)) //check if its a draw
                {
                    Console.Clear();
                    _board.DrawBoard(tictacboard);
                    Console.WriteLine("Unfortunately its Draw!");
                    break;
                }
                else
                {
                    // set current player after each move
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
            };
        }
    }
}
