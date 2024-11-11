using IJunior.TypedScenes;

public class LoadMainMenuState : IGameState
{
    public void Execute()
    {
        GameMainMenu.Load();
    }
}