using Assets.Scripts.Configs;

namespace Assets.Scripts.Infrasctucture.Core
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
