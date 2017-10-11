using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewHexagonReactiveSystem : ReactiveSystem<GameEntity>
{
    private Contexts contexts;
    public AddViewHexagonReactiveSystem(Contexts context) : base(context.game)
    {
        contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.Position));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.isHexagon;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var hexageonPrefab = contexts.game.globals.value.HexagonGameObject;
        var uiRoot = contexts.game.uiRoot.rectTransform;
        foreach (var e in  entities)
        {
            var hex = GameObject.Instantiate(hexageonPrefab, uiRoot) as GameObject;

            var hexRectransform =(RectTransform) hex.transform;
            hexRectransform.anchoredPosition = new Vector2(e.position.Value.x, e.position.Value.y);
            
        }
    }
}

