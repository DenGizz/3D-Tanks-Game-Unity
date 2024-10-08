﻿using UnityEngine;

namespace Assets.Scripts.Features.Behaviours.TankBehaviours
{
    [RequireComponent(typeof(TankShootingControlelrBehaviour))]
    public class TankShootAudioPlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioClip _chargeAudioClip;
        [SerializeField] private AudioClip _fireAudioClip;

        [SerializeField] AudioSource _audioSource;
        private TankShootingControlelrBehaviour _shooter;

        private void Awake()
        {
            _shooter = GetComponent<TankShootingControlelrBehaviour>();

            _shooter.OnFiered += OnFireEventHandler;
            _shooter.OnStartCharge += OnStartChargeEventHandler;
        }

        private void OnFireEventHandler()
        {
            _audioSource.PlayOneShot(_fireAudioClip);
        }

        private void OnStartChargeEventHandler()
        {
            _audioSource.PlayOneShot(_chargeAudioClip);
        }
    }
}
