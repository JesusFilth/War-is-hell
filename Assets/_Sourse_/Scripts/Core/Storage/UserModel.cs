using System;
using UnityEngine.Scripting;

namespace Core.Storage
{
    [Serializable]
    public class UserModel
    {
        [field: Preserve] public string Name;
        [field: Preserve] public int Gold;
        [field: Preserve] public int Score;
        [field: Preserve] public string[] Heroes;
        [field: Preserve] public bool IsOpenSurvival;
    }
}
