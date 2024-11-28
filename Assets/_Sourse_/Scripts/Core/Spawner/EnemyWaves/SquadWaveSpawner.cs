using System.Collections;
using UnityEngine;

namespace Core.Spawner.EnemyWaves
{
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
}