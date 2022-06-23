using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        private const string Unit = "Unit";
        
        [InjectAsset(Unit)] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
        
        [Inject(Id = Unit)] public string UnitName { get; }
        [Inject(Id = Unit)] public Sprite Icon { get; }
        [Inject(Id = Unit)] public float ProductionTime { get; }
    }
}