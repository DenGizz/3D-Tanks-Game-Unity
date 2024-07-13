using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
        _damagable.OnHealed += OnHealedEventHandler;
    }

    private void UpdateHealthUI()
    {
        m_Slider.value = _damagable.HealthPoints;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, _damagable.HealthPoints / _damagable.MaxHealthPoints);
    }

    private void OnDamagedEventHandler(object sender, DamageEventArgs e)
    {
        UpdateHealthUI();
    }

    private void OnHealedEventHandler(float heal)
    {
        UpdateHealthUI();
    }
}
