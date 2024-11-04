﻿public interface ILevelsStorage
{
    LevelLocation GetLevelLocation(int index);

    LevelLocation GetRandomLevelLocation();

    int GetLastLevelNumber();
}
