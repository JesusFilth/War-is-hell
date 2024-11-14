using System;
using GamePush;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillItemUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _iconBackground;
    [SerializeField] private Button _button;
    [Space]
    [SerializeField] private Color32 _active = Color.red;
    [SerializeField] private Color32 _passive = Color.blue;

    private Skill _currentSkill;

    [Inject] private IPlayerAbilities _playerAbilities;
    [Inject] private StateMashineUI _stateMashineUI;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChoseSkill);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChoseSkill);
    }

    public void Init(Skill skill)
    {
        _currentSkill = skill;
        UpdateData();
    }

    private void UpdateData()
    {
        _currentSkill.ChangeLanguage(GP_Language.Current());

        if(_currentSkill.Icon != null)
            _icon.sprite = _currentSkill.Icon;

        _level.text = (_currentSkill.LevelNumber + 1).ToString();
        _description.text = _currentSkill.Description;

        ChangeColor();
    }

    private void ChangeColor()
    {
        if (_currentSkill is SkillActive active)
            _iconBackground.color = _active;
        else if (_currentSkill is SkillPassive passive)
            _iconBackground.color = _passive;
    }

    private void ChoseSkill()
    {
        if (_currentSkill == null)
            throw new ArgumentNullException(nameof(_currentSkill));

        _currentSkill.ExecuteStratigy(_playerAbilities.GetAbilities());
        _stateMashineUI.EnterIn<GameLevelUIState>();
    }
}
