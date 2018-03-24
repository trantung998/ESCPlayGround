//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public AtkInputComponent atkInput { get { return (AtkInputComponent)GetComponent(InputComponentsLookup.AtkInput); } }
    public bool hasAtkInput { get { return HasComponent(InputComponentsLookup.AtkInput); } }

    public void AddAtkInput(string newPlayerId, AtkId newId) {
        var index = InputComponentsLookup.AtkInput;
        var component = CreateComponent<AtkInputComponent>(index);
        component.playerId = newPlayerId;
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceAtkInput(string newPlayerId, AtkId newId) {
        var index = InputComponentsLookup.AtkInput;
        var component = CreateComponent<AtkInputComponent>(index);
        component.playerId = newPlayerId;
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveAtkInput() {
        RemoveComponent(InputComponentsLookup.AtkInput);
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

    static Entitas.IMatcher<InputEntity> _matcherAtkInput;

    public static Entitas.IMatcher<InputEntity> AtkInput {
        get {
            if (_matcherAtkInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.AtkInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAtkInput = matcher;
            }

            return _matcherAtkInput;
        }
    }
}
