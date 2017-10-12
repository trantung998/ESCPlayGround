using Entitas;
using UnityEngine;


public class CheckClickInputSystem : IExecuteSystem
{
    private Contexts contexts;
    private IGroup<GameEntity> _hexagonGroup;
    public CheckClickInputSystem(Contexts contexts)
    {
        this.contexts = contexts;
        _hexagonGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.View));
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var entities = _hexagonGroup.GetEntities();
            foreach (var entity in entities)
            {
                
            }
        }
    }
}

