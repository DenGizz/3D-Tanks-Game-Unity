using Assets.Scripts.Infrasctucture;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;          
    public Slider m_Slider;                        
    public Image m_FillImage;                      
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;    

    public bool IsAlive => !m_Dead;

    public event Action OnDeath;

    private float m_CurrentHealth;  
    private bool m_Dead;



    public void Revive()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }
    

    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth -= amount;
        SetHealthUI();

        if(m_CurrentHealth <=0f && !m_Dead)
            Death();
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth/m_StartingHealth);
    }


    private void Death()
    {
        m_Dead = true;
        gameObject.SetActive(false);

        OnDeath?.Invoke();
    }
}