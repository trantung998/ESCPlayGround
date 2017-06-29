using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas.Blueprints;
using Random = UnityEngine.Random;


public static class Res
{

    public const string Piece0 = "Piece0";
    public const string Piece1 = "Piece1";
    public const string Piece2 = "Piece2";
    public const string Piece3 = "Piece3";
    public const string Piece4 = "Piece4";
    public const string Piece5 = "Piece5";
    public const string Blocker = "Blocker";
}

public static class BlueprintsExtensions
{
    static readonly string[] _pieces = {
        Res.Piece0,
        Res.Piece1,
        Res.Piece2,
        Res.Piece3,
        Res.Piece4,
        Res.Piece5
    };

    public static GameEntity CreateGameBoard(this GameContext context)
    {
        var entity = context.CreateEntity();
        entity.ApplyBlueprint(context.blueprints.value.GetBlueprint("GameBoard"));
        return entity;
    }

    public static GameEntity CreateRandomPiece(this GameContext context, int row, int col)
    {
        var entity = context.CreateEntity();
        entity.ApplyBlueprint(context.blueprints.value.GetBlueprint("Piece"));
        entity.AddPosition(new IntVector2(row, col));
        entity.AddAsset(_pieces[Random.Range(0, _pieces.Length)]);
        return entity;
    }

    public static GameEntity CreateBlock(this GameContext context, int x, int y)
    {
        var entity = context.CreateEntity();
        entity.ApplyBlueprint(context.blueprints.value.GetBlueprint("Blocker"));
        entity.AddPosition(new IntVector2(x, y));
        entity.AddAsset(Res.Blocker);

        return entity;
    }
}

