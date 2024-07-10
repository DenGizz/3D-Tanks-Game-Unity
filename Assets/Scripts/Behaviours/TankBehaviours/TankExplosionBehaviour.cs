using Assets.Scripts.Infrasctucture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TankHealth))]
public class TankExplosionBehaviour : MonoBehaviour
{
    private IAssetsProvider _assetsProvider;

    private TankHealth _health;

    [Inject]
    public void Construct(IAssetsProvider assetsProvider)
    {
        _assetsProvider = assetsProvider;
    }

    private void Awake()
    { 
        _health = GetComponent<TankHealth>();
        _health.OnDeath += OnDeathEventHandler;
    }

    private void OnDeathEventHandler()
    {
        GameObject explosionInstance = Instantiate(_assetsProvider.GetTankExplosionPrefab());
        ParticleSystem m_ExplosionParticles = explosionInstance.GetComponent<ParticleSystem>();
        AudioSource m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
    }
}
