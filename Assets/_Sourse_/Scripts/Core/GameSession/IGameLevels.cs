using UnityEngine;

public interface IGameLevels
{
    void LoadGameLevel();

    void DestroyPlayer();

    void InitPlayer(Vector3 position);
}