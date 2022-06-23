using Abstractions;
using UnityEngine;

namespace Core.MainUnit
{
    public class Unit : MonoBehaviour, ISelectable, IAttackable, IUnit
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 100;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;  
        public Transform PivotPoint => _pivotPoint;
    }
}