using System.Collections.Generic;

public interface IHeroStorage
{
    IReadOnlyList<HeroSetting> GetHeroes();
    void SetCurrentHero(HeroSetting heroSetting);

    HeroSetting GetCurrentHero();
}