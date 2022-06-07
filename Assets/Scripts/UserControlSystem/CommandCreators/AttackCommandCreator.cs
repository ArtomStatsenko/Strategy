using System;
using Abstractions;
using UserControlSystem.Commands;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new AttackCommand()));
        }
    }
}