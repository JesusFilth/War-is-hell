using Reflex.Attributes;
using UnityEngine;

public class GameSession : MonoBehaviour,
    IGameLevel
{
    private LevelLocation _currentLevel;
    private int _currentNumberLevel = 1;
    private IGamePlayer _player;

    [Inject] private ILevelsStorage _levelsStorage;

    public void StartGame(IGamePlayer player)
    {
        _player = player;

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
