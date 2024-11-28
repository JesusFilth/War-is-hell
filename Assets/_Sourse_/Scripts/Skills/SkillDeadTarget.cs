using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/DeadTarget", order = 2)]
    public class SkillDeadTarget : SkillActive
    {
        [Space]
        [Header("Skill Dead Target settings")]
        [SerializeField] private int _deadCount = 1;
        [SerializeField] private int _maxDeadCount;
        [SerializeField] private int _upCountLevel = 3;

        public int DeadCount => _deadCount;

        public override void UpSkill()
        {
            if (Level % _upCountLevel == 0)
                _deadCount = Mathf.Clamp(_deadCount + 1, 0, _maxDeadCount);

            base.UpSkill();
        }

        protected override void CheckMaxLevel()
        {
            if (Cooldawn == MinCooldawn && Chance == MaxChance && _deadCount == _maxDeadCount)
                IsMaxLevel = true;
        }
    }
}
