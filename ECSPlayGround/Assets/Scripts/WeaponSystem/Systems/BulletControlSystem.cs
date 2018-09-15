using Entitas;
using Extensions;

public class BulletControlSystem : IExecuteSystem
{
    private ITimerService _timerService;
    private IGroup<GameEntity> activeBullet;


    public BulletControlSystem(Contexts contexts)
    {
        _timerService = contexts.meta.timeService.instance;
        activeBullet = contexts.game.GetGroup(GameMatcher.BulletConfigs);
    }

    public void Execute()
    {
        foreach (var gameEntity in activeBullet)
        {
            UpdatePosition(gameEntity);
        }
    }

    private void UpdatePosition(GameEntity bullet)
    {
        var position = bullet.eventsPosition.value.ToVector2();
        var dir = bullet.directionComponen.value.ToVector2();

//        var speed = bullet
        var speed = bullet.bulletConfigs.BulletSpeed;
//        var detatime = 
        position += dir * speed * _timerService.Detatime();

        bullet.ReplaceEventsPosition(position.ToVector2D());
    }
}