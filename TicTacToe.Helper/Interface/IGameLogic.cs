namespace TicTacToe.Helper.Interface
{
    public interface IGameLogic
    {
        bool CheckWhoWon(char[] board, char currentPlayer);

        bool IsDraw(char[] board);
    }
}
