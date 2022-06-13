using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model.Commands;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class MoveCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveCommand(argument);
    }
}