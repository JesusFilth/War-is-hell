using Sourse.Scripts.Characters.Player;

namespace Sourse.Scripts.Core.GameSession
{
    public interface IGameProgress
    {
        PlayerProgress GetPlayerProgress();
    }
}
