//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlayerIdComponent playerId { get { return (PlayerIdComponent)GetComponent(GameComponentsLookup.PlayerId); } }
    public bool hasPlayerId { get { return HasComponent(GameComponentsLookup.PlayerId); } }

    public void AddPlayerId(string newValue) {
        var index = GameComponentsLookup.PlayerId;
        var component = CreateComponent<PlayerIdComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerId(string newValue) {
        var index = GameComponentsLookup.PlayerId;
        var component = CreateComponent<PlayerIdComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerId() {
        RemoveComponent(GameComponentsLookup.PlayerId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPlayerId;

    public static Entitas.IMatcher<GameEntity> PlayerId {
        get {
            if (_matcherPlayerId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerId = matcher;
            }

            return _matcherPlayerId;
        }
    }
}
