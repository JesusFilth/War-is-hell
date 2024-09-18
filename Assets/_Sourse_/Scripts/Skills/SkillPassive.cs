using GameCreator.Runtime.Stats;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Passive", order = 2)]
public class SkillPassive : Skill
{
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue = 10;
    [SerializeField] private ModifierType _type = ModifierType.Constant;
    [SerializeField] private Stat _stat;

    private void Awake()
    {
        Initialize();
    }

    public override void ExecuteStratigy(PlayerAbilitys abilitys)
    {
        if (Stratigy == null)
            throw new ArgumentNullException(nameof(Stratigy));

        Stratigy.Execute(abilitys, new StatParameterModel(_stat, _type, _value));
        UpSkill();
    }

    public override string GetDescription()
    {
        return $"+ {_value + Level} {Name}";
    }

    public override void UpSkill()
    {
        Level++;
        _value++;

        CheckMaxLevel();
    }

    protected override void CheckMaxLevel()
    {
        if(_value == _maxValue)
            IsMaxLevel = true;
    }

    private void Initialize()
    {
        Stratigy = new AddModifireStat();
    }
}