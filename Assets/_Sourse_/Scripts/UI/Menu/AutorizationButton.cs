using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AutorizationButton : MonoBehaviour
{
    [SerializeField] private LeaderboardAutorizationCheck _autorizationCheck;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
          PlayerAccount.Authorize();

        if(PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();
#endif
        _autorizationCheck.Check();
    }
}
