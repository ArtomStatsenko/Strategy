using System;
using Abstractions;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        private class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
        {
            private readonly UnitMovementStop _unitMovementStop;

            public StopAwaiter(UnitMovementStop unitMovementStop)
            {
                _unitMovementStop = unitMovementStop;
                _unitMovementStop.OnStop += OnStop;
            }

            private void OnStop()
            {
                _unitMovementStop.OnStop -= OnStop;
                OnWaitFinish(new AsyncExtensions.Void());
            }
        }

        public event Action OnStop;

        [SerializeField] private NavMeshAgent _agent;

        private const float Eps = 1e-5f;
        
        private void Update()
        {
            if (_agent.pathPending || _agent.remainingDistance > _agent.stoppingDistance)
            {
                return;
            }

            if (!_agent.hasPath || _agent.velocity.sqrMagnitude < Eps)
            {
                OnStop?.Invoke();
            }
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
    }
}
