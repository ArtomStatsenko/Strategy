using UnityEngine;

namespace Abstractions.Commands.CommandInterfaces
{
    public interface IMoveCommand : ICommand
    {
        public Vector3 Target { get; }
    }
}