using Reflex.Attributes;
using UnityEngine;

public class GameSession : MonoBehaviour,
    IGameLevel
{
    private LevelLocation _currentLevel;
    private GameMode _mode;
    private int _currentNumberLevel = 1;
    private IGamePlayer _player;

    [Inject] private ILevelsStorage _levelsStorage;

    public void StartGame(IGamePlayer player, GameMode mode)
    {
        _player = player;
        _mode = mode;

        _currentLevel = Instantiate(_levelsStorage.GetLevelLocation(_currentNumberLevel-1));
        _player.SetPosition(_currentLevel.PlayerStartPosition.position);
    }

    public void LoadNextLevel(Skill skill = null)
    {
        _currentNumberLevel++;

        if (_currentLevel != null)
            Destroy(_currentLevel.gameObject);

        _currentLevel = Instantiate(_levelsStorage.GetLevelLocation(_currentNumberLevel - 1));
        _player.SetPosition(_currentLevel.PlayerStartPosition.position);
        _currentLevel.SetPriseSkill(skill);
    }

    public int GetCurrentLevelNumber() => _currentNumberLevel;
}
