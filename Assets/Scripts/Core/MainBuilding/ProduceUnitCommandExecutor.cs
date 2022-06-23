using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using Core.MainUnit;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.MainBuilding
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;
        [Inject] private DiContainer _diContainer;

        private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

        private void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;

            if (innerTask.TimeLeft > 0)
            {
                return;
            }

            RemoveTaskAtIndex(0);

            var instance = _diContainer.InstantiatePrefab(
                innerTask.UnitPrefab, transform.position,
                Quaternion.identity, _unitsParent);
            var queue = instance.GetComponent<ICommandQueue>();
            var mainBuilding = GetComponent<MainBuilding>();
            queue.EnqueueCommand(new MoveCommand(mainBuilding.RallyPoint));
        }

        public void Cancel(int index) => RemoveTaskAtIndex(index);

        private void RemoveTaskAtIndex(int index)
        {
            for (var i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }

            _queue.RemoveAt(_queue.Count - 1);
        }

        public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            if (_queue.Count < _maximumUnitsInQueue)
            {
                _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab,
                    command.UnitName));
            }
        }
    }
}