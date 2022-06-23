using System;
using UnityEngine;
using UserControlSystem.UI.Model;
using UserControlSystem.UI.View;
using Zenject;
using UniRx;

namespace UserControlSystem.UI.Presenter
{
    public class BottomCenterMenuPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _uiHolder;

        private IDisposable _productionQueueAddCt;
        private IDisposable _productionQueueRemoveCt;
        private IDisposable _productionQueueReplaceCt;
        private IDisposable _cancelButtonCts;

        [Inject]
        private void Init(BottomCenterMenuModel model, BottomCenterMenuView view)
        {
            model.UnitProducers.Subscribe(unitProducer =>
            {
                _productionQueueAddCt?.Dispose();
                _productionQueueRemoveCt?.Dispose();
                _productionQueueReplaceCt?.Dispose();
                _cancelButtonCts?.Dispose();
                view.Clear();
                _uiHolder.SetActive(unitProducer != null);

                if (unitProducer == null)
                {
                    return;
                }

                _productionQueueAddCt = unitProducer.Queue.ObserveAdd()
                    .Subscribe(addEvent => view.SetTask(addEvent.Value, addEvent.Index));
                _productionQueueRemoveCt = unitProducer.Queue.ObserveRemove()
                    .Subscribe(removeEvent => view.SetTask(null, removeEvent.Index));
                _productionQueueReplaceCt = unitProducer.Queue.ObserveReplace()
                    .Subscribe(replaceEvent => view.SetTask(replaceEvent.NewValue, replaceEvent.Index));
                _cancelButtonCts = view.CancelButtonClicks.Subscribe(unitProducer.Cancel);

                for (var i = 0; i < unitProducer.Queue.Count; i++)
                {
                    view.SetTask(unitProducer.Queue[i], i);
                }
            });
        }
    }
}