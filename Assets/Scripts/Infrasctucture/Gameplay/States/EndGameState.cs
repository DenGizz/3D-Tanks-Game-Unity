using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Infrasctucture.Gameplay.States
{
    public class EndGameState : IState
    {
        public EndGameState(StateMachine s)
        {
        }

        public void Enter()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }

        public void Exit()
        {
        }
    }
}