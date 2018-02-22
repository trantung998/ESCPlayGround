using System.Collections.Generic;
using Entitas;

public class CharacterAnimationSystem : ReactiveSystem<GameEntity>
{
    private Contexts contexts;
    private IGroup<GameEntity> characterGroup;

    public CharacterAnimationSystem(Contexts context) : base(context.game)
    {
        contexts = context;
        
        characterGroup = context.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.CharacterControl, 
            GameMatcher.PlayerId,
            GameMatcher.CharacterState));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCharacterControl && entity.hasCharacterState;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.CharacterState, GameMatcher.CharacterControl));
    }

    
}