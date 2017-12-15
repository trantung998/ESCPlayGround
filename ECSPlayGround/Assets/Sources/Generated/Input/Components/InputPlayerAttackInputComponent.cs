//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public PlayerAttackInputComponent playerAttackInput { get { return (PlayerAttackInputComponent)GetComponent(InputComponentsLookup.PlayerAttackInput); } }
    public bool hasPlayerAttackInput { get { return HasComponent(InputComponentsLookup.PlayerAttackInput); } }

    public void AddPlayerAttackInput(string newPlayerId) {
        var index = InputComponentsLookup.PlayerAttackInput;
        var component = CreateComponent<PlayerAttackInputComponent>(index);
        component.playerId = newPlayerId;
        AddComponent(index, component);
    }

    public void ReplacePlayerAttackInput(string newPlayerId) {
        var index = InputComponentsLookup.PlayerAttackInput;
        var component = CreateComponent<PlayerAttackInputComponent>(index);
        component.playerId = newPlayerId;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerAttackInput() {
        RemoveComponent(InputComponentsLookup.PlayerAttackInput);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherPlayerAttackInput;

    public static Entitas.IMatcher<InputEntity> PlayerAttackInput {
        get {
            if (_matcherPlayerAttackInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.PlayerAttackInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherPlayerAttackInput = matcher;
            }

            return _matcherPlayerAttackInput;
        }
    }
}
