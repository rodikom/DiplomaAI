using UnityEngine;
using UnityEngine.UI;
using Interfaces;
using TMPro;
using System;

namespace UI
{
    public class StatsBarsView : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Slider manaSlider;
        [SerializeField] private Slider staminaSlider;
        [SerializeField] private TMP_Text expText;

        private IStats _stats;
        private IExperienceService _exp;

        private Image _healthFill;
        private Image _manaFill;
        private Image _staminaFill;

        private void Start()
        {
            _stats = ServiceLocator.Get<IStats>();
            _exp = ServiceLocator.Get<IExperienceService>();

            Bind(_stats.Health, healthSlider, ref _healthFill);
            Bind(_stats.Mana, manaSlider, ref _manaFill);
            Bind(_stats.Stamina, staminaSlider, ref _staminaFill);

            _exp.OnExperienceChanged += UpdateExp;
            UpdateExp(_exp.Experience.Current);
        }

        private void Bind(Resource resource, Slider slider, ref Image fillImage)
        {
            fillImage = slider.fillRect.GetComponent<Image>();

            Image currentFill = fillImage;

            Refresh();

            resource.OnValueChanged += _ => Refresh();

            void Refresh()
            {
                slider.maxValue = resource.Max;
                slider.value = resource.Current;

                if (currentFill != null)
                    currentFill.enabled = resource.Current > 0.01f;
            }
        }


        private void UpdateExp(float value)
        {
            expText.text = value.ToString("0");
        }
    }
}