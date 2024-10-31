using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Pig Punch/Level/LevelSettings", order = 2)]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private float _upExpForLevelPercent = 10f;

    public float UpExpForLevelPercent => _upExpForLevelPercent;
}
