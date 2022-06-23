using System.Linq;
using Abstractions;
using UnityEngine;
using UniRx;
using UnityEngine.EventSystems;
using UserControlSystem.UI.Model;
using Zenject;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackablesRMB;
        [SerializeField] private Transform _groundTransform;

        private Plane _groundPlane;

        [Inject]
        private void Init()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);

            var nonBlockedByUiFramesStream =
                Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());
            
            var lmbClicksStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(0));
            var rmbClicksStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(1));
            var lmbRays = lmbClicksStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
            var rmbRays = rmbClicksStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
            var lmbHitsStream = lmbRays.Select(ray => Physics.RaycastAll(ray));
            var rmbHitsStream = rmbRays.Select(ray => (ray, Physics.RaycastAll(ray)));

            lmbHitsStream.Subscribe(hits =>
            {
                if (IsHit<ISelectable>(hits, out var selectable))
                {
                    _selectedObject.SetValue(selectable);
                }
            });

            rmbHitsStream.Subscribe((ray, hits) =>
            {
                if (IsHit<IAttackable>(hits, out var attackable))
                {
                    _attackablesRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            });
        }

        private bool IsHit<T>(RaycastHit[] hits, out T result) where T : class
        {
            result = default;

            if (hits.Length == 0)
            {
                return false;
            }

            result = hits.Select(hit => hit.collider.GetComponentInParent<T>()).FirstOrDefault(c => c != null);
            return result != default;
        }
    }
}