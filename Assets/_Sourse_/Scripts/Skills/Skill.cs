using UnityEngine;

public abstract class Skill : ScriptableObject
{
    protected const float MaxChance = 100;
    protected const float MinCooldawn = 1;

    [SerializeField] private SkillEffect _effect;
    [SerializeField] protected float Cooldawn = 3f;
    [SerializeField] protected float Chance = 100f;

    public SkillEffect Effect => _effect;
    private float _currentTime = 0;
    public bool IsCooldawn => _currentTime + Cooldawn >= Time.time;

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