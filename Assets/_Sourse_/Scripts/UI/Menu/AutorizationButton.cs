using UnityEngine;
using UnityEngine.UI;
using GamePush;

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
        GP_Player.OnLoginError += OnLoginError;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);

        GP_Player.OnLoginComplete -= OnLoginComplete;
        GP_Player.OnLoginError -= OnLoginError;
    }

    private void OnClick()
    {
        GP_Player.Login();
    }

    private void OnLoginComplete()
    {
        _button.gameObject.SetActive(false);
    }

    private void OnLoginError()
    {
        Debug.Log("LogoutError");
    }
}
