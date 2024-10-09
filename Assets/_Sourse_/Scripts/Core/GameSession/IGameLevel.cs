using UnityEngine;

public interface IGameLevel
{
    void StartGame(IGamePlayer player);

    void LoadNextLevel(Skill skill = null);

    int GetCurrentLevelNumber();
}