using GamePush;
using UnityEngine;

namespace Sourse.Scripts.Core
{
    public class FocusGame : MonoBehaviour
    {
        private bool _isLock;

        public static FocusGame Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void OnEnable()
        {
            Application.focusChanged += OnInBackgroundChangeApp;
        }

        private void OnDisable()
        {
            Application.focusChanged -= OnInBackgroundChangeApp;
        }

        public void Lock()
        {
            GP_Game.IsPaused();

            MuteAudio(true);
            PauseGame(true);

            _isLock = true;
        }

        public void Unlock()
        {
            GP_Game.GameReady();

            _isLock = false;

            MuteAudio(false);
            PauseGame(false);
        }

        private void MuteAudio(bool value)
        {
            if (_isLock)
                return;

            AudioListener.pause = value;
        }

        private void PauseGame(bool value)
        {
            if (_isLock)
                return;

            Time.timeScale = value ? 0 : 1;
        }

        private void OnInBackgroundChangeApp(bool value)
        {
            MuteAudio(!value);
            PauseGame(!value);
        }
    }
}