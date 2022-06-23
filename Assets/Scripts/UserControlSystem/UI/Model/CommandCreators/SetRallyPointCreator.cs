using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class SetRallyPointCommandCreator : CancellableCommandCreatorBase<ISetRallyPointCommand, Vector3>
    {
        protected override ISetRallyPointCommand CreateCommand(Vector3 argument) => new SetRallyPointCommand(argument);
    }
}