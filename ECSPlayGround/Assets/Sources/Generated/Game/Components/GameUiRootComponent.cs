//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity uiRootEntity { get { return GetGroup(GameMatcher.UiRoot).GetSingleEntity(); } }
    public UiRootComponent uiRoot { get { return uiRootEntity.uiRoot; } }
    public bool hasUiRoot { get { return uiRootEntity != null; } }

    public GameEntity SetUiRoot(UnityEngine.RectTransform newRectTransform) {
        if (hasUiRoot) {
            throw new Entitas.EntitasException("Could not set UiRoot!\n" + this + " already has an entity with UiRootComponent!",
                "You should check if the context already has a uiRootEntity before setting it or use context.ReplaceUiRoot().");
        }
        var entity = CreateEntity();
        entity.AddUiRoot(newRectTransform);
        return entity;
    }

    public void ReplaceUiRoot(UnityEngine.RectTransform newRectTransform) {
        var entity = uiRootEntity;
        if (entity == null) {
            entity = SetUiRoot(newRectTransform);
        } else {
            entity.ReplaceUiRoot(newRectTransform);
        }
    }

    public void RemoveUiRoot() {
        uiRootEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UiRootComponent uiRoot { get { return (UiRootComponent)GetComponent(GameComponentsLookup.UiRoot); } }
    public bool hasUiRoot { get { return HasComponent(GameComponentsLookup.UiRoot); } }

    public void AddUiRoot(UnityEngine.RectTransform newRectTransform) {
        var index = GameComponentsLookup.UiRoot;
        var component = CreateComponent<UiRootComponent>(index);
        component.rectTransform = newRectTransform;
        AddComponent(index, component);
    }

    public void ReplaceUiRoot(UnityEngine.RectTransform newRectTransform) {
        var index = GameComponentsLookup.UiRoot;
        var component = CreateComponent<UiRootComponent>(index);
        component.rectTransform = newRectTransform;
        ReplaceComponent(index, component);
    }

    public void RemoveUiRoot() {
        RemoveComponent(GameComponentsLookup.UiRoot);
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

    static Entitas.IMatcher<GameEntity> _matcherUiRoot;

    public static Entitas.IMatcher<GameEntity> UiRoot {
        get {
            if (_matcherUiRoot == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UiRoot);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUiRoot = matcher;
            }

            return _matcherUiRoot;
        }
    }
}
