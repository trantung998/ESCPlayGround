using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Random = UnityEngine.Random;


public class GameBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private GameContext context;
    private IGroup<GameEntity> gameBoardElements;

    public GameBoardSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
        gameBoardElements = context.GetGroup(GameMatcher.AllOf(GameMatcher.GameBoardElement, GameMatcher.Position));
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameBoard);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameBoard;                                      
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var gameBoard = entities.SingleEntity().gameBoard;
        foreach (var e in gameBoardElements.GetEntities())
        {
            if(e.position.value.x >= gameBoard.cols || e.position.value.y >= gameBoard.rows)
            {
                e.isDestroyed = true;
            }
        }
    }

    public void Initialize()
    {
        var gameBoard = context.CreateGameBoard().gameBoard;
        for (int i = 0; i < gameBoard.rows; i++)
        {
            for (int j = 0; j < gameBoard.cols; j++)
            {
                if (Random.value > 0.91f)
                {
                    context.CreateBlock(j, i);
                }
                else
                {
                    context.CreateRandomPiece(j, i);
                }
            }
        }
    }
}

