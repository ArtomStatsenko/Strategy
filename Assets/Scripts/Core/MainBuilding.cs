using Abstractions;
using UnityEngine;

namespace Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000f;
        [SerializeField] private Sprite _icon;

        private float _health = 1000f;
        private float _spawnDistance = 5f;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public override void ExecuteSpecificCommand(IProduceUnitCommand command) => 
            Instantiate(command.UnitPrefab,
            new Vector3(Random.Range(-_spawnDistance, _spawnDistance), 1f,
                Random.Range(-_spawnDistance, _spawnDistance)), Quaternion.identity, _unitsParent);
    }
}