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
}