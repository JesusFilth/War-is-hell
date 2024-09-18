using System;
using IJunior.TypedScenes;

public class LoadMainMenuState : IGameState
{
    private readonly IGameLevels _gameLevels;//?

    public LoadMainMenuState(IGameLevels gameLevels)
    {
        if (gameLevels == null)
            throw new ArgumentNullException(nameof(gameLevels));

        _gameLevels = gameLevels;
    }

    public void Execute()
    {
        _gameLevels.DestroyPlayer();
        Menu_Jes.Load();
    }
}