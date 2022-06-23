using UnityEngine;

namespace Abstractions.Commands.CommandInterfaces
{
    public interface ISetRallyPointCommand : ICommand
    {
        Vector3 RallyPoint { get; }
    }
}