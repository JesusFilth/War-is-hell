using System;

internal class AddFullHPStratigy : ISkillStratigy
{
    public void Execute(PlayerAbilitys abilitys, float value)
    {
        abilitys.Stats.AddFullHeal();
    }

    public void Execute(PlayerAbilitys abilitys, SkillActive skill)
    {
        throw new NotImplementedException();
    }
}
