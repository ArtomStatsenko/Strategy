using Abstractions.Commands.CommandInterfaces;
using UserControlSystem.UI.Model.CommandCreators;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public class UIModelInstaller : MonoInstaller
    {
        private const float ProductionTime = 5f;
        private const string Unit = "Unit";

        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>().To<SetRallyPointCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopCommandCreator>().AsTransient();
            Container.Bind<CommandButtonsModel>().AsTransient();
            Container.Bind<float>().WithId(Unit).FromInstance(ProductionTime);
            Container.Bind<string>().WithId(Unit).FromInstance(Unit);
            Container.Bind<BottomCenterMenuModel>().AsSingle();
        }
    }
}