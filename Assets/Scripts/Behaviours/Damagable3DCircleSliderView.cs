using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(IDamagable))]
public class Damagable3DCircleSliderView : MonoBehaviour, IInitializable
{
    private IDamagable _damagable;

    [SerializeField] private Slider m_Slider;
    [SerializeField] private Image m_FillImage;
    [SerializeField] private Color m_FullHealthColor = Color.green;
    [SerializeField] private Color m_ZeroHealthColor = Color.red;

    [Inject]
    public void Construct(IDamagable damagable)
    {
        _damagable = damagable;
    }

    [Inject]
    public void Initialize()
    {
        UpdateHealthUI();
        _damagable.OnDamaged += OnDamagedEventHandler;
    }

    private void UpdateHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = _damagable.HealthPoints;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, _damagable.HealthPoints / _damagable.MaxHealthPoints);
    }

    private void OnDamagedEventHandler(object sender, DamageEventArgs e)
    {
        UpdateHealthUI();
    }
}
