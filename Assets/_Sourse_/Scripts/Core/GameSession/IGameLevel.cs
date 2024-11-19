﻿using Sourse.Scripts.Skills;

namespace Sourse.Scripts.Core.GameSession
{
    public interface IGameLevel
    {
        void StartGame(IGamePlayer player, GameMode mode);

        void LoadNextLevel(Skill skill = null);

        int GetCurrentLevelNumber();

        GameMode GetCurrentMode();

        bool IsCompanyCompleted();
    }
}