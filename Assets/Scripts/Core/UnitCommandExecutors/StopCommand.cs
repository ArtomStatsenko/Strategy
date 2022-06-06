using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class StopCommand : CommandExecutorBase<IStopCommand>, ICommand
    {
        public override void ExecuteSpecificCommand<T>(T command)
        {
            Debug.Log("Stop command");
        }
    }
}