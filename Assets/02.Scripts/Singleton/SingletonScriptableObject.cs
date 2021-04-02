using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace JHS
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
    {
        static string c_settingFileDirectory = "Assets/Resources";
        static string c_settingFilePath = $"Assets/Resources/{typeof(T).Name}.asset";

        static T __instance;

        public static T s_instance
        {
            get
            {
                if (__instance != null) return __instance;

                Debug.Log(typeof(T).Name);
                __instance = Resources.Load<T>(typeof(T).Name);

#if UNITY_EDITOR
                if (__instance == null)
                {
                    if (!AssetDatabase.IsValidFolder(c_settingFileDirectory))
                    {
                        AssetDatabase.CreateFolder("Assets", "Resources");
                    }

                    __instance = AssetDatabase.LoadAssetAtPath<T>(typeof(T).Name);

                    if (__instance == null)
                    {
                        __instance = CreateInstance<T>();
                        AssetDatabase.CreateAsset(__instance, c_settingFilePath);
                    }
                }
#endif

                return __instance;
            }
        }
    } 
}
