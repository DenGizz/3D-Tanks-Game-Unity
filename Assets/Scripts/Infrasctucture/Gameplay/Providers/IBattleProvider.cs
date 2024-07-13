using Assets.Scripts.Domain;

namespace Assets.Scripts.Infrasctucture.Gameplay.Providers
{
    public interface IBattleProvider
    {
        Battle CurrentBattle { get; set; }
    }
}
