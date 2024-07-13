using Assets.Scripts.Domain;
using Zenject;

namespace Assets.Scripts.Behaviours
{
    public class DamagableComponentInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDamagable>().FromComponentInHierarchy().AsSingle();
        }
    }
}
