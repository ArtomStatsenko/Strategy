using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

namespace Core.Units
{
    public class MoveCommand : IMoveCommand
    {
        public Vector3 Target { get; }
        
        public MoveCommand(Vector3 target)
        {
            Target = target;
        }
    }
}