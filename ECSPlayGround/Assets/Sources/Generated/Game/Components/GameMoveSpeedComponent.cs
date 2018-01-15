//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MoveSpeedComponent moveSpeed { get { return (MoveSpeedComponent)GetComponent(GameComponentsLookup.MoveSpeed); } }
    public bool hasMoveSpeed { get { return HasComponent(GameComponentsLookup.MoveSpeed); } }

    public void AddMoveSpeed(float newValue, float newEffectiveValue) {
        var index = GameComponentsLookup.MoveSpeed;
        var component = CreateComponent<MoveSpeedComponent>(index);
        component.value = newValue;
        component.effectiveValue = newEffectiveValue;
        AddComponent(index, component);
    }

    public void ReplaceMoveSpeed(float newValue, float newEffectiveValue) {
        var index = GameComponentsLookup.MoveSpeed;
        var component = CreateComponent<MoveSpeedComponent>(index);
        component.value = newValue;
        component.effectiveValue = newEffectiveValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMoveSpeed() {
        RemoveComponent(GameComponentsLookup.MoveSpeed);
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

    static Entitas.IMatcher<GameEntity> _matcherMoveSpeed;

    public static Entitas.IMatcher<GameEntity> MoveSpeed {
        get {
            if (_matcherMoveSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoveSpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoveSpeed = matcher;
            }

            return _matcherMoveSpeed;
        }
    }
}
