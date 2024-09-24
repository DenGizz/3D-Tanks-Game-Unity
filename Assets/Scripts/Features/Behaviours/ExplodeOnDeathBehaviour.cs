using Assets.Scripts.Domain;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Core.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Features.Behaviours
{
    [RequireComponent(typeof(IDamagable))]
    public class ExplodeOnDeathBehaviour : MonoBehaviour, IInitializable
    {
        private IAssetsProvider _assetsProvider;
        private IDamagable _damagable;
        private IVFXFactory _fxFactory;

        [Inject]
        public void Construct(IAssetsProvider assetsProvider, IDamagable damagable, IVFXFactory fxFactory)
        {
            _assetsProvider = assetsProvider;
            _damagable = damagable;
            _fxFactory = fxFactory;
        }

        [Inject]
        public void Initialize()
        {
            _damagable.OnDeath += OnDeathEventHandler;
        }

        private void OnDeathEventHandler(IDamagable deadDamageable)
        {
            _fxFactory.CreateTankExplosion(transform.position).Play();
        }
    }
}
