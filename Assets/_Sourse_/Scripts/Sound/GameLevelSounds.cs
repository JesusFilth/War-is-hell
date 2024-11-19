using UnityEngine;

namespace Sourse.Scripts.Sound
{
    public class GameLevelSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [Space]
        [SerializeField] private AudioClip _gold;

        public void PlayGold()
        {
            _audioSource.clip = _gold;
            _audioSource.Play();
        }
    }
}
