//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly InputDestroyComponent inputDestroyComponent = new InputDestroyComponent();

    public bool isInputDestroy {
        get { return HasComponent(InputComponentsLookup.InputDestroy); }
        set {
            if (value != isInputDestroy) {
                var index = InputComponentsLookup.InputDestroy;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : inputDestroyComponent;

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

    static Entitas.IMatcher<InputEntity> _matcherInputDestroy;

    public static Entitas.IMatcher<InputEntity> InputDestroy {
        get {
            if (_matcherInputDestroy == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputDestroy);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputDestroy = matcher;
            }

            return _matcherInputDestroy;
        }
    }
}
