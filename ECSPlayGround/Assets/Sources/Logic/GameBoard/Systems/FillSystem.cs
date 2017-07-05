using System;
using System.Collections.Generic;
using Entitas;

public class FillSystem : ReactiveSystem<GameEntity>
{
    private GameContext context;

    public FillSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameBoardElement, GroupEvent.Removed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var gameBoard = context.gameBoard;

        //check cac cot
        for (int i = 0; i < gameBoard.cols; i++)
        {
            var pos = new IntVector2(i, gameBoard.rows);//vi tri tren/duoi cung
            var nextRowPos = GameBoardLogic.GetNextEmptyRow(context, pos);

            while (nextRowPos != gameBoard.rows)
            {
                context.CreateRandomPiece(nextRowPos, i);
                nextRowPos = GameBoardLogic.GetNextEmptyRow(context, pos);
            }
        }
    }
}

