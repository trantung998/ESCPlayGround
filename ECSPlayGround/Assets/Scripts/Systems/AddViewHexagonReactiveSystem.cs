using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

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
        var globals = contexts.game.globals;
        var hexageonPrefab = contexts.game.globals.value.HexagonGameObject;
        var uiRoot = contexts.game.uiRoot.rectTransform;

        var wSpacing = globals.value.widthSpacing;
        var hSpacing = globals.value.heightSpacing;
        var hOffset = globals.value.heightOffset;

        foreach (var e in  entities)
        {
            var hex = GameObject.Instantiate(hexageonPrefab, uiRoot) as GameObject;
            var hexRectransform =(RectTransform) hex.transform;
            hexRectransform.localScale = Vector3.one;
            var position = new Vector2(e.position.Value.x * wSpacing, e.position.Value.y * hSpacing);

            
            var isEven = e.position.Value.x % 2 == 0;
            var image = hex.GetComponent<Image>();

            if (!isEven)
            {
                image.color = globals.value.oddColor;
                position.y += hOffset;
            }
            hexRectransform.anchoredPosition = position;

            e.AddView(hex);

        }
    }
}

