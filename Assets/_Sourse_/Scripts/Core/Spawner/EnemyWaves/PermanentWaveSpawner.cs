using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PermanentWaveSpawner : WaveSpawner
{
    [SerializeField] private int _maxEnemys = 3;

    protected override IEnumerator Execute()
    {
        while(CountEnemysOnBattlefield != _maxEnemys)
        {
            if (HasEnemys == false)
                break;

            Create();
            yield return new WaitForSeconds(DelaySpawn);
        }

        Executing = null;
    }
}