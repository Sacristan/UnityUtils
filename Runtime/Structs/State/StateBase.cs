using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    public abstract class StateBase<T> where T : System.Enum
    {
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
                }
            }
        }

        public virtual void UpdateState(T oldState)
        {

        }

        public void ResetState()
        {
            CurrentState = default(T);
        }

    }
}