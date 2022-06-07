using System;
using Abstractions;
using UserControlSystem.Commands;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new MoveCommand()));
        }
    }
}