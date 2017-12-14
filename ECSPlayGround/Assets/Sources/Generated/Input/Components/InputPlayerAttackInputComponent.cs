//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly PlayerAttackInputComponent playerAttackInputComponent = new PlayerAttackInputComponent();

    public bool isPlayerAttackInput {
        get { return HasComponent(InputComponentsLookup.PlayerAttackInput); }
        set {
            if (value != isPlayerAttackInput) {
                var index = InputComponentsLookup.PlayerAttackInput;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : playerAttackInputComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
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
