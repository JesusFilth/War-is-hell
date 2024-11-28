using Characters.Player;

namespace Skills
{
    public class SkillExecuteStratigy
    {
        public void Execute(PlayerAbilities abilitys, StatParameterModel statModel)
        {
            abilitys.AddModifier(statModel);
        }

        public void Execute(PlayerAbilities abilitys, AttributeParameterModel attributeModel)
        {
            abilitys.AddModifier(attributeModel);
        }

        public void Execute(PlayerAbilities abilitys, SkillActive skill)
        {
            abilitys.SkillsStorage.AddSkill(skill);
        }
    }
}
