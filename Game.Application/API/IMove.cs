namespace Game.Application.API;

using Field;

public interface IMove
{
    void Perform(GameField gameField);
}