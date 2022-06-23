using System;
using System.Collections.Generic;
using UniRx;
using Abstractions;
using Abstractions.Commands;
using UnityEngine;
using UserControlSystem.UI.Model;
using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private CommandButtonsView _view;
        
        [Inject] private IObservable<ISelectable> _selectedValues;
        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectedValues.Subscribe(OnValueChanged);

            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnlockAllInteractions;
            _model.OnCommandCancel += _view.UnlockAllInteractions;
            _model.OnCommandAccepted += _view.LockInteractions;
        }

        private void OnValueChanged(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }
            
            _currentSelectable = selectable;
            _view.Clear();

            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange(((Component)selectable).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
    }
}