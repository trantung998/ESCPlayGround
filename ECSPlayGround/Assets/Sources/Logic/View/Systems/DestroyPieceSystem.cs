using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;


public class DestroyPieceSystem : ReactiveSystem<GameEntity>
{


    public DestroyPieceSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return new Collector<GameEntity>(
            new [] {
                context.GetGroup(GameMatcher.Asset),
                context.GetGroup(GameMatcher.Destroyed)}, 
            new []
            {
                GroupEvent.Removed,
                GroupEvent.Added
  
            });

//        return new Collector<GameEntity>(
//            new[] {
//                        context.GetGroup(GameMatcher.Asset),
//                        context.GetGroup(GameMatcher.Destroyed)
//            },
//            new[] {
//                        GroupEvent.Removed,
//                        GroupEvent.Added
//            }
//        );
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            DestroyPiece(e.view);
            e.RemoveView();
        }
    }

    private void DestroyPiece(ViewComponent viewComponent)
    {
        var gameObject = viewComponent.gameObject;
        var spriteRender = gameObject.GetComponent<SpriteRenderer>();
        var color = spriteRender.color;
        color.a = 0f;
        spriteRender.material.DOColor(color, 0.2f);

        gameObject.transform.DOScale(Vector3.one*1.3f, 0.2f).OnComplete(() =>
        {
            gameObject.Unlink();
            UnityEngine.Object.Destroy(gameObject);
        });



    }
}

