
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using Entitas.Blueprints;
    using SourceMatchOne;
using UnityEngine;

namespace Assets.Scripts.Extensions
{

    public static class BlueprintExtension
    {
        static readonly string[] _pieces = {
            Res.Piece0,
            Res.Piece1,
            Res.Piece2,
            Res.Piece3,
            Res.Piece4,
            Res.Piece5
        };

        public static GameEntity CreateRandomPiece(this GameContext context, int x, int y)
        {
            var entity = context.CreateEntity();
            entity.ApplyBlueprint(context.assetsScriptsComponentsBlueprintsBlueprint.blueprint.Piece());

            entity.AddAssetsScriptsComponentsGameBoardPosition(new IntVector2(x, y));
            entity.AddAssetsScriptsComponentsGameViewAssert(_pieces[Random.Range(0, _pieces.Length)]);

            return entity;
        }

        public static GameEntity CreateGameBoard(this GameContext context)
        {
            var entity = context.CreateEntity();
            entity.ApplyBlueprint(context.assetsScriptsComponentsBlueprintsBlueprint.blueprint.GameBoard());
            return entity;
        }
        public static GameEntity CreateBlocker(this GameContext context, int x, int y)
        {
            var entity = context.CreateEntity();
            entity.ApplyBlueprint(context.assetsScriptsComponentsBlueprintsBlueprint.blueprint.Blocker());

            entity.AddAssetsScriptsComponentsGameBoardPosition(new IntVector2(x, y));
            entity.AddAssetsScriptsComponentsGameViewAssert(Res.Blocker);
            return entity;
        }
    }
}
