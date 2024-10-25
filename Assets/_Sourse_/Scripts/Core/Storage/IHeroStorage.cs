using System.Collections.Generic;

public interface IHeroStorage
{
    IReadOnlyList<HeroSetting> GetHeroes();
}