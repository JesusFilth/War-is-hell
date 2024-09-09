using UnityEngine;

public class SquadWaveSpawner : WaveSpawner
{
    [SerializeField] private int _count;

    protected override void Execute()
    {
        if(CountEnemysOnBattlefield == 0)
        {
            for (int i = 0; i < _count; i++)
            {
                Create();
            }
        }
    }
}