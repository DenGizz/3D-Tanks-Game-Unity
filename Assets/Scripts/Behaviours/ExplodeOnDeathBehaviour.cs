using Assets.Scripts.Infrasctucture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(IDamagable))]
public class ExplodeOnDeathBehaviour : MonoBehaviour
{
    private IAssetsProvider _assetsProvider;
    private IDamagable _damagable;

    [Inject]
    public void Construct(IAssetsProvider assetsProvider)
    {
        _assetsProvider = assetsProvider;
    }


    private void Awake()
    {
        _damagable = GetComponent<IDamagable>();
        _damagable.OnDeath += OnDeathEventHandler;
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
