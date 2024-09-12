using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Curce", order = 2)]
public class SkillCurce : SkillActive
{
    [SerializeField] private int _enemyCount = 1;
    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private int _upCountLevel = 3;

    public int EnemyCount => _enemyCount;

    public override void UpSkill()
    {
        if (Level % _upCountLevel == 0)
            _enemyCount = Mathf.Clamp(_enemyCount+1, 0, _maxEnemyCount);

        base.UpSkill();
    }

    protected override void CheckMaxLevel()
    {
        if (Cooldawn == MinCooldawn && Chance == MaxChance && _enemyCount == _maxEnemyCount)
            IsMaxLevel = true;
    }
}