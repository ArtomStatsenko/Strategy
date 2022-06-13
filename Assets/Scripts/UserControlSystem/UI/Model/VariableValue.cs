using System;
using UnityEngine;
using Utils;

namespace UserControlSystem.UI.Model
{
    public abstract class VariableValue<T> : ScriptableObject, IAwaitable<T>
    {
        public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
        {
            private event Action _continuation;
            
            private readonly VariableValue<TAwaited> _scriptableObjectValueBase;
            private TAwaited _result;
            private bool _isCompleted;
            
            public bool IsCompleted => _isCompleted;
            public TAwaited GetResult() => _result;

            public NewValueNotifier(VariableValue<TAwaited> scriptableObjectValueBase)
            {
                _scriptableObjectValueBase = scriptableObjectValueBase;
                _scriptableObjectValueBase.OnValueChanged += OnValueChanged;
            }

            private void OnValueChanged(TAwaited obj)
            {
                _scriptableObjectValueBase.OnValueChanged -= OnValueChanged;
                _result = obj;
                _isCompleted = true;
                _continuation?.Invoke();
            }

            public void OnCompleted(Action continuation)
            {
                if (_isCompleted)
                {
                    continuation?.Invoke();
                }
                else
                {
                    _continuation = continuation;
                }
            }
        }

        public event Action<T> OnValueChanged;
        
        public T CurrentValue { get; private set; }

        public void SetValue(T value)
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