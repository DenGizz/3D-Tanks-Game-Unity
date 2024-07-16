using Assets.Scripts.Configs;
using Assets.Scripts.Infrastructure.Gameplay.Configs;

namespace Assets.Scripts.Infrasctucture.Core.Services
{
    public interface IStaticDataService
    {
        BattleRulesConfig BattleSessionConfig { get; }
        LocalDeviceInputSchemesConfig LocalInputSchemesConfig { get; }
        ScenesConfig ScenesConfig { get; }
    }
}
