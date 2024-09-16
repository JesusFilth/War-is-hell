using System;

public class LoadGameSceneState : IGameState
{
    private GameLevelStorage _gameLevelStorage;

    public LoadGameSceneState(GameLevelStorage gameLevelStorage)
    {
        if(gameLevelStorage == null)
            throw new ArgumentNullException(nameof(gameLevelStorage));

        _gameLevelStorage = gameLevelStorage;
    }

    public void Execute()
    {
        _gameLevelStorage.LoadGameLevel();
    }
}
