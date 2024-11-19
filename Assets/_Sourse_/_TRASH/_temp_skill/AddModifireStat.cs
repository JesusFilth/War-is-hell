using System;
using Sourse.Scripts.Characters.Player;
using Sourse.Scripts.Skills;

public class AddModifireStat : ISkillStratigy
{
    public void Execute(PlayerAbilitys abilitys, StatParameterModel statModel)
    {
        abilitys.AddModifier(statModel);
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        throw new NotImplementedException();
    }
}
