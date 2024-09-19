using Reflex.Attributes;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Inject] private StateMashineUI _uI;

    public void OpenWindow()
    {
        _uI.EnterIn<LifeRewardUIState>();
    }
}
