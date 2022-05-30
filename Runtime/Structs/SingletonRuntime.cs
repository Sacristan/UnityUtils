using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonRuntime<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;

    protected virtual bool ShouldDontDestroyOnLoad => false;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject singletonObj = new GameObject(typeof(T).ToString());
                    instance = singletonObj.AddComponent<T>();

                    SingletonRuntime<T> component = instance.GetComponent<SingletonRuntime<T>>();
                    component.OnCreated();

                    if (component.ShouldDontDestroyOnLoad)
                    {
                        DontDestroyOnLoad(singletonObj);
                    }
                }
            }
            return instance;
        }
    }

    public virtual void OnCreated()
    {

    }
}
