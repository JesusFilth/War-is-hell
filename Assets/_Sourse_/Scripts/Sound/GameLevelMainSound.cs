using UnityEngine;

namespace Sourse.Scripts.Sound
{
    public class GameLevelMainSound : MonoBehaviour
    {
        private void Start()
        {
            BackgroundSound.Instance.PlayGameLevelSound();
        }
    }
}