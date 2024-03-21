namespace Game.Application;

using API;
using Field;

public class TwoPlayersGame
{
    private readonly GameField gameField;

    private IPlayer firstPlayer;

    private IPlayer secondPlayer;

    private IPlayer currentPlayer;

    public TwoPlayersGame(GameField gameField, IPlayer firstPlayer, IPlayer secondPlayer)
    {
        this.gameField = gameField;
        this.firstPlayer = firstPlayer;
        this.secondPlayer = secondPlayer;

        currentPlayer = this.firstPlayer;
    }

    public bool TryToMakeMove(IPlayer player, IMove move)
    {
        if (player != currentPlayer)
        {
            return false;
        }

        move.Perform(gameField);
        return true;
    }
    
}