using UnityEngine;

public class GameLevelMainSound : MonoBehaviour
{
    private void Start()
    {
        BackgroundSound.Instance.PlayGameLevelSound();
    }
}