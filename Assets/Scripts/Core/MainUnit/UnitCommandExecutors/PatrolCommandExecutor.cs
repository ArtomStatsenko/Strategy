using System.Threading.Tasks;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

namespace Core.MainUnit.UnitCommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override async Task ExecuteSpecificCommand(IPatrolCommand command) =>
            Debug.Log($"Patrolling from ({command.From}) to ({command.To})");
    }
}