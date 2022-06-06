using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class AttackCommand : CommandExecutorBase<IAttackCommand>, ICommand
    {
        public override void ExecuteSpecificCommand<T>(T command)
        {
            Debug.Log("Attack command");
        }
    }
}