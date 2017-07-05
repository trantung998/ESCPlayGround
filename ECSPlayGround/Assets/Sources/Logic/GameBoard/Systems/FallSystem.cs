using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

public class FallSystem : ReactiveSystem<GameEntity>
{
    private GameContext context;

    public FallSystem(Contexts contexts) : base(contexts.game)
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
        for (int col = 0; col < gameBoard.cols; col++)
        {
            for (int row = 1; row < gameBoard.rows; row++)
            {
                var pos = new IntVector2(col, row);
                var moveable = context
                    .GetEntitiesWithPosition(pos)
                    .Where(e => e.isMovable)
                    .ToArray();

                foreach (var e in moveable)
                {
                    moveDown(e, pos);
                }
            }
        }
    }

    private void moveDown(GameEntity e, IntVector2 position)
    {
        var nextRow = GameBoardLogic.GetNextEmptyRow(context, position);
        if (nextRow != position.y)
        {
            e.ReplacePosition(new IntVector2(position.x, nextRow));
        }
    }
}

