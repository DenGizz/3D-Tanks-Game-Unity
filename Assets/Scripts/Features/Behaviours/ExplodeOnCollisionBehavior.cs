using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Features.Behaviours
{
    public class ExplodeOnCollisionBehavior : MonoBehaviour
    {
        private IVFXFactory _vfxFactory;

        [Inject]
        public void Construct(IVFXFactory vfxFactory)
        {
            _vfxFactory = vfxFactory;
        }

        private void OnTriggerEnter(Collider other)
        {
            _vfxFactory.CreateShellExplosion(transform.position).Play();
        }
    }
}
