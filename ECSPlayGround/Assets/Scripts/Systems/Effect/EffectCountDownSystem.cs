using Entitas;
using UnityEngine;

public class EffectCountDownSystem : IExecuteSystem
{
    private IGroup<GameEntity> effects;
    private GameContext _gameContext;

    public EffectCountDownSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
        effects = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Effect));
    }

    public void Execute()
    {
        foreach (var entity in effects.GetEntities())
        {
            foreach (var effect in entity.effect.effects)
            {
                effect.duration -= Time.deltaTime;
            }
            //Remove effect
            entity.effect.effects.RemoveAll(effect => effect.duration <= 0);
        }
    }
}
