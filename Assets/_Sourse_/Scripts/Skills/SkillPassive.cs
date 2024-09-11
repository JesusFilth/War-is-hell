using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Passive", order = 2)]
public class SkillPassive : Skill
{
    [SerializeField] private float _value;
    [SerializeField] private PassiveSkillOperationType _operation;

    private void Awake()
    {
        Initialize();
    }

    public override void ExecuteStratigy(PlayerAbilitys abilitys)
    {
        if (Stratigy == null)
            throw new ArgumentNullException(nameof(Stratigy));

        Stratigy.Execute(abilitys, _value + Level);
        Level++;
    }

    public override string GetDescription()
    {
        return $"+ {_value + Level} {Name}";
    }

    private void Initialize()
    {
        PassiveSkillFactory skillFactory = new PassiveSkillFactory();
        Stratigy = skillFactory.GetStratigy(_operation);
    }
}
