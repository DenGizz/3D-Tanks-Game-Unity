namespace Assets.Scripts.Features.InputSources
{
    public interface IInputSource
    {
        float MovementInputValue { get; }
        float TurnInputValue { get; }

        bool GetFireButtonDown { get; }
        bool GetFireButtonUp { get; }
        bool GetFireButton { get; }
    }
}
