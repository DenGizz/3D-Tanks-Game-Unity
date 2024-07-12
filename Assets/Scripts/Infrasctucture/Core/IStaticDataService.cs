﻿using Assets.Scripts.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Core
{
    public interface IStaticDataService
    {
        BattleSessionConfig BattleSessionConfig { get; }
        LocalInputSchemesConfig LocalInputSchemesConfig { get; }
    }
}
