using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model;

namespace UserControlSystem.UI.Presenter
{
    public class OutlinePresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;

        private ISelectable _currentObject;

        private void Start()
        {
            _selectedValue.OnSelected += OnSelected;
            OnSelected(_selectedValue.CurrentValue);
        }

        private void OnSelected(ISelectable selectedObject)
        {
            if (selectedObject == _currentObject)
            {
                return;
            }

            if (_currentObject != null)
            {
                ((Component)_currentObject).GetComponent<Outline>().enabled = false;
            }

            if (selectedObject != null)
            {
                ((Component)selectedObject).GetComponent<Outline>().enabled = true;
            }
            
            _currentObject = selectedObject;
        }
    }
}