using System;
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model.Commands;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        private Action<IPatrolCommand> _creationCallback;
        
        [Inject] private AssetsContext _context;

        [Inject] private SelectableValue _selectable;
        
        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnValueChanged += OnNewValue;
        }

        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(
                _context.Inject(new PatrolCommand(_selectable.CurrentValue.PivotPoint.position, groundClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
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
