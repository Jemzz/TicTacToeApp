using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Helper.Implementation;
using TicTacToe.Helper.Interface;

// setting up DI
var serviceProvider = new ServiceCollection()
                .AddSingleton<IBoard, Board>()
                .AddSingleton<IPlayerMovement, PlayerMovement>()
                .AddSingleton<IGameLogic, GameLogic>()
                .AddSingleton<IBoardGame, BoardGame>()
                .BuildServiceProvider();

var boardGame = serviceProvider.GetService<IBoardGame>();

try
{
    // begin game
    boardGame!.SetUp();
}
catch (Exception)
{
    throw;
}