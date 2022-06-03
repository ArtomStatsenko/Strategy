using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model;

namespace UserControlSystem.UI.Presenter
{
    public class OutlinePresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;

        private Outline _outline;
        
        private void Start()
        {
            if (!TryGetComponent(out _outline))
            {
                _outline = gameObject.AddComponent<Outline>();
            }
            
            _selectedValue.OnSelected += OnSelected;

            OnSelected(_selectedValue.CurrentValue);
        }

        private void OnSelected(ISelectable selected)
        {
            if (selected == null)
            {
                _outline.enabled = false;
                return;
            }

            var selectableComponent = (Component)selected;
            _outline.enabled = selectableComponent.gameObject == gameObject;
        }
    }
}