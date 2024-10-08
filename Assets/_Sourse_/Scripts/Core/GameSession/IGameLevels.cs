using UnityEngine;

public interface IGameLevels
{
    void StartGame();

    void LoadNextLevel(Skill skill = null);

    void InitPlayer(Vector3 position);
}