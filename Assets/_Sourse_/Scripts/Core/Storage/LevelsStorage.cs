using System;
using System.Collections.Generic;
using Characters;
using Enviroment.Levels;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Storage
{
    public class LevelsStorage : MonoBehaviour,
        ILevelsStorage,
        IGameLevelSettings,
        IHeroStorage,
        ILoadScreens
    {
        [SerializeField] private LevelLocation[] _levels;
        [SerializeField] private List<HeroSetting> _heroes;
        [SerializeField] private Sprite[] _loadScreens;
        [SerializeField] private LevelSettings _levelSettings;

        private HeroSetting _currentHero;

        public LevelLocation GetLevelLocation(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == _levels.Length)
                index = 0;

            return _levels[index];
        }

        public LevelLocation GetRandomLevelLocation()
        {
            int randomIndex = Random.Range(0, _levels.Length);
            return _levels[randomIndex];
        }

        public void SetCurrentHero(HeroSetting heroSetting)
        {
            _currentHero = heroSetting;
        }

        public HeroSetting GetCurrentHero() 
        {
            if (_currentHero == null)
                _currentHero = _heroes[0];

            return _currentHero;
        }

        public IReadOnlyList<HeroSetting> GetHeroes() => _heroes;

        public Sprite GetRandomScreen()
        {
            if (_loadScreens == null || _loadScreens.Length == 0)
                throw new ArgumentNullException(nameof(_loadScreens));

            return _loadScreens[Random.Range(0, _loadScreens.Length)];
        }

        public float GetUpLevelPowerPercent() => _levelSettings.UpLevelPowerPercent;

        public int GetLastLevelNumber()
        {
            return _levels.Length;
        }

        public float GetExperianceForSurvivol() => _levelSettings.ExperianceForSurvivol;
    }
}