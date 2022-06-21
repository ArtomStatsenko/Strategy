using System;
using Abstractions;
using UserControlSystem.CommandsRealization;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class ProduceUnitCommandCreator : CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new ProduceUnitCommandHeir()));
        }
    }
}