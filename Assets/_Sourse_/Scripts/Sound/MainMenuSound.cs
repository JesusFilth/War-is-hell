using UnityEngine;

namespace Sourse.Scripts.Sound
{
    public class MainMenuSound : MonoBehaviour
    {
        private void Start()
        {
            BackgroundSound.Instance.PlayMainMenuSound();
        }
    }
}