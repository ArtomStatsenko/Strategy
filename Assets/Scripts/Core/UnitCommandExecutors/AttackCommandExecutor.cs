using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command) => Debug.Log("Attack");
    }
}