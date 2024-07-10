using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankHealth))]
public class TankHealthView : MonoBehaviour
{
    private TankHealth _health;

    [SerializeField] private Slider m_Slider;
    [SerializeField] private Image m_FillImage;
    [SerializeField] private Color m_FullHealthColor = Color.green;
    [SerializeField] private Color m_ZeroHealthColor = Color.red;

    private void Start()
    {
        _health = GetComponent<TankHealth>();
        UpdateHealthUI();
        _health.OnDamaged += OnDamagedEventHandler;
    }

    private void UpdateHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = _health.CurrentHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, _health.CurrentHealth / _health.MaxHealth);
    }

    private void OnDamagedEventHandler(object sender, DamageEventArgs e)
    {
        UpdateHealthUI();
    }
}
