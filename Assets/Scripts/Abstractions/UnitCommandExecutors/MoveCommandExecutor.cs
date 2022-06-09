using UnityEngine;

namespace Abstractions.UnitCommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command) =>
            Debug.Log($"{name} is moving to {command.Target}!");
    }
}