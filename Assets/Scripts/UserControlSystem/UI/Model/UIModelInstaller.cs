using Abstractions;
using UserControlSystem.UI.Model.CommandCreators;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public class UIModelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopCommandCreator>().AsTransient();
            Container.Bind<CommandButtonsModel>().AsTransient();
        }
    }
}