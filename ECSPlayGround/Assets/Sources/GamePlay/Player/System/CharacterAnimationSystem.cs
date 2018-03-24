using System.Collections.Generic;
using System.Linq;
using Entitas;

public class CharacterAnimationSystem : ReactiveSystem<GameEntity>
{
    private GameContext gameContexts;
    private IGroup<GameEntity> characterGroup;

    public CharacterAnimationSystem(Contexts context) : base(context.game)
    {
        gameContexts = context.game;
        
        characterGroup = 
            context.game.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerId, GameMatcher.CharacterControl));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var playerId = entity.playerId;
            var playerEntityList = characterGroup.GetEntities();
            if (playerEntityList != null && playerEntityList.Length > 0)
            {
                var playerEntity = playerEntityList.First(gameEntity => gameEntity.playerId.value == playerId.value);
                if (playerEntity != null)
                {
                    playerEntity.characterControl.value.PlayAnimation(entity.characterFiniteState.State);
                }  
            
            }
            entity.isClean = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAnimationControl;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
//        return null;
          return context.CreateCollector(GameMatcher.AllOf(GameMatcher.AnimationControl, GameMatcher.CharacterFiniteState));
    }

    
}