//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly TouchScreenStateComonent touchScreenStateComonentComponent = new TouchScreenStateComonent();

    public bool isTouchScreenStateComonent {
        get { return HasComponent(InputComponentsLookup.TouchScreenStateComonent); }
        set {
            if (value != isTouchScreenStateComonent) {
                var index = InputComponentsLookup.TouchScreenStateComonent;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : touchScreenStateComonentComponent;

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
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherTouchScreenStateComonent;

    public static Entitas.IMatcher<InputEntity> TouchScreenStateComonent {
        get {
            if (_matcherTouchScreenStateComonent == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.TouchScreenStateComonent);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherTouchScreenStateComonent = matcher;
            }

            return _matcherTouchScreenStateComonent;
        }
    }
}
