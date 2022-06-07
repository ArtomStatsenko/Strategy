using System;
using Abstractions;
using UserControlSystem.Commands;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public class StopCommandCreator : CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new StopCommand()));
        }
    }
}