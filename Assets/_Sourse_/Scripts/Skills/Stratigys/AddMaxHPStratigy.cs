using System;

public class AddMaxHPStratigy : ISkillStratigy
{
    public void Execute(PlayerAbilitys abilitys, float value)
    {
        abilitys.Stats.AddMaxHeal(value);
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        throw new NotImplementedException();
    }
}
