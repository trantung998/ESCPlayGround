//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CharacterControlComponent characterControl { get { return (CharacterControlComponent)GetComponent(GameComponentsLookup.CharacterControl); } }
    public bool hasCharacterControl { get { return HasComponent(GameComponentsLookup.CharacterControl); } }

    public void AddCharacterControl(Sources.GamePlay.Player.Scripts.BaseCharacterControler newValue) {
        var index = GameComponentsLookup.CharacterControl;
        var component = CreateComponent<CharacterControlComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCharacterControl(Sources.GamePlay.Player.Scripts.BaseCharacterControler newValue) {
        var index = GameComponentsLookup.CharacterControl;
        var component = CreateComponent<CharacterControlComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCharacterControl() {
        RemoveComponent(GameComponentsLookup.CharacterControl);
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

    static Entitas.IMatcher<GameEntity> _matcherCharacterControl;

    public static Entitas.IMatcher<GameEntity> CharacterControl {
        get {
            if (_matcherCharacterControl == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharacterControl);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacterControl = matcher;
            }

            return _matcherCharacterControl;
        }
    }
}
