using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PermanentWaveSpawner : WaveSpawner
{
    protected override IEnumerator Execute()
    {
        while(CountEnemysOnBattlefield != Count)
        {
            if (HasEnemys == false)
                break;

            Create();
            yield return new WaitForSeconds(DelaySpawn);
        }

        Executing = null;
    }
}