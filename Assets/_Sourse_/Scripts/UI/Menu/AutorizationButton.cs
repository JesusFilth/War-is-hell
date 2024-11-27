using GamePush;
using UnityEngine;
using UnityEngine.UI;

namespace Sourse.Scripts.UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class AutorizationButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();

            //if(GP_Player.IsLoggedIn())
            //    _button.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);

            GP_Player.OnLoginComplete += OnLoginComplete;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);

            GP_Player.OnLoginComplete -= OnLoginComplete;
        }

        private void OnClick()
        {
            GP_Player.Login();
        }

        private void OnLoginComplete()
        {
            _button.gameObject.SetActive(false);
        }
    }
}
