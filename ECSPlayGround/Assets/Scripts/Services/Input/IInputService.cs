using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    bool IsTouch { get; }

    Vector3 TouchPosition { get; }

}