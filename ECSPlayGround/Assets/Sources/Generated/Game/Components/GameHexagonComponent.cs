//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly HexagonComponent hexagonComponent = new HexagonComponent();

    public bool isHexagon {
        get { return HasComponent(GameComponentsLookup.Hexagon); }
        set {
            if (value != isHexagon) {
                if (value) {
                    AddComponent(GameComponentsLookup.Hexagon, hexagonComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Hexagon);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHexagon;

    public static Entitas.IMatcher<GameEntity> Hexagon {
        get {
            if (_matcherHexagon == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Hexagon);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHexagon = matcher;
            }

            return _matcherHexagon;
        }
    }
}
