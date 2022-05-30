using UnityEngine;

namespace Sacristan.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        #region Properties
        public static T Instance => instance;
        public static bool IsInitialized => instance != null;
        #endregion

        #region MonoBehaviour
        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogErrorFormat("Trying to instantiate a second instance of singleton class {0}", typeof(T));
            }
            else
            {
                instance = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
            if (instance == this) instance = null;
        }
        #endregion
    }
}
