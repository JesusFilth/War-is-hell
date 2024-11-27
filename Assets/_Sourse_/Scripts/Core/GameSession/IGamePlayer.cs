using UnityEngine;

namespace Sourse.Scripts.Core.GameSession
{
    public interface IGamePlayer
    {
        void SetPosition(Vector3 position);

        void AddExpirience(float exp);

        void Resurrect();
    }
}