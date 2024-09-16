using Reflex.Attributes;
using UnityEngine;

public class StartGameButtonTemp : MonoBehaviour
{
    [Inject] private GameLevelStorage _levelStorage;

    public void StartGame()
    {
        _levelStorage.LoadGameLevel();
    }
}
