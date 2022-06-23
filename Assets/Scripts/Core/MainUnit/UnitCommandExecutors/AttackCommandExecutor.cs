using System.Threading.Tasks;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

namespace Core.MainUnit.UnitCommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override async Task ExecuteSpecificCommand(IAttackCommand command) =>
            Debug.Log($"Attack {command.Target}");
    }
}