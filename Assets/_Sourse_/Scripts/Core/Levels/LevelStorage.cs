using IJunior.TypedScenes;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelStorage : MonoBehaviour
{
    [SerializeField] private LevelLocation[] _levels;
    [SerializeField] private Player _playerPrefab;

    public Player Player { get; private set; }

    public void ToNextRandomLevel()
    {
        int randomLevelIndex = Random.Range(0, _levels.Length);
        Game.Load(_levels[randomLevelIndex]);
    }

    public void LoadStartGameLevel()
    {
        Player = Instantiate(_playerPrefab);

        int randomLevelIndex = Random.Range(0, _levels.Length);
        Game.Load(_levels[randomLevelIndex]);
    }
}
