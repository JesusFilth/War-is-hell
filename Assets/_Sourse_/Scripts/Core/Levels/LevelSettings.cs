using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Pig Punch/Level/LevelSettings", order = 2)]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private float _upEnemyStatForLevel = 1;
    [SerializeField] private float _upExeptionPercentForLevel = 10;
    [Space]
    [SerializeField] private int _minWaveSize = 4;
    [SerializeField] private int _maxWaveSize = 10;

    [SerializeField] private int _minSquadEnemy = 2;
    [SerializeField] private int _maxSquadEnemy = 5;

    [SerializeField] private int _minPermonentEnemy = 2;
    [SerializeField] private int _maxPermonentEnemy = 5;

    public float UpEnemyStatForLevel => _upEnemyStatForLevel;
    public float UpExeptionPercentForLevel => _upExeptionPercentForLevel;
    public int MinWaveSize => _minWaveSize;
    public int MaxWaveSize => _maxWaveSize;
    public int MinSquadEnemy => _minSquadEnemy;
    public int MaxSquadEnemy => _maxSquadEnemy;
    public int MinPermonentEnemy => _minPermonentEnemy;
    public int MaxPermonentEnemy => _maxPermonentEnemy;
}
