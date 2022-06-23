using System;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UserControlSystem.UI.Model.CommandCreators;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public class CommandButtonsModel
    {
        public event Action<ICommandExecutor> OnCommandAccepted;
        public event Action OnCommandSent;
        public event Action OnCommandCancel;

        [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
        [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
        [Inject] private CommandCreatorBase<IMoveCommand> _mover;
        [Inject] private CommandCreatorBase<IPatrolCommand> _patroller;
        [Inject] private CommandCreatorBase<IStopCommand> _stopper;

        private bool _isCommandPending;

        public void OnCommandButtonClicked(ICommandExecutor commandExecutor, ICommandQueue commandsQueue)
        {
            if (_isCommandPending)
            {
                ProcessOnCancel();
            }
            
            _isCommandPending = true;
            
            OnCommandAccepted?.Invoke(commandExecutor);
            _unitProducer.ProcessCommandExecutor(commandExecutor, command =>
                ExecuteCommandWrapper(command, commandsQueue));
            _attacker.ProcessCommandExecutor(commandExecutor, command =>
                ExecuteCommandWrapper(command, commandsQueue));
            _stopper.ProcessCommandExecutor(commandExecutor, command =>
                ExecuteCommandWrapper(command, commandsQueue));
            _mover.ProcessCommandExecutor(commandExecutor, command =>
                ExecuteCommandWrapper(command, commandsQueue));
            _patroller.ProcessCommandExecutor(commandExecutor, command =>
                ExecuteCommandWrapper(command, commandsQueue));
        }

        private void ExecuteCommandWrapper(object command, ICommandQueue commandsQueue)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                commandsQueue.Clear();
            }
            
            commandsQueue.EnqueueCommand(command);
            _isCommandPending = false;
            OnCommandSent?.Invoke();
        }

        public void OnSelectionChanged()
        {
            _isCommandPending = false;
            ProcessOnCancel();
        }

        private void ProcessOnCancel()
        {
            _unitProducer.ProcessCancel();
            _attacker.ProcessCancel();
            _stopper.ProcessCancel();
            _mover.ProcessCancel();
            _patroller.ProcessCancel();
            OnCommandCancel?.Invoke();
        }
    }
}