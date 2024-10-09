using System.Collections;
using UnityEngine;

public class SquadWaveSpawner : WaveSpawner
{
    [SerializeField] private int _count;

    protected override IEnumerator Execute()
    {
        if(CountEnemysOnBattlefield == 0)
        {
            for (int i = 0; i < _count; i++)
            {
                Create();
                yield return new WaitForSeconds(DelaySpawn);
            }
        }

        Executing = null;
    }
}