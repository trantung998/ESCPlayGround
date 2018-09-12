using UnityEngine;

public class MouseInputService : IInputService
{
    public bool IsTouch
    {
        get { return Input.GetMouseButton(0); }
    }

    public Vector3 TouchPosition
    {
        get { return Input.mousePosition; }
    }
}