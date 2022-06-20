using System;
using Abstractions;
using UnityEngine;
using UniRx;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class OutlinePresenter : MonoBehaviour
    {
        [Inject] private IObservable<ISelectable> _selectedValues;

        private ISelectable _currentObject;

        private void Start()
        {
            _selectedValues.Subscribe(OnValueChanged);
        }

        private void OnValueChanged(ISelectable selectedObject)
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