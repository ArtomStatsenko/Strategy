using System;
using Abstractions;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue),
        order = 0)]
    public class SelectableValue : ScriptableObject
    {
        public event Action<ISelectable> OnSelected;
        
        public ISelectable CurrentValue { get; private set; }

        public void SetValue(ISelectable value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }
}