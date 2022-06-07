using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command) => Debug.Log("Stop");
    }
}