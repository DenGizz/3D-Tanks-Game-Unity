using System;
using Assets.Scripts.Domain;
using Assets.Scripts.Features.InputSources;
using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Features.Behaviours.TankBehaviours
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

        private float _currentLaunchForce;
        private float _chargeSpeed;

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
            _chargeSpeed = (_maxLaunchForce - _minLaunchForce) / _maxChargeTime;
        }

        private void Update()
        {
            if (_inputSource.GetFireButtonDown)
            {
                _currentLaunchForce = _minLaunchForce;
                OnStartCharge?.Invoke();
            }

            if (_inputSource.GetFireButton)
                _currentLaunchForce += _chargeSpeed * Time.deltaTime;

            if (_inputSource.GetFireButtonUp)
            {
                _currentLaunchForce = Mathf.Clamp(_currentLaunchForce, _minLaunchForce, _maxLaunchForce);
                Fire();
                _currentLaunchForce = 0;
            }
        }

        public void SetInputSource(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }

        private void Fire ()
        {
            IShell shell = _shellFactory.CreateShell(_fireTransform.position, _fireTransform.rotation);
            shell.Lunch(_fireTransform.forward, _currentLaunchForce);
            OnFiered?.Invoke();
        }
    }
}