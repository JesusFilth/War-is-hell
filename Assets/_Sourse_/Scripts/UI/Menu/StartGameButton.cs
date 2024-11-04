using Reflex.Attributes;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;

    public void StartGame()
    {
        _stateMashine.EnterIn<LoadGameSceneState, GameMode>(GameMode.Company);
    }
}