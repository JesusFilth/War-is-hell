using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Active", order = 2)]
public class SkillActive : Skill
{
    protected const float MaxChance = 100;
    protected const float MinCooldawn = 1;

    [Space]
    [Header("Skill Active settings")]
    [SerializeField] private SkillEffect _effect;  
    [SerializeField] protected float Cooldawn = 3f;
    [SerializeField] protected float Chance = 50f;
    [SerializeField] private float _upCooldawnLevel = 0.1f;
    [SerializeField] private float _upChanceLevel = 2f;

    public SkillEffect Effect => _effect;

    public bool IsCooldawn => _currentTime + Cooldawn >= Time.time;

    private float _currentTime = 0;

    public override void ExecuteStratigy(PlayerAbilitys abilitys)
    {
        if (Stratigy == null)
            throw new ArgumentNullException(nameof(Stratigy));

        Stratigy.Execute(abilitys, this);
    }

    public override void UpSkill()
    {
        Level++;

        Cooldawn = Mathf.Clamp(Cooldawn - _upCooldawnLevel, MinCooldawn, float.MaxValue);
        Chance = Mathf.Clamp(Chance + _upChanceLevel, 0, MaxChance);

        CheckMaxLevel();
    }

    public virtual void Active()
    {
        _currentTime = Time.time;
    }

    public bool CanActiveEffectForChance()
    {
        float randomChance = Random.Range(0, MaxChance);
        return randomChance <= Chance;
    }

    protected override void CheckMaxLevel()
    {
        if(Cooldawn == MinCooldawn && Chance == MaxChance)
            IsMaxLevel = true;
    }
}