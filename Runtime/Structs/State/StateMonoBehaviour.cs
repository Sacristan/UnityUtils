using UnityEngine;

namespace Sacristan.Utils
{
    public abstract class StateMonoBehaviour<T> : MonoBehaviour where T : System.Enum
    {
        public event System.Action<T> OnStateChanged;

        public interface IState
        {
            void AddState(T state);
            void RemoveState(T state);
        }

        private T currentState;
        public T CurrentState
        {
            get => currentState;
            set
            {
                if (!currentState.Equals(value))
                {
                    T oldState = currentState;
                    currentState = value;
                    UpdateState(oldState);
                    OnStateChanged?.Invoke(currentState);
                }
            }
        }

        public virtual void UpdateState(T oldState)
        {

        }
    }
}