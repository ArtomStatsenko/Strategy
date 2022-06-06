using Abstractions;
using UnityEngine;
using Utils.AssetsInjector;

namespace UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Unit")] private GameObject _unitPrefab;

        public GameObject UnitPrefab => _unitPrefab;
    }
}