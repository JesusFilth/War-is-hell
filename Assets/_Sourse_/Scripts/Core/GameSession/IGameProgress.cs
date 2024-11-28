using Characters.Player;

namespace Core.GameSession
{
    public interface IGameProgress
    {
        PlayerProgress GetPlayerProgress();
    }
}
