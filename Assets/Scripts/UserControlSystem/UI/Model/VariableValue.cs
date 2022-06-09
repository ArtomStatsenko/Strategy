using System;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    public class VariableValue<T> : ScriptableObject
    {
        public event Action<T> OnValueChanged;
        
        public T CurrentValue { get; private set; }
    
        public void SetValue(T value)
        {
            CurrentValue = value;
            OnValueChanged?.Invoke(value);
        }
    }
}