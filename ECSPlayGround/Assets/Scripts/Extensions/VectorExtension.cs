using UnityEngine;

namespace Extensions
{
    public static class VectorExtension
    {
        public static Vector2D ToVector2D(this Vector3 vector3)
        {
            return new Vector2D() {x = vector3.x, y = vector3.y};
        }

        public static Vector3D ToVector3D(this Vector3 vector3)
        {
            return new Vector3D() {x = vector3.x, y = vector3.y, z = vector3.z};
        }

        public static Vector2 ToVector2(this Vector2D vector2D)
        {
            return new Vector2(vector2D.x, vector2D.y);
        }
    }
}