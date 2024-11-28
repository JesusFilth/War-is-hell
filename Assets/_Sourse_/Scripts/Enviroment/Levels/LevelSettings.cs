using UnityEngine;

namespace Enviroment.Levels
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Pig Punch/Level/LevelSettings", order = 2)]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private float _upLevelPowerPercent = 10f;
        [SerializeField] private float _experianceForSurvivol = 50f;

        public float UpLevelPowerPercent => _upLevelPowerPercent;
        public float ExperianceForSurvivol => _experianceForSurvivol;
    }
}
