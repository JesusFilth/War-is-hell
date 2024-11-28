using System;
using UnityEngine;

namespace Skills.SkillEffects
{
    public class SkillEffect : MonoBehaviour
    {
        public event Action<SkillEffect> Destroed;

        private void OnDestroy()
        {
            Destroed?.Invoke(this);
        }
    }
}
