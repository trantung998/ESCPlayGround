//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public MoveInputComponent moveInput { get { return (MoveInputComponent)GetComponent(InputComponentsLookup.MoveInput); } }
    public bool hasMoveInput { get { return HasComponent(InputComponentsLookup.MoveInput); } }

    public void AddMoveInput(string newId, float newValue, MoveDirection newDirection, float newDeltaTime) {
        var index = InputComponentsLookup.MoveInput;
        var component = CreateComponent<MoveInputComponent>(index);
        component.Id = newId;
        component.value = newValue;
        component.Direction = newDirection;
        component.deltaTime = newDeltaTime;
        AddComponent(index, component);
    }

    public void ReplaceMoveInput(string newId, float newValue, MoveDirection newDirection, float newDeltaTime) {
        var index = InputComponentsLookup.MoveInput;
        var component = CreateComponent<MoveInputComponent>(index);
        component.Id = newId;
        component.value = newValue;
        component.Direction = newDirection;
        component.deltaTime = newDeltaTime;
        ReplaceComponent(index, component);
    }

    public void RemoveMoveInput() {
        RemoveComponent(InputComponentsLookup.MoveInput);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherMoveInput;

    public static Entitas.IMatcher<InputEntity> MoveInput {
        get {
            if (_matcherMoveInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.MoveInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMoveInput = matcher;
            }

            return _matcherMoveInput;
        }
    }
}
