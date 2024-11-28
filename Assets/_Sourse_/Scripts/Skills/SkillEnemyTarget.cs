using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/EnemyTarget", order = 2)]
    public class SkillEnemyTarget : SkillActive
    {
        [Space]
        [Header("Skill Enemy Target settings")]
        [SerializeField] private int _enemyCount = 1;
        [SerializeField] private int _maxEnemyCount;
        [SerializeField] private int _needLevelForCountUp = 3;

        public int EnemyCount => _enemyCount;

        public override void UpSkill()
        {
            if (Level % _needLevelForCountUp == 0)
                _enemyCount = Mathf.Clamp(_enemyCount + 1, 0, _maxEnemyCount);

            base.UpSkill();
        }

        protected override void CheckMaxLevel()
        {
            if (Cooldawn == MinCooldawn && Chance == MaxChance && _enemyCount == _maxEnemyCount)
                IsMaxLevel = true;
        }
    }
}