using Reflex.Attributes;
using UnityEngine;

public class OnMeinMenuPlayerDestroy : MonoBehaviour
{
    [Inject] private IGameLevels _gameLevels;

    private void Awake()
    {
        _gameLevels.DestroyPlayer();
    }
}
