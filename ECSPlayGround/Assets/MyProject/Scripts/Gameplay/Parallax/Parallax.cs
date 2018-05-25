using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gameplay.Parallax;
using MEC;
using UnityEngine;

namespace Gameplay.Parallax
{
    public class Parallax : ObjectBounds
    {
        public enum PossibleDirections
        {
            Left,
            Right,
            Up,
            Down,
            Forwards,
            Backwards
        };

        public int numberCloneBg = 1;

        /// the relative speed of the object
        public float ParallaxSpeed = 0;

        public PossibleDirections ParallaxDirection = PossibleDirections.Left;

        protected GameObject[] _clone;
        protected Vector3 _movement;
        protected Vector3 _initialPosition;
        protected Vector3 _newPosition;
        protected Vector3 _direction;
        protected float _width;

        /// <summary>
        /// On start, we store various variables and clone the object
        /// </summary>
        protected virtual void Start()
        {
            if (ParallaxDirection == PossibleDirections.Left || ParallaxDirection == PossibleDirections.Right)
            {
                _width = GetBounds().size.x;
            }

            if (ParallaxDirection == PossibleDirections.Up || ParallaxDirection == PossibleDirections.Down)
            {
                _width = GetBounds().size.y;
            }

            if (ParallaxDirection == PossibleDirections.Forwards || ParallaxDirection == PossibleDirections.Backwards)
            {
                _width = GetBounds().size.z;
            }

            switch (ParallaxDirection)
            {
                case PossibleDirections.Backwards:
                    _direction = Vector3.back;
                    break;
                case PossibleDirections.Forwards:
                    _direction = Vector3.forward;
                    break;
                case PossibleDirections.Down:
                    _direction = Vector3.down;
                    break;
                case PossibleDirections.Up:
                    _direction = Vector3.up;
                    break;
                case PossibleDirections.Left:
                    _direction = Vector3.left;
                    break;
                case PossibleDirections.Right:
                    _direction = Vector3.right;
                    break;
            }


            _initialPosition = transform.position;

//            // we clone the object and position the clone at the end of the initial object
//            _clone = (GameObject) Instantiate(gameObject, _newPosition, transform.rotation);
//            _clone.transform.parent = transform.parent;
//            // we remove the parallax component from the clone to prevent an infinite loop
//            Parallax parallaxComponent = _clone.GetComponent<Parallax>();
//            Destroy(parallaxComponent);
            MakeClone();
            Timing.RunCoroutine(Utilities._EmulateUpdate(MyUpdate, this), Segment.Update);
        }

        private void MakeClone()
        {
            _clone = new GameObject[numberCloneBg];
            for (int i = 0; i < numberCloneBg; i++)
            {
                //Get new pos for clone
                if (ParallaxDirection == PossibleDirections.Left || ParallaxDirection == PossibleDirections.Right)
                {
                    _newPosition = new Vector3(transform.position.x + _width * (i + 1), transform.position.y, transform.position.z);
                }

                if (ParallaxDirection == PossibleDirections.Up || ParallaxDirection == PossibleDirections.Down)
                {
                    _newPosition = new Vector3(transform.position.x, transform.position.y + _width * (i + 1), transform.position.z);
                }

                if (ParallaxDirection == PossibleDirections.Forwards || ParallaxDirection == PossibleDirections.Backwards)
                {
                    _newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _width * (i + 1));
                }

                // we clone the object and position the clone at the end of the initial object
                _clone[i] = (GameObject) Instantiate(gameObject, _newPosition, transform.rotation);
                _clone[i].transform.parent = transform.parent;
                // we remove the parallax component from the clone to prevent an infinite loop
                Parallax parallaxComponent = _clone[i].GetComponent<Parallax>();
                Destroy(parallaxComponent);
            }
        }

        private void UpdatePosition()
        {
            transform.Translate(_movement);
            for (var i = 0; i < _clone.Length; i++)
            {
                _clone[i].transform.Translate(_movement);
            }
        }

        /// <summary>
        /// On Update, we move the object and its clone
        /// </summary>
        protected virtual void MyUpdate()
        {
            // we determine the movement the object and its clone need to apply, based on their speed and the level's speed
//            if (LevelManager.Instance != null)
//            {
//                _movement = _direction * (ParallaxSpeed / 10) * LevelManager.Instance.Speed * Time.deltaTime;
//            }
//            else
            {
                _movement = _direction * (ParallaxSpeed / 10) * Time.deltaTime;
            }

            // we move both objects
            UpdatePosition();


            // if the object has reached its left limit, we teleport both objects to the right
            if (ShouldResetPosition())
            {
                transform.Translate(-_direction * _width);
                for (var i = 0; i < _clone.Length; i++)
                {
                    _clone[i].transform.Translate(-_direction * _width);
                }
            }
        }

        protected virtual bool ShouldResetPosition()
        {
            switch (ParallaxDirection)
            {
                case PossibleDirections.Backwards:
                    if (transform.position.z + _width * numberCloneBg < _initialPosition.z)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case PossibleDirections.Forwards:
                    if (transform.position.z - _width * numberCloneBg> _initialPosition.z)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case PossibleDirections.Down:
                    if (transform.position.y + _width * numberCloneBg< _initialPosition.y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case PossibleDirections.Up:
                    if (transform.position.y - _width * numberCloneBg> _initialPosition.y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case PossibleDirections.Left:
                    if (transform.position.x + _width * numberCloneBg< _initialPosition.x)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case PossibleDirections.Right:
                    if (transform.position.x - _width * numberCloneBg> _initialPosition.x)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }

            return false;
        }
    }
}