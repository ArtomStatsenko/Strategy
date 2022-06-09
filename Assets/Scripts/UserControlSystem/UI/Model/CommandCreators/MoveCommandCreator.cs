using System;
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model.Commands;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreators
{
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        private Action<IMoveCommand> _creationCallback;

        [Inject] private AssetsContext _context;

        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnValueChanged += OnValueChanged;
        }

        private void OnValueChanged(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
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