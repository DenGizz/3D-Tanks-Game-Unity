using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Ui
{
    [CreateAssetMenu(fileName = "UiInstaller", menuName = "Infrasctucture/Installers/UiInstaller")]
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUiFactory>().To<UiFactory>().AsSingle();
            Container.Bind<IUiProvider>().To<UiProvider>().AsSingle();
        }
    }
}
