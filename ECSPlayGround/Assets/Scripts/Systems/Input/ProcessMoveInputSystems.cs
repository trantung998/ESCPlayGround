using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Entitas;
using Debug = UnityEngine.Debug;


public class ProcessMoveInputSystems : ReactiveSystem<InputEntity>
{
    private Contexts contexts;

    public ProcessMoveInputSystems(Contexts ctx) : base(ctx.input)
    {
        contexts = ctx;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.MoveInput);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMoveInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var input = entities[entities.Count - 1];
        var playerid = input.playerId.value;

        var players = contexts.game.GetEntitiesWithPlayerId(playerid);
//        Debug.Log("GetEntitiesWithPlayerId: " + players.Count);
        var playerMoveSpeedFactor = contexts.game.playerData.value.moveSpeed;
        foreach (var player in players)
        {
            if (player.hasVelocity)
            {
                player.ReplaceVelocity(input.moveInput.value * playerMoveSpeedFactor);
            }
        }
    }
}