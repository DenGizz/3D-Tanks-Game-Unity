using Assets.Scripts.Configs;

namespace Assets.Scripts.Infrasctucture.Core
{
    public interface IStaticDataService
    {
        BattleRulesConfig BattleSessionConfig { get; }
        LocalInputSchemesConfig LocalInputSchemesConfig { get; }
    }
}
