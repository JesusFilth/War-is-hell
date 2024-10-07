public class SkillExecuteStratigy
{
    public void Execute(PlayerAbilitys abilitys, StatParameterModel statModel)
    {
        abilitys.AddModifier(statModel);
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        abilitys.SkillsStorage.AddSkill(skill);
    }
}
