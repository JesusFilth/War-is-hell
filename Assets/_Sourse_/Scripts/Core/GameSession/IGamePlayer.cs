using UnityEngine;

namespace Sourse.Scripts.Core.GameSession
{
    public interface IGamePlayer
    {
        Transform GetPlayerPosition();

        void SetPosition(Vector3 position);

        void AddExpirience(float exp);

        void Resurrect();
    }
}