using Assets.Scripts.Configs;
using Assets.Scripts.Infrasctucture.Core.Providers;
using Assets.Scripts.Infrastructure.Gameplay.Configs;

namespace Assets.Scripts.Infrasctucture.Core.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetsProvider _assetsProvider;

        public StaticDataService(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public BattleRulesConfig BattleSessionConfig => _assetsProvider.GetBattleSessionConfig();

        public LocalDeviceInputSchemesConfig LocalInputSchemesConfig => _assetsProvider.GetLocalInputSchemesConfig();

        public ScenesConfig ScenesConfig => _assetsProvider.GetScenesConfig();
    }
}
