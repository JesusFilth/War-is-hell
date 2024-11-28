using UnityEngine;

namespace Core.GameSession
{
    public interface IGamePlayer
    {
        void SetPosition(Vector3 position);

        void AddExperience(float exp);

        void Resurrect();
    }
}