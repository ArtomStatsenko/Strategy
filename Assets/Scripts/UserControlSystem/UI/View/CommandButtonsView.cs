using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public class CommandButtonsView : MonoBehaviour
    {
        public Action<ICommandExecutor, ICommandQueue> OnClick;

        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _patrolButton;
        [SerializeField] private Button _stopButton;
        [SerializeField] private Button _produceUnitButton;

        private Dictionary<Type, Button> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, Button>
            {
                { typeof(ICommandExecutor<IAttackCommand>), _attackButton },
                { typeof(ICommandExecutor<IMoveCommand>), _moveButton },
                { typeof(ICommandExecutor<IPatrolCommand>), _patrolButton },
                { typeof(ICommandExecutor<IStopCommand>), _stopButton },
                { typeof(ICommandExecutor<IProduceUnitCommand>), _produceUnitButton }
            };
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors, ICommandQueue queue)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var button = _buttonsByExecutorType.First(type => type.Key.IsInstanceOfType(currentExecutor)).Value;
                button.gameObject.SetActive(true);
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor, queue));
            }
        }

        public void Clear()
        {
            foreach (var buttonTypePair in _buttonsByExecutorType)
            {
                buttonTypePair.Value.onClick.RemoveAllListeners();
                buttonTypePair.Value.gameObject.SetActive(false);
            }
        }
        
        public void LockInteractions(ICommandExecutor executor)
        {
            UnlockAllInteractions();
            GetButtonByType(executor.GetType()).GetComponent<Selectable>().interactable = false;
        }

        public void UnlockAllInteractions() => SetInteractable(true);

        private void SetInteractable(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _stopButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
        }

        private Button GetButtonByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType.First(type => type.Key.IsAssignableFrom(executorInstanceType)).Value;
        }
    }
}