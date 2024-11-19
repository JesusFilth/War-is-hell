using Sourse.Scripts.Characters.Player;

namespace Sourse.Scripts.Skills
{
    public class SkillExecuteStratigy
    {
        public void Execute(PlayerAbilitys abilitys, StatParameterModel statModel)
        {
            abilitys.AddModifier(statModel);
        }

        public void Execute(PlayerAbilitys abilitys, AttributeParameterModel attributeModel)
        {
            abilitys.AddModifier(attributeModel);
        }

        public void Execute(PlayerAbilitys abilitys, SkillActive skill)
        {
            abilitys.SkillsStorage.AddSkill(skill);
        }
    }
}
