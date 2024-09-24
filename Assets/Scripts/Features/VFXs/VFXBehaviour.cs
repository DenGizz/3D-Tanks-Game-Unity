using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _audioSource;

    public void Play()
    {
        _particleSystem.Play();
        _audioSource.Play();

        float destroyDelay = Mathf.Max(_particleSystem.duration, _audioSource.clip.length);

        Destroy(gameObject, destroyDelay);
    }
}
