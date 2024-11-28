using IJunior.TypedScenes;

namespace Core.Game_FSM
{
    public class LoadMainMenuState : IGameState
    {
        public void Execute()
        {
            GameMainMenu.Load();
        }
    }
}