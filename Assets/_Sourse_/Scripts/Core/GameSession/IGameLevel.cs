using UnityEngine;

public interface IGameLevel
{
    void StartGame(IGamePlayer player, GameMode mode);

    void LoadNextLevel(Skill skill = null);

    int GetCurrentLevelNumber();
}