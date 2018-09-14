//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AtkSpeedComponent atkSpeed { get { return (AtkSpeedComponent)GetComponent(GameComponentsLookup.AtkSpeed); } }
    public bool hasAtkSpeed { get { return HasComponent(GameComponentsLookup.AtkSpeed); } }

    public void AddAtkSpeed(float newValue) {
        var index = GameComponentsLookup.AtkSpeed;
        var component = CreateComponent<AtkSpeedComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAtkSpeed(float newValue) {
        var index = GameComponentsLookup.AtkSpeed;
        var component = CreateComponent<AtkSpeedComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAtkSpeed() {
        RemoveComponent(GameComponentsLookup.AtkSpeed);
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

    static Entitas.IMatcher<GameEntity> _matcherAtkSpeed;

    public static Entitas.IMatcher<GameEntity> AtkSpeed {
        get {
            if (_matcherAtkSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AtkSpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAtkSpeed = matcher;
            }

            return _matcherAtkSpeed;
        }
    }
}
