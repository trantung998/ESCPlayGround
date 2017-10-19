//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HexagonRotationComponent hexagonRotation { get { return (HexagonRotationComponent)GetComponent(GameComponentsLookup.HexagonRotation); } }
    public bool hasHexagonRotation { get { return HasComponent(GameComponentsLookup.HexagonRotation); } }

    public void AddHexagonRotation(int newValue) {
        var index = GameComponentsLookup.HexagonRotation;
        var component = CreateComponent<HexagonRotationComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHexagonRotation(int newValue) {
        var index = GameComponentsLookup.HexagonRotation;
        var component = CreateComponent<HexagonRotationComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHexagonRotation() {
        RemoveComponent(GameComponentsLookup.HexagonRotation);
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

    static Entitas.IMatcher<GameEntity> _matcherHexagonRotation;

    public static Entitas.IMatcher<GameEntity> HexagonRotation {
        get {
            if (_matcherHexagonRotation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HexagonRotation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHexagonRotation = matcher;
            }

            return _matcherHexagonRotation;
        }
    }
}
