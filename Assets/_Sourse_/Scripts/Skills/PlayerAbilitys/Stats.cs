using System;
using GameCreator.Runtime.Variables;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private const string MaxHP = "MaxHP";
    private const string HP = "HP";
    private const string Damage = "Damage";
    private const string Durability = "Durability";

    [SerializeField] private LocalNameVariables _variables;

    public void AddMaxHeal(float value)
    {
        float maxHp = Convert.ToSingle(_variables.Get(MaxHP));
        maxHp += value;

        _variables.Set(MaxHP, maxHp);
    }

    public void AddHeal(float value)
    {
        float hp = Convert.ToSingle(_variables.Get(HP));
        float maxHp = Convert.ToSingle(_variables.Get(MaxHP));

        hp = Mathf.Clamp(hp+=value, 0, maxHp);
        _variables.Set(HP, hp);
    }

    public void AddDamage(float value)
    {
        float damage = Convert.ToSingle(_variables.Get(Damage));
        damage += value;

        _variables.Set(Damage, damage);
    }

    public void AddDurability(float value)
    {
        float durability = Convert.ToSingle(_variables.Get(Durability));
        durability += value;

        _variables.Set(Durability, durability);
    }

    public void AddFullHeal()
    {
        float maxHp = Convert.ToSingle(_variables.Get(MaxHP));

        _variables.Set(HP, maxHp);
    }
}