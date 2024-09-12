using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Skill", menuName = "Pig Punch/Skills/Active", order = 2)]
public class SkillActive : Skill
{
    protected const float MaxChance = 100;
    protected const float MinCooldawn = 1;

    private const float CooldawnUPLevel = 0.1f;
    private const float ChanceUpLevel = 2f;

    [SerializeField] private SkillEffect _effect;  
    [SerializeField] protected float Cooldawn = 3f;
    [SerializeField] protected float Chance = 50f;

    public SkillEffect Effect => _effect;

    public bool IsCooldawn => _currentTime + Cooldawn >= Time.time;

    private float _currentTime = 0;

    private void Awake()
    {
        Stratigy = new ActiveSkillStratigy();
    }

    public override void ExecuteStratigy(PlayerAbilitys abilitys)
    {
        if (Stratigy == null)
            throw new ArgumentNullException(nameof(Stratigy));

        Stratigy.Execute(abilitys, this);
        Level++;
    }

    public virtual void UpSkill()//?
    {
        if (Level == 0)
            return;

        Cooldawn -= CooldawnUPLevel;
        Chance += ChanceUpLevel;
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
}