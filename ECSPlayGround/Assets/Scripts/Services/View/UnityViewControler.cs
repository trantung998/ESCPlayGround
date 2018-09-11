using Entitas;
using Extensions;
using UnityEngine;

public class UnityViewControler : MonoBehaviour, IViewControler
{
    protected Contexts _contexts;
    protected GameEntity _entity;
    private IPoolService _poolService;

    public Vector2D Position
    {
        get { return transform.position.ToVector2D(); }
        set { transform.position = value.ToVector2(); }
    }

    public Vector2D Scale
    {
        get { return transform.localScale.ToVector2D(); }
        set { transform.localScale = value.ToVector2(); }
    }

    public bool Active
    {
        get { return gameObject.activeInHierarchy; }
        set { gameObject.SetActive(value); }
    }

    public void InitializeView(Contexts contexts, IEntity Entity)
    {
        this._contexts = contexts;
        this._entity = (GameEntity) Entity;

        _poolService = contexts.meta.poolService.instance;
    }

    public void DestroyView(bool usePool = true)
    {
        if (usePool)
        {
            _poolService.Despawn(transform);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}