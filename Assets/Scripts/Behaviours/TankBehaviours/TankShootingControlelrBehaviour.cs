using Assets.Scripts.Domain;
using Assets.Scripts.Features.InputSources;
using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Behaviours.TankBehaviours
{
    public class TankShootingControlelrBehaviour : MonoBehaviour, IInputReader, IShootable
    {
        public event Action OnFiered;
        public event Action OnStartCharge;

        public float MinLaunchForce => _minLaunchForce;
        public float MaxLaunchForce => _maxLaunchForce;
        public float MaxChargeTime => _maxChargeTime;
        public float CurrentLaunchForce => _currentLaunchForce;

        [SerializeField] private Transform _fireTransform;
        [SerializeField] private float _minLaunchForce = 15f;       
        [SerializeField] private float _maxLaunchForce = 30f; 
        [SerializeField] private float _maxChargeTime = 0.75f;

        private float _currentLaunchForce;         // The force that will be given to the shell when the fire button is released.
        private float _chargeSpeed;                // How fast the launch force increases, based on the max charge time.
        private bool _isFired;                       // Whether or not the shell has been launched with this button press.

        private IShellFactory _shellFactory;
        private IInputSource _inputSource;



        [Inject]
        public void Construct(IShellFactory shellFactory)
        {
            _shellFactory = shellFactory;
        }

        private void OnEnable()
        {
            _currentLaunchForce = _minLaunchForce;
        }

        private void Start ()
        {
            // The rate that the launch force charges up is the range of possible forces by the max charge time.
            _chargeSpeed = (_maxLaunchForce - _minLaunchForce) / _maxChargeTime;
        }

        private void Update ()
        {
            // If the max force has been exceeded and the shell hasn't yet been launched...
            if (_currentLaunchForce >= _maxLaunchForce && !_isFired)
            {
                // ... use the max force and launch the shell.
                _currentLaunchForce = _maxLaunchForce;
                Fire ();
            }
            // Otherwise, if the fire button has just started being pressed...
            else if (_inputSource.GetFireButtonDown)
            {
                // ... reset the fired flag and reset the launch force.
                _isFired = false;
                _currentLaunchForce = _minLaunchForce;

                OnStartCharge?.Invoke();
            }
            // Otherwise, if the fire button is being held and the shell hasn't been launched yet...
            else if (_inputSource.GetFireButton && !_isFired)
            {
                // Increment the launch force and update the slider.
                _currentLaunchForce += _chargeSpeed * Time.deltaTime;
            }
            // Otherwise, if the fire button is released and the shell hasn't been launched yet...
            else if (_inputSource.GetFireButtonUp && !_isFired)
            {
                // ... launch the shell.
                Fire ();
            }
        }

        public void SetInputSource(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }


        private void Fire ()
        {
            _isFired = true;

            IShell shell = _shellFactory.CreateShell(_fireTransform.position, _fireTransform.rotation);
            shell.Lunch(_fireTransform.forward, _currentLaunchForce);

            _currentLaunchForce = _minLaunchForce;

            OnFiered?.Invoke();
        }
    }
}