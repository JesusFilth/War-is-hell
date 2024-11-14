using Reflex.Attributes;
using UnityEngine;

public class GameModeButton : ButtonView
{
    [SerializeField] private GameMode _mode;
    [SerializeField] private GameObject _focus;

    [Inject] private CurrentGameMode _currentGameMode;
    [Inject] private UserStorage _userStorage;

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentGameMode.ModeChanged += UpdateFrame;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _currentGameMode.ModeChanged -= UpdateFrame;
    }

    private void Start()
    {
        UpdateFrame(_currentGameMode.CurrentMode);
    }

    public void On()
    {
        _focus.SetActive(true);
    }

    protected override void OnClick()
    {
        if (_userStorage.IsOpenSurvivolMode() == false)
            return;

        _currentGameMode.SetGameMode(_mode);
    }

    private void UpdateFrame(GameMode mode)
    {
        bool isActive = mode == _mode ? true : false;

        _focus.SetActive(isActive);
    }
}
