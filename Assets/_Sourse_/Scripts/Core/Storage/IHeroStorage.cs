using System.Collections.Generic;
using Sourse.Scripts.Characters;

namespace Sourse.Scripts.Core.Storage
{
    public interface IHeroStorage
    {
        IReadOnlyList<HeroSetting> GetHeroes();
        void SetCurrentHero(HeroSetting heroSetting);

        HeroSetting GetCurrentHero();
    }
}