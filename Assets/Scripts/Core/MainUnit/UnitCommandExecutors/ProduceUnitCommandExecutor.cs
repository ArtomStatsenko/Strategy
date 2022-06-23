using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.MainUnit.UnitCommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;
        [SerializeField] private float _spawnDistance = 5f;
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
            _diContainer.InstantiatePrefab(innerTask.UnitPrefab, new Vector3(
                Random.Range(-_spawnDistance, _spawnDistance), 0,
                Random.Range(-_spawnDistance, _spawnDistance)), Quaternion.identity, _unitsParent);
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