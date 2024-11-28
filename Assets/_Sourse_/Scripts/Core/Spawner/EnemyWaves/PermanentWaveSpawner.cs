using System.Collections;
using UnityEngine;

namespace Core.Spawner.EnemyWaves
{
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
}