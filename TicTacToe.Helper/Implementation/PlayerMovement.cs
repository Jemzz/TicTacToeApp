using TicTacToe.Helper.Interface;

namespace TicTacToe.Helper.Implementation
{
    public class PlayerMovement : IPlayerMovement
    {
        public void HandlePlayerMovement(char[] board, char currentPlayer)
        {
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = currentPlayer == 'X' ? ConsoleColor.Red : ConsoleColor.Blue;
                Console.WriteLine($"Current player - {currentPlayer}, enter your move (1-9): ");

                // Make sure numbes 1 - 9 is entered, its an unused square and parse returns true otherwise false
                if (int.TryParse(Console.ReadLine(), out int position) && position >= 1 && position <= 9 && board[position - 1] == '-')
                {
                    board[position - 1] = currentPlayer;
                    break;
                }

                // If the criteria isnt met
                Console.WriteLine("Wrong move. Try again.");
            };
        }
    }
}
