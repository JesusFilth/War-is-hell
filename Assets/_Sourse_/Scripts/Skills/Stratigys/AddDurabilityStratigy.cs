using System;

public class AddDurabilityStratigy : ISkillStratigy
{
    public void Execute(PlayerAbilitys abilitys, float value)
    {
        abilitys.Stats.AddDurability(value);
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        throw new NotImplementedException();
    }
}