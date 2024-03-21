namespace Game.Field.API;

public interface IGameApi
{
    IEnumerable<ICreature> GetCreaturesOwnByMaster(IMaster master);
    
    IEnumerable<ICreature> GetEnemyCreaturesFor(IMaster master);
}

public class GameFieldApi : IGameApi
{
    private readonly GameField gameField;

    public GameFieldApi(GameField gameField)
    {
        this.gameField = gameField;
    }

    public IEnumerable<ICreature> GetCreaturesOwnByMaster(IMaster master)
    {
        return gameField.AllCreatures.Where(creature => creature.Master == master);
    }

    public IEnumerable<ICreature> GetEnemyCreaturesFor(IMaster master)
    {
        return gameField.AllCreatures.Where(creature => creature.Master != master);
    }
}