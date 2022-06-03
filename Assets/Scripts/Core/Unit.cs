using Abstractions;
using UnityEngine;

namespace Core
{
    public class Unit : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;

        private float _health = 100;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
    }
}