using Assets.Scripts.Features.InputSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Features.Behaviours.TankBehaviours;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class TankController : ITank
    {
        public bool IsAlive => _damagable.IsAlive;

        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }
        public Quaternion Rotation
        {
            get => _transform.rotation;
            set => _transform.rotation = value;
        }

        public float Health => _data.Health;
        public float MaxHealth => _data.MaxHealth;

        public event Action<IDamagable> OnDeath;

        public event EventHandler<DamageEventArgs> OnDamaged;
        public event Action<float> OnHealed;

        private readonly TankData _data;
        private readonly GameObject _gameObject;

        private readonly Transform _transform;
        private readonly IDamagable _damagable;
        private readonly TankMoveControllerBehaviour _moveController;
        private readonly TankShootingControlelrBehaviour _shootingControlelrBehaviour;


        public TankController(TankData data, GameObject gameObeject)
        {
            _gameObject = gameObeject;
            _transform = gameObeject.transform;
            _damagable = gameObeject.GetComponent<IDamagable>();
            _moveController = gameObeject.GetComponent<TankMoveControllerBehaviour>();
            _shootingControlelrBehaviour = gameObeject.GetComponent<TankShootingControlelrBehaviour>();

            _damagable.OnDeath += (args) => OnDeath?.Invoke(this);

            _damagable.OnDamaged += (object s, DamageEventArgs args)
                => OnDamaged?.Invoke(this, new DamageEventArgs(args.DamageTaken));

            _damagable.OnHealed += (args) => OnHealed?.Invoke(args);

        }

        public void SetInputSource(IInputSource inputSource)
        {
            _moveController.SetInputSource(inputSource);
            _shootingControlelrBehaviour.SetInputSource(inputSource);
        }

        public void DisableControl()
        {
            _moveController.enabled = false;
            _shootingControlelrBehaviour.enabled = false;
        }

        public void EnableControl()
        {
            _moveController.enabled = true;
            _shootingControlelrBehaviour.enabled = true;
        }

        public void Revive()
        {
            _gameObject.SetActive(true);
            _damagable.Revive();
        }

        public void TakeDamage(float amount)
        {
            _damagable.TakeDamage(amount);
        }
    }
}
