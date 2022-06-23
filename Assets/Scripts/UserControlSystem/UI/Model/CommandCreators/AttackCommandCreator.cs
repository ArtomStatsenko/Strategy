using Abstractions;
using Abstractions.Commands.CommandInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);
    }
}