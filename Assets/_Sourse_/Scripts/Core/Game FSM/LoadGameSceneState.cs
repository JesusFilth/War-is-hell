using IJunior.TypedScenes;
using UnityEngine;

public class LoadGameSceneState : IGameState
{
    public void Execute()
    {
        Debug.Log("Changed? - Game.Load(null)");
        GameLevel.Load(null);
    }
}
