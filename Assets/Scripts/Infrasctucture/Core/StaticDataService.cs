using Assets.Scripts.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
