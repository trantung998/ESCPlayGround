using UnityEngine;


public interface ICameraService
{
    Vector2 MainCameraViewportToWorldPoint(Vector2 position);

    Vector3 ScreenToWorldPoint(Vector3 screenPos);
}