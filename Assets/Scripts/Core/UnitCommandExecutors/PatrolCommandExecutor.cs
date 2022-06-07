using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command) => Debug.Log("Patrol");
    }
}