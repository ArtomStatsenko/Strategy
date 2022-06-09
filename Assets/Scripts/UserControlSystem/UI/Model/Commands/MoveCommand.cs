using Abstractions;
using UnityEngine;

namespace UserControlSystem.UI.Model.Commands
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