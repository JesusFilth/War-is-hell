using UnityEngine;
using Random = UnityEngine.Random;

public class PermanentWaveSpawner : WaveSpawner
{
    [SerializeField] private int _maxEnemys = 3;

    protected override void Execute()
    {
        while(CountEnemysOnBattlefield != _maxEnemys)
        {
            if (HasEnemys == false)
                break;

            Create();
        }
    }

    protected override void UseLevelSettings()
    {
        base.UseLevelSettings();

        _maxEnemys = Random.Range(Settings.GetMinPermonentEnemy(), Settings.GetMaxPermonentEnemy());
    }
}