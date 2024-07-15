using Assets.Scripts.Domain;
using Zenject;

namespace Assets.Scripts.Features.Behaviours
{
    internal class ShootableComponentInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IShootable>().FromComponentInHierarchy().AsSingle();
        }
    }
}
