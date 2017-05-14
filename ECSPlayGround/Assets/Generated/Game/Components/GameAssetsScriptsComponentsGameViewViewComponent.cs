//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Assets.Scripts.Components.GameView.ViewComponent assetsScriptsComponentsGameViewView { get { return (Assets.Scripts.Components.GameView.ViewComponent)GetComponent(GameComponentsLookup.AssetsScriptsComponentsGameViewView); } }
    public bool hasAssetsScriptsComponentsGameViewView { get { return HasComponent(GameComponentsLookup.AssetsScriptsComponentsGameViewView); } }

    public void AddAssetsScriptsComponentsGameViewView(UnityEngine.GameObject newViewObject) {
        var index = GameComponentsLookup.AssetsScriptsComponentsGameViewView;
        var component = CreateComponent<Assets.Scripts.Components.GameView.ViewComponent>(index);
        component.viewObject = newViewObject;
        AddComponent(index, component);
    }

    public void ReplaceAssetsScriptsComponentsGameViewView(UnityEngine.GameObject newViewObject) {
        var index = GameComponentsLookup.AssetsScriptsComponentsGameViewView;
        var component = CreateComponent<Assets.Scripts.Components.GameView.ViewComponent>(index);
        component.viewObject = newViewObject;
        ReplaceComponent(index, component);
    }

    public void RemoveAssetsScriptsComponentsGameViewView() {
        RemoveComponent(GameComponentsLookup.AssetsScriptsComponentsGameViewView);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAssetsScriptsComponentsGameViewView;

    public static Entitas.IMatcher<GameEntity> AssetsScriptsComponentsGameViewView {
        get {
            if(_matcherAssetsScriptsComponentsGameViewView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AssetsScriptsComponentsGameViewView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAssetsScriptsComponentsGameViewView = matcher;
            }

            return _matcherAssetsScriptsComponentsGameViewView;
        }
    }
}
