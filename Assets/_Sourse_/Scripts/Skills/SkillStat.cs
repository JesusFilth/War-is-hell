using System;
using GameCreator.Runtime.Stats;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Stat", order = 2)]
public class SkillStat : SkillPassive
{
    [SerializeField] private ModifierType _type = ModifierType.Constant;
    [SerializeField] private Stat _stat;

    public override void ExecuteStratigy(PlayerAbilitys abilitys)
    {
        if (Stratigy == null)
            throw new ArgumentNullException(nameof(Stratigy));

        Stratigy.Execute(abilitys, new StatParameterModel(_stat, _type, Value));
        UpSkill();
    }
}
