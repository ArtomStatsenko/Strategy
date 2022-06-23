using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command) =>
            Debug.Log($"Patrolling from ({command.From}) to ({command.To})");
    }
}