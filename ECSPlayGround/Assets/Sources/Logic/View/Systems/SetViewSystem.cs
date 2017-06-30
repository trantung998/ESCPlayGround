using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;


public class SetViewSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext context;

    public SetViewSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.View);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var pos = e.position;
            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y, 0f);
        }
    }
}

