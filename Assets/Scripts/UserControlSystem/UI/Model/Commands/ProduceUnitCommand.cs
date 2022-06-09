using Abstractions;
using UnityEngine;
using Utils.AssetsInjector;

namespace UserControlSystem.UI.Model.Commands
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Unit")] private GameObject _unitPrefab;

        public GameObject UnitPrefab => _unitPrefab;
    }
}