using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameModeSurvivalButton : MonoBehaviour
{
    [SerializeField] private GameObject _titleObj;

    private Button _button;

    [Inject] private CurrentGameMode _currentGameMode;
    [Inject] private UserStorage _userStorage;

    private void Awake()
    {
        _button = GetComponent<Button>();

        if (_userStorage.IsOpenSurvivolMode() == false)
        {
            _button.interactable = false;
            _titleObj.SetActive(true);
        }
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
        _currentGameMode.ToSurvivolMode();
    }
}