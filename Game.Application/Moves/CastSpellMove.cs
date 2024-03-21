namespace Game.Application.Moves;

using API;
using Field;
using Field.API;

public class CastSpellMove : IMove
{
    private readonly ISpell spell;

    public CastSpellMove(ISpell spell)
    {
        this.spell = spell;
    }

    public void Perform(GameField gameField)
    {
        spell.CastOn(new GameFieldApi(gameField));
    }
}