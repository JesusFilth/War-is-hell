using System;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public event Action<SkillEffect> Destroed;

    private void OnDestroy()
    {
        Destroed?.Invoke(this);
    }
}
