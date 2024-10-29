using IJunior.TypedScenes;

public class LoadMainMenuState : IGameState
{
    public void Execute()
    {
        MainMenu.Load();
    }
}