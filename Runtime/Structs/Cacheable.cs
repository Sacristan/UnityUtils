using UnityEngine;

public sealed class Cacheable<T> where T : Component
    {
        readonly System.Func<T> callback;
        T _value = null;

        public Cacheable(System.Func<T> callback)
        {
            this.callback = callback;
        }

        public T Value
        {
            get
            {
                if (_value == null)
                {
                    _value = callback?.Invoke();
                }
                return _value;
            }
        }
    }