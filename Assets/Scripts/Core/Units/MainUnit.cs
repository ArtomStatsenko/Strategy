using Abstractions;
using Core.Units.UnitCommandExecutors;
using UnityEngine;

namespace Core.Units
{
    public class MainUnit : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;
        [SerializeField] private int _damage = 25;

        private float _health = 100;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Transform PivotPoint => _pivotPoint;
        public int Damage => _damage;
        
        public void ReceiveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }

            _health -= amount;

            if (_health <= 0)
            {
                _animator.SetTrigger(AnimationTypes.Death);
                Invoke(nameof(DestroyUnit), 2f);
            }
        }

        private async void DestroyUnit()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }
    }
}