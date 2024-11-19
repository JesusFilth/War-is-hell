using System;
using Sourse.Scripts.Characters.Player;
using Sourse.Scripts.Skills;

public class ActiveSkillStratigy : ISkillStratigy
{
    public void Execute(PlayerAbilitys abilitys, StatParameterModel statModel)
    {
        throw new NotImplementedException();
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        abilitys.SkillsStorage.AddSkill(skill);
    }
}