using IJunior.TypedScenes;
using UnityEngine;

public class LoadGameSceneState : IGameState<GameMode>
{
    public GameMode _gameMode;

    public void Execute()
    {
        GameLevel.Load(_gameMode);
    }

    public void SetParam(GameMode mode)
    {
        _gameMode = mode;
    }
}
