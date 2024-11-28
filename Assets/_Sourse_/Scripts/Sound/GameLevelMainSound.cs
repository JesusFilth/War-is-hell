using UnityEngine;

namespace Sound
{
    public class GameLevelMainSound : MonoBehaviour
    {
        private void Start()
        {
            BackgroundSound.Instance.PlayGameLevelSound();
        }
    }
}