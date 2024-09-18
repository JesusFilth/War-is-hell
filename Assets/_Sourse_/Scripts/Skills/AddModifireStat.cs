using System;
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
