using Extensions;
using UnityEngine;

public class UnityCameraService : ICameraService
{
    public Vector2 MainCameraViewportToWorldPoint(Vector2 position)
    {
        return Camera.main.ViewportToWorldPoint(position);
    }

    public Vector3 ScreenToWorldPoint(Vector3 screenPos)
    {
        return Camera.main.ScreenToWorldPoint(screenPos);
    }
}