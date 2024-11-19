using System;
using UnityEngine;

namespace Sourse.Scripts.Skills.SkillEffects
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
