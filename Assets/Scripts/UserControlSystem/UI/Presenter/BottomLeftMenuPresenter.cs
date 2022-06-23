using System;
using Abstractions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class BottomLeftMenuPresenter : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _selectedImage;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillImage;
        
        [Inject] private IObservable<ISelectable> _selectedValues;

        private void Start()
        {
            _selectedValues.Subscribe(OnValueChanged);
        }

        private void OnValueChanged(ISelectable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _text.enabled = selected != null;

            if (selected == null)
            {
                return;
            }

            _selectedImage.sprite = selected.Icon;
            _text.text = $"{selected.Health}/{selected.MaxHealth}";
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthSlider.value = selected.Health;
            var color = Color.Lerp(Color.red, Color.green, selected.Health / selected.MaxHealth);
            _sliderBackground.color = color * 0.5f;
            _sliderFillImage.color = color;
        }
    }
}