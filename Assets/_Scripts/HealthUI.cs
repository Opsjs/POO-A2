using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField, Required] EntityHealth _playerHealth;

    int CachedMaxHealth { get; set; }
    private void Start()
    {
        UpdateSlider(_playerHealth.MaxHealth);
        _playerHealth.OnHealthUpdate += UpdateSlider;
    }
    public void UpdateSlider(int newHealthValue)
    {
        _slider.value = newHealthValue;
        _text.text = $"{newHealthValue} / {_playerHealth.MaxHealth}";
    }

}
