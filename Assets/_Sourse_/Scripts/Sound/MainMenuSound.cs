using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    private void Start()
    {
        BackgroundSound.Instance.PlayMainMenuSound();
    }
}