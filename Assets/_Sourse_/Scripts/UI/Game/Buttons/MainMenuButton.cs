using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MainMenuButton : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;
    [Inject] private UserStorage _userStorage;
    [Inject] private IGameProgress _progress;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnClick);

    private void OnClick()
    {
        _userStorage.AddGold(_progress.GetPlayerProgress().Gold);
        _userStorage.AddScore(_progress.GetPlayerProgress().Score);

        _stateMashine.EnterIn<LoadMainMenuState>();
    }
}
