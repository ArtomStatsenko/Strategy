using Abstractions;
using UnityEngine;
using UnityEngine.AI;

namespace Core.UnitCommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        
        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger("Walk");
            await _stop;
            _animator.SetTrigger("Idle");
        }
    }
}