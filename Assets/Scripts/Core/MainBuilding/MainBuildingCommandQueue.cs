using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Zenject;

namespace Core.MainBuilding
{
    public class MainBuildingCommandQueue : MonoBehaviour, ICommandQueue
    {
        [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;

        public void Clear()
        {
        }

        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
            await _setRallyPointCommandExecutor.TryExecuteCommand(command);
        }
    }
}