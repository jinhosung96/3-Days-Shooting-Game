using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class SingletonObject<T> : MonoBehaviour where T : SingletonObject<T>
    {
        private static T __instance;

        public static T s_instance
        {
            get
            {
                if (__instance == null)
                {
                    var obj = FindObjectOfType<T>();
                    if (obj != null)
                    {
                        __instance = obj;
                    }
                    else
                    {
                        var newSingleton = new GameObject(typeof(T).Name).AddComponent<T>();
                        __instance = newSingleton;
                    }
                }
                return __instance;
            }
            private set
            {
                __instance = value;
            }
        }

        protected void Awake()
        {
            var objs = FindObjectsOfType<T>();
            if (objs.Length != 1)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
    } 
}
