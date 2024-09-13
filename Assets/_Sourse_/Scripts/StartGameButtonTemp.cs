using Reflex.Attributes;
using UnityEngine;

public class StartGameButtonTemp : MonoBehaviour
{
    [Inject] private LevelStorage _levelStorage;

    public void StartGame()
    {
        _levelStorage.LoadStartGameLevel();
    }
}
