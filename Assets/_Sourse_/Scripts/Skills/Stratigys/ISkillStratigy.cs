public interface ISkillStratigy
{
    void Execute(PlayerAbilitys abilitys, float value);

    void Execute(PlayerAbilitys abilitys, SkillActive skill);
}
