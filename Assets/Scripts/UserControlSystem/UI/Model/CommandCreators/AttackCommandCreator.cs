using System;
using Abstractions;
using UserControlSystem.UI.Model.Commands;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        private Action<IAttackCommand> _creationCallback;
        
        [Inject] private AssetsContext _context;

        [Inject]
        private void Init(AttackableValue groundClicks)
        {
            groundClicks.OnValueChanged += OnNewValue;
        }

        private void OnNewValue(IAttackable attackable)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackable)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}