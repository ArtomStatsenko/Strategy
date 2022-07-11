using System.Text;
using Abstractions;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class GameOverScreenPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private GameObject _view;
        
        [Inject] private IGameStatus _gameStatus;

        [Inject]
        private void Init()
        {
            _gameStatus.Status.ObserveOnMainThread().Subscribe(result =>
            {
                var sb = new StringBuilder("Game Over!\n");
                sb.AppendLine(result == 0 ? "Draw!" : $"Faction {result} win!");

                _view.SetActive(true);
                _text.text = sb.ToString();
                Time.timeScale = 0;
            });
        }
    }
}