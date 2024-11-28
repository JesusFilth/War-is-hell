using GamePush;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class PlayerSettingsView : MonoBehaviour
    {
        private const string SectetKey = "secretCode"; 

        [SerializeField] private GameObject _mainUi;

        [SerializeField] private Button _close;
        [SerializeField] private Button _save;
        [SerializeField] private Button _copy;

        [SerializeField] private TMP_InputField _name;
        [SerializeField] private TMP_InputField _secretKey;

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            _close.onClick.AddListener(OnClose);
            _save.onClick.AddListener(OnSave);
            _copy.onClick.AddListener(OnCopy);
        }

        private void OnDisable()
        {
            _close.onClick.RemoveListener(OnClose);
            _save.onClick.RemoveListener(OnSave);
            _copy.onClick.RemoveListener(OnCopy);
        }

        private void Initialize()
        {
            string name = GP_Player.GetName();

            if (string.IsNullOrEmpty(name) == false)
                _name.text = name;

            _secretKey.text = GP_Player.GetString(SectetKey);
        }

        private void OnSave()
        {
            if (_name.text == string.Empty)
            {
                OnClose();
                return;
            }

            if (_name.text == GP_Player.GetName())
            {
                OnClose();
                return;
            }

            GP_Player.SetName(_name.text);
            GP_Player.Sync();

            OnClose();
        }

        private void OnClose()
        {
            _mainUi.SetActive(true);
            gameObject.SetActive(false);
        }

        private void OnCopy()
        {
            GUIUtility.systemCopyBuffer = _secretKey.text;
        }
    }
}
