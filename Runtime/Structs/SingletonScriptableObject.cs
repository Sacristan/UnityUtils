using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
    {
        static T instance;

        public static bool Exists
        {
            get
            {
                FindInstance();
                return instance != null;
            }
        }

        public static T Instance
        {
            get
            {
                FindInstance();
                return instance;
            }
        }

        static void FindInstance()
        {
            if (instance != null) return;

            T[] assets = Resources.LoadAll<T>("");
            if (assets == null || assets.Length < 1)
            {
                throw new System.Exception($"No {typeof(T)} instances exist!");
            }
            else if (assets.Length > 1)
            {
                throw new System.Exception($"There are multiple {typeof(T)} instances!");
            }

            instance = assets[0];
        }
    }
}