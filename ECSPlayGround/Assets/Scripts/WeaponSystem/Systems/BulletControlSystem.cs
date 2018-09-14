using Entitas;
using Extensions;

public class BulletControlSystem : IExecuteSystem
{
    private IGroup<GameEntity> activeBullet;

    public BulletControlSystem(Contexts contexts)
    {
        activeBullet = contexts.game.GetGroup(GameMatcher.BulletConfigs);
    }
    
    public void Execute()
    {
        foreach (var gameEntity in activeBullet)
        {
            
        }
    }

    private void UpdatePosition(GameEntity bullet)
    {
        var position = bullet.eventsPosition.value.ToVector2();
//        var speed = bullet
        var speed = bullet.bulletConfigs.BulletSpeed;
//        var detatime = 
    }
}