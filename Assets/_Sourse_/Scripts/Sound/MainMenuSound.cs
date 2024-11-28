using UnityEngine;

namespace Sound
{
    public class MainMenuSound : MonoBehaviour
    {
        private void Start()
        {
            BackgroundSound.Instance.PlayMainMenuSound();
        }
    }
}