using Entitas;
using Extensions;
using UnityEngine;

namespace Events
{
    public class UnityRotationListener : MonoBehaviour, IEventListener, IEventsRorationListener
    {
        GameEntity _entity;

        public void RegisterEventListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.AddEventsRorationListener(this);
        }

        public void OnEventsRoration(GameEntity entity, float angel)
        {
            transform.SetEulerAnglesZ(angel);
        }
    }
}