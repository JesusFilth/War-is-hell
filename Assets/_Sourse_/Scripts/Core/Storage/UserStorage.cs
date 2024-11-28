using System;
using GamePush;
using UnityEngine;

namespace Core.Storage
{
    public class UserStorage
    {
        private const string GoldKey = "gold";
        private const string OpenSurvivalKey = "isopensurvival";
        private const string HeroesKey = "heroes";

        private const string UserKey = "User";

        public event Action<int> GoldChanged;
        public int UserGold => GP_Player.GetInt(GoldKey);

        public bool HasHero(string id)
        {
            const char HeroesSplit = ';';
            const char HeroInfoSplit = '-';
            const int ValueIndex = 1;

            string heroes = string.Empty;

#if UNITY_WEBGL && !UNITY_EDITOR
        heroes = GP_Player.GetString(HeroesKey);
#else
            heroes = PlayerPrefs.GetString(UserKey);
#endif

            string[] heroesInfo = heroes.Split(HeroesSplit);

            int heroIndex = int.Parse(id);

            string[] hero = heroesInfo[heroIndex].Split(HeroInfoSplit);

            if (hero[ValueIndex] == "true")
                return true;

            return false;
        }

        public void AddGold(int value)
        {
            GP_Player.Add(GoldKey,value);
            GoldChanged?.Invoke(GP_Player.GetInt(GoldKey));

            Save();
        }

        public void AddHero(string id, int price)
        {
            const char HeroesSplit = ';';
            const char HeroInfoSplit = '-';

            string heroes = string.Empty;

#if UNITY_WEBGL && !UNITY_EDITOR
        heroes = GP_Player.GetString(HeroesKey);
#else
            heroes = PlayerPrefs.GetString(UserKey);
#endif

            string[] heroesInfo = heroes.Split(HeroesSplit);

            int heroIndex = int.Parse(id);

            heroesInfo[heroIndex] = $"{id}{HeroInfoSplit}true";

            string newInfo = string.Empty;

            foreach(string hero in heroesInfo)
            {
                newInfo += $"{hero};";
            }

            newInfo.Remove(newInfo.Length - 1);

            GP_Player.Add(GoldKey, price);
            GP_Player.Set(HeroesKey, newInfo);

            GoldChanged?.Invoke(GP_Player.GetInt(GoldKey));
            Save();
        }

        public void AddScore(int score)
        {
            if (GP_Player.GetScore() < score)
                GP_Player.SetScore(score);

            Save();
        }

        public void UpdateGold()
        {
            GoldChanged.Invoke(GP_Player.GetInt(GoldKey));
        }

        public void OpenSurvivalMode()
        {
            GP_Player.SetFlag(OpenSurvivalKey, true);
            Save();
        }

        public bool IsOpenSurvivolMode()
        {
            return GP_Player.GetBool(OpenSurvivalKey);
        }

        private void Save()
        {
            GP_Player.Sync();
        }
    }
}