using GameCreator.Runtime.Stats;
using Sourse.Scripts.Characters.Player;
using UnityEngine;

namespace Sourse.Scripts.Skills
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Attribute", order = 2)]
    public class SkillAttribute : SkillPassive
    {
        [SerializeField] private Attribute _attribute;

        public override void ExecuteStratigy(PlayerAbilities abilitys)
        {
            if (Stratigy == null)
                throw new System.ArgumentNullException(nameof(Stratigy));

            Stratigy.Execute(abilitys, new AttributeParameterModel(_attribute, Value));
            UpSkill();
        }
    }
}
