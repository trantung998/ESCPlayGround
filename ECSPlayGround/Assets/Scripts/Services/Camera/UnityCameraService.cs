using UnityEngine;

public class UnityCameraService : ICameraService
{
    public Vector2 MainCameraViewportToWorldPoint(Vector2 position)
    {
        return Camera.main.ViewportToWorldPoint(position);
    }
}