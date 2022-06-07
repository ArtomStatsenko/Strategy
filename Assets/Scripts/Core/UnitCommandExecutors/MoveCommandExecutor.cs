using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command) => Debug.Log("Move");
    }
}