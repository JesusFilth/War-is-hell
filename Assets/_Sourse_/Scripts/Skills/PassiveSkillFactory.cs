public class PassiveSkillFactory
{
    public ISkillStratigy GetStratigy(PassiveSkillOperationType type)
    {
        switch (type)
        {
            case PassiveSkillOperationType.AddHP: return new AddHPStratigy();
            case PassiveSkillOperationType.AddMaxHP: return new AddMaxHPStratigy();
            case PassiveSkillOperationType.AddFullHP: return new AddFullHPStratigy();
            case PassiveSkillOperationType.AddDamage: return new AddDamageStratigy();
            case PassiveSkillOperationType.AddDurability: return new AddDurabilityStratigy();
                default: return null;
        }
    }
}
