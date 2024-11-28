using UnityEngine;

namespace Sourse.Scripts.Sound
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _mainMenu;
        [SerializeField] private AudioClip _gameLevel;

        public static BackgroundSound Instance { get; private set; }

        public bool IsPlaying => AudioListener.volume == 1;

        private void Awake()
        {
            transform.parent = null;

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void PlayMainMenuSound()
        {
            _audioSource.clip = _mainMenu;
            Play();
        }

        public void PlayGameLevelSound()
        {
            _audioSource.clip = _gameLevel;
            Play();
        }

        public void OnVolume()
        {
            AudioListener.volume = 1;
            Play();
        }

        public void OffVolume()
        {
            AudioListener.volume = 0;
            Stop();
        }

        private void Play() => _audioSource.Play();

        private void Stop() => _audioSource.Stop();
    }
}