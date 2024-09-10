using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Curce", order = 2)]
public class SkillCurce : Skill
{
    private const int MaxEnemys = 5;

    [SerializeField] private int _enemyCount = 1;

    public int EnemyCount => _enemyCount;
}
