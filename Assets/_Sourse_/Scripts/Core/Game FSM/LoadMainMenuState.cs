using System;
using IJunior.TypedScenes;

public class LoadMainMenuState : IGameState
{
    public void Execute()
    {
        Menu_Jes.Load();
    }
}