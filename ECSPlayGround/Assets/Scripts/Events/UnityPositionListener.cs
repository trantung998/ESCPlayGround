using Entitas;
using Extensions;
using UnityEngine;

namespace Events
{
    public class UnityPositionListener : MonoBehaviour, IEventListener, IEventsPositionListener
    {
        GameEntity _entity;

        public void RegisterEventListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.AddEventsPositionListener(this);
        }

        public void OnEventsPosition(GameEntity entity, Vector2D value)
        {
            transform.position = value.ToVector2();
        }
    }
}