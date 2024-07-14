using Assets.Scripts.Features.InputSources;
using System;
using UnityEngine;

namespace Assets.Scripts.Behaviours.TankBehaviours
{
    [RequireComponent(typeof(TankMoveControllerBehaviour))]
    public class MoveAudioPlayerBehaviour : MonoBehaviour
    {
        private TankMoveControllerBehaviour _move;
        private AudioSource m_MovementAudio;

        [SerializeField] private AudioClip m_EngineIdling;
        [SerializeField] private AudioClip m_EngineDriving;
        [SerializeField] private float m_PitchRange = 0.2f;
        private float m_OriginalPitch;

        private void Awake()
        {
            _move = GetComponent<TankMoveControllerBehaviour>();
            m_MovementAudio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            m_OriginalPitch = m_MovementAudio.pitch;
        }

        private void Update()
        {
            HandleEngineAudio();
        }

        private void HandleEngineAudio()
        {
            if (m_MovementAudio.clip != m_EngineDriving)
                return;

            Vector2 moveVector = new Vector2(_move.m_MovementInputValue, _move.m_TurnInputValue);

            if(moveVector.magnitude <  0.1f)
            { 
                HandleStationaryAudio();
                return;
            }

            HandleInMoveAudio();
        }

        private void HandleStationaryAudio()
        {
            m_MovementAudio.clip = m_EngineIdling;
            m_MovementAudio.pitch = UnityEngine.Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
            m_MovementAudio.Play();
        }

        private void HandleInMoveAudio()
        {
            m_MovementAudio.clip = m_EngineDriving;
            m_MovementAudio.pitch = UnityEngine.Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
            m_MovementAudio.Play();
        }
    }
}
