using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Sources.Tools
{
    public class Utilities
    {
        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }

        public static int CircleIncreaseNumber(int current, int threshHold)
        {
            if (current < threshHold - 1) return current + 1;
            if (current >= threshHold - 1) return 0;
            return current + 1;
        }

        public static string ReplaceSymboByNewLine(string text, string symbo)
        {
            return text.Replace(symbo, System.Environment.NewLine);
        }

        public static T LoadScriptableObject<T>(string filePath) where T : ScriptableObject
        {
            return Resources.Load(filePath) as T;
        }
    }
}