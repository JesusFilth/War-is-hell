using IJunior.TypedScenes;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevelStorage : MonoBehaviour
{
    [SerializeField] private LevelLocation[] _levels;
    [SerializeField] private Player _playerPrefab;

    public Player Player { get; private set; }

    public void LoadGameLevel()
    {
        int randomLevelIndex = Random.Range(0, _levels.Length);
        Game.Load(_levels[randomLevelIndex]);
    }

    public void InitPlayer(Vector3 position)
    {
        if(Player == null)
            Player = Instantiate(_playerPrefab);

        Player.SetPosition(position);
    }

    public void DestroyPlayer()
    {
        if(Player != null)
            Destroy(Player.gameObject);
    }
}