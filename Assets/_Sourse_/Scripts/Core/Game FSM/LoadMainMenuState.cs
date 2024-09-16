using System;
using IJunior.TypedScenes;

public class LoadMainMenuState : IGameState
{
    private readonly GameLevelStorage _gameLevelStorage; 

    public LoadMainMenuState(GameLevelStorage gameLevelStorage)
    {
        if (gameLevelStorage == null)
            throw new ArgumentNullException(nameof(gameLevelStorage));

        _gameLevelStorage = gameLevelStorage;
    }

    public void Execute()
    {
        _gameLevelStorage.DestroyPlayer();
        Menu_Jes.Load();
    }
}
