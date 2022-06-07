using UnityEngine;

namespace Abstractions.UnitCommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command) => Debug.Log("Stop");
    }
}