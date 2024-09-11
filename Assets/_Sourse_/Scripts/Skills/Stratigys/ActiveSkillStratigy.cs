using System;

public class ActiveSkillStratigy : ISkillStratigy
{
    public void Execute(PlayerAbilitys abilitys, float value)
    {
        throw new NotImplementedException();
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        abilitys.SkillsStorage.AddSkill(skill);
    }
}