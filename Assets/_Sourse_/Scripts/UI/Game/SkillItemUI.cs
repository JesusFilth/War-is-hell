using System;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillItemUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Button _button;

    private Skill _currentSkill;

    [Inject] private LevelStorage _levelStorage;
    [Inject] private SkillsConteinerUI _skillsConteinerUI;

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
        if(_currentSkill.Icon != null)
            _icon.sprite = _currentSkill.Icon;

        _name.text = _currentSkill.Name;
        _level.text = _currentSkill.Level.ToString();
    }

    private void ChoseSkill()
    {
        if (_currentSkill == null)
            throw new ArgumentNullException(nameof(_currentSkill));

        _currentSkill.ExecuteStratigy(_levelStorage.Player.Abilitys);
        _skillsConteinerUI.Hide();
    }
}
