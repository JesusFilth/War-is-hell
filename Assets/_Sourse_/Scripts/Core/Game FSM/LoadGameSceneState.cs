using IJunior.TypedScenes;

public class LoadGameSceneState : IGameState<GameMode>
{
    private GameMode _gameMode;

    public void Execute()
    {
        GameLevel.Load(_gameMode);
    }

    public void SetParam(GameMode mode)
    {
        _gameMode = mode;
    }
}
