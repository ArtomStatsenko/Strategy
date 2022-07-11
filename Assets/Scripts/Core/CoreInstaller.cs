using Abstractions;
using UnityEngine;
using Zenject;

namespace Core
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private GameStatus _gameStatus;

        public override void InstallBindings()
        {
            Container.Bind<IGameStatus>().FromInstance(_gameStatus);
        }
    }
}