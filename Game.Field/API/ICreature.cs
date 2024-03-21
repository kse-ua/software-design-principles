namespace Game.Field.API;

public interface ICreature
{
    IMaster Master { get; }
    
    int Health { get; }

    void AffectDamage(int damage);
}

public abstract class Creature : ICreature
{

    public IMaster Master { get; }

    public int Health { get; private set; }

    public void AffectDamage(int damage)
    {
        Health = Math.Max(0, Health - damage);
    }

    protected Creature(IMaster master, int health)
    {
        Master = master;
        Health = health;
    }
}