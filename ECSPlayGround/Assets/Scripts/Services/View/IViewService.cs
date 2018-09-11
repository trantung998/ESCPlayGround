using Entitas;
using UnityEngine;

public interface IViewService
{
    void CreateView(Contexts contexts, IEntity entity, string assetPath, bool usePool);
}