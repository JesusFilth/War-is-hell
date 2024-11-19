using UnityEngine;

namespace Sourse.Scripts.Enviroment.Levels
{
    [CreateAssetMenu(fileName = "LevelMap", menuName = "Pig Punch/Level/Level", order = 2)]
    public class LevelMap : MonoBehaviour//?
    {
        [SerializeField] private LevelLocation _map;
    }
}
