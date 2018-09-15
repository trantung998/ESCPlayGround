using UnityEngine;

namespace Extensions
{
    public static class VectorExtension
    {
        public static Vector2D ToVector2D(this Vector3 vector3)
        {
            return new Vector2D() {x = vector3.x, y = vector3.y};
        }

        public static Vector2D ToVector2D(this Vector2 vector2)
        {
            return new Vector2D() {x = vector2.x, y = vector2.y};
        }

        public static Vector3D ToVector3D(this Vector3 vector3)
        {
            return new Vector3D {x = vector3.x, y = vector3.y, z = vector3.z};
        }

        public static Vector2 ToVector2(this Vector2D vector2D)
        {
            return new Vector2(vector2D.x, vector2D.y);
        }

        public static Vector3 ToVector3(this Vector3D vector3D)
        {
            return new Vector3(vector3D.x, vector3D.y, vector3D.z);
        }
    }
}