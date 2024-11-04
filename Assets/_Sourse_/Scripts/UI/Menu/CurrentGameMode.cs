using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class CurrentGameMode : MonoBehaviour
{
    [SerializeField] private TMP_Text _modeText;

    [Inject] private UserStorage _userStorage;

    public GameMode CurrentMode { get; private set; } = GameMode.Company;

    private void Awake()
    {
        Initialize();
    }

    public void ToSurvivolMode()
    {
        CurrentMode = GameMode.Survival;
    }

    public void ToCompanyMode()
    {
        CurrentMode = GameMode.Company;
    }

    private void UpdateTextMode()
    {
        _modeText.text = CurrentMode.ToString();
    }

    private void Initialize()
    {
        if(_userStorage.IsOpenSurvivolMode())
            CurrentMode = GameMode.Survival;
    }
}