public interface ISkillStratigy
{
    void Execute(PlayerAbilitys abilitys, StatParameterModel statModel);

    void Execute(PlayerAbilitys abilitys, SkillActive skill);
}
