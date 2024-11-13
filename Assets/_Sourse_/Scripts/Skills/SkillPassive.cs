using System;
using UnityEngine;

public abstract class SkillPassive : Skill
{
    [SerializeField] protected float Value;
    [SerializeField] protected float UpValue = 5;
    [SerializeField] protected float MaxValue = 10;

    public override void ExecuteStratigy(PlayerAbilitys abilitys)
    {
        throw new NotImplementedException();
    }

    public override string GetDescription()
    {
        return $"+ {Value + Level} {Name}";
    }

    public override void UpSkill()
    {
        Level++;
        Value += UpValue;

        CheckMaxLevel();
    }

    protected override void CheckMaxLevel()
    {
        if(Value == MaxValue)
            IsMaxLevel = true;
    }
}