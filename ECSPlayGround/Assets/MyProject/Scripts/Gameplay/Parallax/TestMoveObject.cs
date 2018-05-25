using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gameplay;
using MEC;
using UnityEngine;

namespace Assets.MyProject.Scripts.Gameplay.Parallax
{
    public class TestMoveObject : MonoBehaviour
    {
        [SerializeField] private float speed;
        protected Vector3 _movement;
        protected Vector3 _direction;

        private void Start()
        {
            _direction = Vector3.down;
            Timing.RunCoroutine(Utilities._EmulateUpdate(MyUpdate, this), Segment.Update);
        }

        private void MyUpdate()
        {
            _movement = _direction * (speed) * Time.deltaTime;
            transform.Translate(_movement);
        }
    }
}
