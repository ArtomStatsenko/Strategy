using Abstractions;
using UnityEngine;

namespace Core.UnitCommandExecutors
{
    public class MoveCommand : CommandExecutorBase<IMoveCommand>, ICommand
    {
        public override void ExecuteSpecificCommand<T>(T command)
        {
            Debug.Log("Move command");
        }
    }
}