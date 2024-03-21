namespace Game.Spells;

using Field;
using Field.API;

public class FireballSpell : ISpell
{
    private IMaster caster;

    public FireballSpell(IMaster caster)
    {
        this.caster = caster;
    }
    
    public void CastOn(IGameApi fieldApi)
    {
        var enemyCreatures = fieldApi.GetEnemyCreaturesFor(caster).ToList();
        if (!enemyCreatures.Any())
        {
            return;
        }
        var random = new Random();
        var creature = enemyCreatures[random.Next(0, enemyCreatures.Count)];
        
        creature.AffectDamage(5);
    }
}