using Abstractions;
using UserControlSystem.UI.Model.Commands;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);
    }
}