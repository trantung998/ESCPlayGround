using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;


public class VelocityHandlerSystem : IExecuteSystem
{
    private Contexts contexts;
    private IGroup<GameEntity> moveableEntities;
    public VelocityHandlerSystem(Contexts ctx)
    {
        contexts = ctx;
        moveableEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
    }

    public void Execute()
    {
        foreach (var entity in moveableEntities.GetEntities())
        {
            var pos = entity.position.value;
            entity.ReplacePosition(pos + entity.velocity.value);
        }
    }
}