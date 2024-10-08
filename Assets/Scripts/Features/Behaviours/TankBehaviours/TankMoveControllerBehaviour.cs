﻿using Assets.Scripts.Features.InputSources;
using UnityEngine;

namespace Assets.Scripts.Features.Behaviours.TankBehaviours
{
    public class TankMoveControllerBehaviour : MonoBehaviour, IInputReader
    {       
        public float m_Speed = 12f;            
        public float m_TurnSpeed = 180f;       

        private Rigidbody m_Rigidbody;         
        public float m_MovementInputValue;    
        public float m_TurnInputValue;        


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

        private void Update()
        {
            m_MovementInputValue = _inputSource == null ? 0 : _inputSource.MovementInputValue;
            m_TurnInputValue = _inputSource == null ? 0 : _inputSource.TurnInputValue;
        }

        private void FixedUpdate()
        {
            // Move and turn the tank.
            HandleMove();
            HandleTurn();
        }

        public void SetInputSource(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }

        private void HandleMove()
        {
            // Adjust the position of the tank based on the player's input.
            // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

            // Apply this movement to the rigidbody's position.
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }

        private void HandleTurn()
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