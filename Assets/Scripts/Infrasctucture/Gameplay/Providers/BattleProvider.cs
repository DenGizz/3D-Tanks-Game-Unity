using Assets.Scripts.Domain;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public class BattleProvider : IBattleProvider
    {
        public Battle CurrentBattle { get; set; }
    }
}
