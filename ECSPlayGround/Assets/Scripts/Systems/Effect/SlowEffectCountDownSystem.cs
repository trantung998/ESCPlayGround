using Entitas;
using UnityEngine;

public class SlowEffectCountDownSystem : IExecuteSystem
{
    private IGroup<GameEntity> effects;
    private GameContext _gameContext;
    private bool checkRemove = false;
    public SlowEffectCountDownSystem(Contexts gameContext)
    {
        _gameContext = gameContext.game;
        effects = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.SlowListComponnet));
    }

    public void Execute()
    {
        foreach (var entity in effects.GetEntities())
        {
            foreach (var effect in entity.slowListComponnet.listEffect)
            {
                effect.duration -= Time.deltaTime;
                if (effect.duration <= 0)
                {
                    checkRemove = true;
                }
            }

            if (checkRemove)
            {
                //Remove effect
                var numberItemremoved = entity.slowListComponnet.listEffect.RemoveAll(effect => effect.duration <= 0);
                if (numberItemremoved > 0)
                {
                    entity.isUpdateEffect = false;
                    entity.isUpdateEffect = true;
                    checkRemove = false;
                    Debug.Log("hillo");
                }
            }
        }
    }
}
