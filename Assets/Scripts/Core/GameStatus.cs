using System;
using System.Threading;
using Abstractions;
using UniRx;
using UnityEngine;

namespace Core
{
    public class GameStatus : MonoBehaviour, IGameStatus
    {
        private Subject<int> _status = new Subject<int>();

        public IObservable<int> Status => _status;
        
        private void CheckStatus(object state)
        {
            switch (FactionMember.FactionsCount)
            {
                case 0:
                    _status.OnNext(0);
                    break;
                case 1:
                    _status.OnNext(FactionMember.GetWinner());
                    break;
            }
        }

        private void Update()
        {
            ThreadPool.QueueUserWorkItem(CheckStatus);
        }
    }
}