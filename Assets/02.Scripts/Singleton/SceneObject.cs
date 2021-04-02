using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class SceneObject<T> : MonoBehaviour where T : SceneObject<T>
    {
        private static T s_instance;
        public static T Instance
        {
            get
            {
                if (s_instance == null) s_instance = FindObjectOfType<T>();

                return s_instance;
            }
        }
    } 
}
