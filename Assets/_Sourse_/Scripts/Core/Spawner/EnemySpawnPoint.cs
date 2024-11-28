using Characters;

namespace Core.Spawner
{
    public class EnemySpawnPoint : SpawnPoint
    {
        private Enemy _currentEnemy;

        private void OnDisable()
        {
            if (_currentEnemy != null)
                _currentEnemy.Died -= OnDieEnemy;
        }

        public void SetEnemy(Enemy enemy)
        {
            ToBusy();
            _currentEnemy = enemy;
            _currentEnemy.Died += OnDieEnemy;
        }

        private void OnDieEnemy(Enemy enemy)
        {
            ToFree();
            enemy.Died -= OnDieEnemy;

            _currentEnemy = null;
        }
    }
}