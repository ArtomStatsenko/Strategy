using UnityEngine;

namespace Abstractions.UnitCommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command) => Debug.Log("Attack");
    }
}