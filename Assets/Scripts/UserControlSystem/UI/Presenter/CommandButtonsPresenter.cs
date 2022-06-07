using System.Collections.Generic;
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model;
using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        
        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            OnSelected(_selectable.CurrentValue);

            _selectable.OnSelected += OnSelected;
            
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnlockAllInteractions;
            _model.OnCommandCancel += _view.UnlockAllInteractions;
            _model.OnCommandAccepted += _view.LockInteractions;
        }

        private void OnSelected(ISelectable selectable)
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