using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model.Commands;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class PatrolCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;

        protected override IPatrolCommand CreateCommand(Vector3 argument) =>
            new PatrolCommand(_selectable.CurrentValue.PivotPoint.position, argument);
    }
}