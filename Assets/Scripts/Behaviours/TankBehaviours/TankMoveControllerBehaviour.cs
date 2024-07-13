using Assets.Scripts.Features.InputSources;
using UnityEngine;

namespace Assets.Scripts.Behaviours.TankBehaviours
{
    public class TankMoveControllerBehaviour : MonoBehaviour, IInputReader
    {       
        public float m_Speed = 12f;            
        public float m_TurnSpeed = 180f;       
        public AudioSource m_MovementAudio;    
        public AudioClip m_EngineIdling;       
        public AudioClip m_EngineDriving;      
        public float m_PitchRange = 0.2f;
      
        private Rigidbody m_Rigidbody;         
        private float m_MovementInputValue;    
        private float m_TurnInputValue;        
        private float m_OriginalPitch;

        private IInputSource _inputSource;

        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable ()
        {
            m_Rigidbody.isKinematic = false;
            m_MovementInputValue = 0f;
            m_TurnInputValue = 0f;
        }

        private void OnDisable ()
        {
            m_Rigidbody.isKinematic = true;
        }

        private void Start()
        {
            m_OriginalPitch = m_MovementAudio.pitch;
        }
    
        private void Update()
        {
            m_MovementInputValue = 0;
            m_TurnInputValue = 0;

            if(_inputSource != null)
            {
                m_MovementInputValue = _inputSource.MovementInputValue;
                m_TurnInputValue = _inputSource.TurnInputValue;
            }
        
            EngineAudio();
        }

        private void FixedUpdate()
        {
            // Move and turn the tank.
            Move();
            Turn();
        }

        public void SetInputSource(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }

        private void EngineAudio()
        {
            // If there is no input (the tank is stationary)...
            if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f)
            {
                // ... and if the audio source is currently playing the driving clip...
                if (m_MovementAudio.clip == m_EngineDriving)
                {
                    // ... change the clip to idling and play it.
                    m_MovementAudio.clip = m_EngineIdling;
                    m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play ();
                }
            }
            else
            {
                // Otherwise if the tank is moving and if the idling clip is currently playing...
                if (m_MovementAudio.clip == m_EngineIdling)
                {
                    // ... change the clip to driving and play.
                    m_MovementAudio.clip = m_EngineDriving;
                    m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                    m_MovementAudio.Play();
                }
            }
        }

        private void Move()
        {
            // Adjust the position of the tank based on the player's input.
            // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

            // Apply this movement to the rigidbody's position.
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }

        private void Turn()
        {
            // Adjust the rotation of the tank based on the player's input.
            // Determine the number of degrees to be turned based on the input, speed and time between frames.
            float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

            // Make this into a rotation in the y axis.
            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

            // Apply this rotation to the rigidbody's rotation.
            m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
        }
    }
}