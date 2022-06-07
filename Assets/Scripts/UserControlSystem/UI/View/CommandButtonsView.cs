using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public class CommandButtonsView : MonoBehaviour
    {
        public event Action<ICommandExecutor> OnClick;

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
                { typeof(CommandExecutorBase<IAttackCommand>), _attackButton },
                { typeof(CommandExecutorBase<IMoveCommand>), _moveButton },
                { typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton },
                { typeof(CommandExecutorBase<IStopCommand>), _stopButton },
                { typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton }
            };
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var button = _buttonsByExecutorType.First(type => type.Key.IsInstanceOfType(currentExecutor)).Value;
                button.gameObject.SetActive(true);
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
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
    }
}