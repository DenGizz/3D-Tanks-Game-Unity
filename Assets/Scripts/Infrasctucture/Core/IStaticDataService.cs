using Assets.Scripts.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Core
{
    public interface IStaticDataService
    {
        BattleRulesConfig BattleSessionConfig { get; }
        LocalInputSchemesConfig LocalInputSchemesConfig { get; }
    }
}
