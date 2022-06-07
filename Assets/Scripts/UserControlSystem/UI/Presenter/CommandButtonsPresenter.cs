using System;
using System.Collections.Generic;
using Abstractions;
using UnityEngine;
using UserControlSystem.Commands;
using UserControlSystem.UI.Model;
using UserControlSystem.UI.View;
using Utils.AssetsInjector;

namespace UserControlSystem.UI.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            onSelected(_selectable.CurrentValue);

            _selectable.OnSelected += onSelected;
            _view.OnClick += onButtonClick;
        }

        private void onSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
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

        private void onButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProduceCommand = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProduceCommand)
            {
                unitProduceCommand.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }

            var attackCommand = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (attackCommand)
            {
                attackCommand.ExecuteSpecificCommand(new AttackCommand());
                return;
            }
            
            var moveCommand = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (moveCommand)
            {
                moveCommand.ExecuteSpecificCommand(new MoveCommand());
                return;
            }
            
            var patrolCommand = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (patrolCommand)
            {
                patrolCommand.ExecuteSpecificCommand(new PatrolCommand());
                return;
            }
            
            var stopCommand = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (stopCommand)
            {
                stopCommand.ExecuteSpecificCommand(new StopCommand());
                return;
            }

            throw new ApplicationException(
                $"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}