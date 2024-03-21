namespace Game.Field;

using API;

public class GameField
{
    private readonly List<ICreature> creatures = new ();

    public IEnumerable<ICreature> AllCreatures => creatures;

    public void AddCreature(ICreature creature)
    {
        creatures.Add(creature);
    }
}