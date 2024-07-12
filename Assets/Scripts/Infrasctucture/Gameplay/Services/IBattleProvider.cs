using Assets.Scripts.Domain;
using Assets.Scripts.Tank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrasctucture.Gameplay.Services
{
    public interface IBattleProvider
    {
        Battle CurrentBattle { get; set; }
    }
}
