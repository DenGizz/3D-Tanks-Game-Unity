using Assets.Scripts.Configs;
using Assets.Scripts.Infrasctucture.Core.Providers;

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

        public LocalInputSchemesConfig LocalInputSchemesConfig => _assetsProvider.GetLocalInputSchemesConfig();
    }
}
