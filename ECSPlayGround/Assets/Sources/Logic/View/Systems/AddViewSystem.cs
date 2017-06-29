using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using Entitas;
using UnityEngine;


//tạo view cho piece và block
//sau đó add vào viewcontainer

public class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _viewContainer = new GameObject("Views").transform;
    private readonly GameContext context;



    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        throw new NotImplementedException();
    }

    public AddViewSystem(Contexts context) : base(context.game)
    {
        this.context = context.game;
    }
}

