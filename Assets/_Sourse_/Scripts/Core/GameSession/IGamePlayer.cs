using UnityEngine;

public interface IGamePlayer
{
    Transform GetPlayerPosition();

    void AddExpirience(float exp);
}