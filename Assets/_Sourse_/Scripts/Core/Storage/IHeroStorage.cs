using System.Collections.Generic;
using Characters;

namespace Core.Storage
{
    public interface IHeroStorage
    {
        IReadOnlyList<HeroSetting> GetHeroes();
        void SetCurrentHero(HeroSetting heroSetting);

        HeroSetting GetCurrentHero();
    }
}