using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Pig Punch/Level/LevelSettings", order = 2)]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private float _upLevelPowerPercent = 10f;

    public float UpLevelPowerPercent => _upLevelPowerPercent;
}
