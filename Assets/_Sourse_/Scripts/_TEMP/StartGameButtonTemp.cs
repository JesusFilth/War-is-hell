using Reflex.Attributes;
using UnityEngine;

public class StartGameButtonTemp : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;

    public void StartGame()
    {
        _stateMashine.EnterIn<LoadGameSceneState>();
    }
}