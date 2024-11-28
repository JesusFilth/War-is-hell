using Skills.SkillEffects;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/PlayerTarget", order = 2)]
    public class SkillPlayerTarget : SkillActive
    {
        [Space]
        [Header("Skill Player Target settings")]
        [SerializeField] private int _effectCount = 1;
        [SerializeField] private int _maxCountEffect = 5;
        [SerializeField] private int _needLevelForCountUp = 3;

        private int _currentCount = 0;

        public bool IsFull => _effectCount == _currentCount;

        public void CreateEffect()
        {
            if (IsFull)
                return;

            SkillEffect effect = Instantiate(Effect);
            effect.Destroed += DestroyEffect;
            _currentCount++;
        }

        private void DestroyEffect(SkillEffect effect)
        {
            _currentCount--;
            effect.Destroed -= DestroyEffect;
        }

        public override void UpSkill()
        {
            if (Level % _needLevelForCountUp == 0)
                _effectCount = Mathf.Clamp(_effectCount + 1, 0, _maxCountEffect);

            base.UpSkill();
        }

        protected override void CheckMaxLevel()
        {
            if (Cooldawn == MinCooldawn && Chance == MaxChance && _effectCount == _maxCountEffect)
                IsMaxLevel = true;
        }
    }
}
