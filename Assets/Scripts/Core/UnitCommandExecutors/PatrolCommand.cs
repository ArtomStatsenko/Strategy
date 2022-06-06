using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class PatrolCommand : CommandExecutorBase<IPatrolCommand>, ICommand
    {
        public override void ExecuteSpecificCommand<T>(T command)
        {
            Debug.Log("Patrol command");
        }
    }
}