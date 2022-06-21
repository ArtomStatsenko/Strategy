using System;
using UnityEngine;

namespace Abstractions
{
    public abstract class VariableValue<T> : ScriptableObject, IAwaitable<T>
    {
        private class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
        {
            private readonly VariableValue<TAwaited> _scriptableObjectValueBase;

            public NewValueNotifier(VariableValue<TAwaited> scriptableObjectValueBase)
            {
                _scriptableObjectValueBase = scriptableObjectValueBase;
                _scriptableObjectValueBase.OnValueChanged += OnNewValue;
            }

            private void OnNewValue(TAwaited obj)
            {
                _scriptableObjectValueBase.OnValueChanged -= OnNewValue;
                OnWaitFinish(obj);
            }
        }

        public event Action<T> OnValueChanged;
        
        public T CurrentValue { get; private set; }

        public virtual void SetValue(T value)
        {
            CurrentValue = value;
            OnValueChanged?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }
}