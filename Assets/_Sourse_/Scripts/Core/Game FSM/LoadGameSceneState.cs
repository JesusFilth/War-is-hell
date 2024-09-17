using System;

public class LoadGameSceneState : IGameState
{
    private IGameLevels _gameLevels;

    public LoadGameSceneState(IGameLevels gameLevels)
    {
        if(gameLevels == null)
            throw new ArgumentNullException(nameof(gameLevels));

        _gameLevels = gameLevels;
    }

    public void Execute()
    {
        _gameLevels.LoadGameLevel();
    }
}
