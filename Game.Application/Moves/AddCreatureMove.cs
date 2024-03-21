namespace Game.Application.Moves;

using API;
using Field;
using Field.API;

public class AddCreatureMove : IMove
{
    private readonly ICreature creature;

    public AddCreatureMove(ICreature creature)
    {
        this.creature = creature;
    }
    
    public void Perform(GameField gameField)
    {
        gameField.AddCreature(creature);
    }
}