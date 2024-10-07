using GameCreator.Runtime.Stats;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Attribute", order = 2)]
public class SkillAttribute : SkillPassive
{
    [SerializeField] private Attribute _attribute;

    public override void ExecuteStratigy(PlayerAbilitys abilitys)
    {
        if (Stratigy == null)
            throw new System.ArgumentNullException(nameof(Stratigy));

        Stratigy.Execute(abilitys, new AttributeParameterModel(_attribute, Value));
        UpSkill();
    }
}
