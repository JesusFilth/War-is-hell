using System.Collections;
using UnityEngine;

public class SquadWaveSpawner : WaveSpawner
{
    protected override IEnumerator Execute()
    {
        if(CountEnemysOnBattlefield == 0)
        {
            for (int i = 0; i < Count; i++)
            {
                Create();
                yield return new WaitForSeconds(DelaySpawn);
            }
        }

        Executing = null;
    }
}