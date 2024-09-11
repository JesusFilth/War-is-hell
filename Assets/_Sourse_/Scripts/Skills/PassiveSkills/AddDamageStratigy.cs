using System;

public class AddDamageStratigy : ISkillStratigy
{
    public void Execute(PlayerAbilitys abilitys, float value)
    {
        abilitys.Stats.AddDamage(value);
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        throw new NotImplementedException();
    }
}
