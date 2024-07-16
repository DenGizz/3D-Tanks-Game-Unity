﻿using Assets.Scripts.Configs;

namespace Assets.Scripts.Infrasctucture.Core.Services
{
    public interface IStaticDataService
    {
        BattleRulesConfig BattleSessionConfig { get; }
        LocalDeviceInputSchemesConfig LocalInputSchemesConfig { get; }
    }
}
