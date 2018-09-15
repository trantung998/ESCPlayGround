using UnityEngine;

namespace Extensions
{
    public static class TransformExtension
    {
        private static Vector3 m_tmpVector3 = Vector3.zero;
        private static Vector2 m_tmpVector2 = Vector2.zero;

        public static void SetEulerAngles(this Transform self, float x, float y, float z)
        {
            m_tmpVector3.Set(x, y, z);
            self.eulerAngles = m_tmpVector3;
        }
        public static void SetEulerAnglesX(this Transform self, float x)
        {
            self.SetEulerAngles(x, self.eulerAngles.y, self.eulerAngles.z);
        }

        public static void SetEulerAnglesY(this Transform self, float y)
        {
            self.SetEulerAngles(self.eulerAngles.x, y, self.eulerAngles.z);
        }

        public static void SetEulerAnglesZ(this Transform self, float z)
        {
            self.SetEulerAngles(self.eulerAngles.x, self.eulerAngles.y, z);
        }
    }
}