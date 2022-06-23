using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Zenject;

namespace Core.MainBuilding
{
    public class MainBuildingCommandQueue : MonoBehaviour, ICommandQueue
    {
        [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;

        public void Clear()
        {
        }

        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
        }
    }
}