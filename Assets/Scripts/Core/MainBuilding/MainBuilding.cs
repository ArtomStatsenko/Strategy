using Abstractions;
using UnityEngine;

namespace Core.MainBuilding
{
    public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
    {
        [SerializeField] private float _maxHealth = 1000f;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        
        private float _health = 1000f;
        public Vector3 RallyPoint { get; set; }

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Transform PivotPoint => _pivotPoint;
    }
}