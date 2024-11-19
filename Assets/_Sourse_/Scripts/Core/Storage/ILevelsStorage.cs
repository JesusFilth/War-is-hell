using Sourse.Scripts.Enviroment.Levels;

namespace Sourse.Scripts.Core.Storage
{
    public interface ILevelsStorage
    {
        LevelLocation GetLevelLocation(int index);

        LevelLocation GetRandomLevelLocation();

        int GetLastLevelNumber();
    }
}
