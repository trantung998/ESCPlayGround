//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Entitas;
//using UnityEngine;
//
//public class DebugMessageSystem : ReactiveSystem<GameEntity>
//{
//    public DebugMessageSystem(IContext<GameEntity> context) : base(context)
//    {
//    }
//
//    public DebugMessageSystem(Collector<GameEntity> collector) : base(collector)
//    {
//    }
//
//    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
//    {
//        return context.CreateCollector(GameMatcher.DebugMessage);
//    }
//
//    protected override bool Filter(GameEntity entity)
//    {
//        return entity.hasDebugMessage;
//    }
//
//    protected override void Execute(List<GameEntity> entities)
//    {
//        // this is the list of entities that meet our conditions
//        foreach (var e in entities)
//        {
//            // we can safely access their DebugMessage component
//            // then grab the string data and print it
//            Debug.Log(e.debugMessage.message);
//        }
//    }
//}