namespace Game.Starter;

using Application.API;
using Creatures;
using Field;

public interface IGameFieldFactory
{
    GameField CreateGameField(IPlayer firstPlayer, IPlayer secondPlayer);
}

class GameFieldFactory : IGameFieldFactory
{
    public GameField CreateGameField(IPlayer firstPlayer, IPlayer secondPlayer)
    {
        var field = new GameField();
        
        field.AddCreature(new Troll(firstPlayer));
        field.AddCreature(new Troll(secondPlayer));

        return field;
    }
}