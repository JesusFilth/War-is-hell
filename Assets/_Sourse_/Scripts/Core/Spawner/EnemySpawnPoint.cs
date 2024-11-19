using Sourse.Scripts.Characters;

namespace Sourse.Scripts.Core.Spawner
{
    public class EnemySpawnPoint : SpawnPoint
    {
        private Enemy _currentEnemy;

        private void OnDisable()
        {
            if (_currentEnemy != null)
                _currentEnemy.Died -= DieEnemy;
        }

        public void SetEnemy(Enemy enemy)
        {
            ToBusy();
            _currentEnemy = enemy;
            _currentEnemy.Died += DieEnemy;
        }

        private void DieEnemy(Enemy enemy)
        {
            ToFree();
            enemy.Died -= DieEnemy;

            _currentEnemy = null;
        }
    }
}