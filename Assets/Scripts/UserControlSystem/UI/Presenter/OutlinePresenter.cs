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
            if (!gameObject.TryGetComponent(out _outline))
            {
                _outline = gameObject.AddComponent<Outline>();
            }

            _selectedValue.OnSelected += OnSelected;

            OnSelected(_selectedValue.CurrentValue);
        }

        private void OnSelected(ISelectable selected)
        {
            _outline.enabled = selected != null;
        }
    }
}