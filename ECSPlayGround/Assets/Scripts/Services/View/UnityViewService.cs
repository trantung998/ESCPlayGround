using Entitas;
using Extensions;
using UnityEngine;

public class UnityViewService : IViewService
{
    public void CreateView(Contexts contexts, IEntity entity, string assetPath, bool usePool = true)
    {
        var prefab = Resources.Load<GameObject>(assetPath);
        GameObject viewGo = null;
        if (usePool)
        {
            var poolService = contexts.meta.poolService.instance;
            viewGo = poolService.Spawn(prefab).gameObject;
        }
        else
        {
            viewGo = GameobjectExtension.SpawObject(assetPath);
        }

        if (viewGo != null)
        {
            var viewControler = viewGo.GetComponent<IViewControler>();
            if (viewControler != null)
            {
                viewControler.InitializeView(contexts, entity);
            }

            var eventListeners = viewGo.GetComponents<IEventListener>();
            foreach (var listener in eventListeners)
            {
                listener.RegisterEventListeners(entity);
            }
        }
    }
}