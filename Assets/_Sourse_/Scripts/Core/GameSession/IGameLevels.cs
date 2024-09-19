using UnityEngine;

public interface IGameLevels
{
    void LoadGameLevel(Skill skill = null);

    void DestroyPlayer();

    void InitPlayer(Vector3 position);
}