using System;
using UnityEngine.Scripting;

[Serializable]
public class UserModel
{
    [field: Preserve] public string Name;
    [field: Preserve] public int Gold;
}
