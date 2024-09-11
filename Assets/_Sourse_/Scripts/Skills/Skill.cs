using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    protected ISkillStratigy Stratigy;
    protected int Level = 0;

    public string Name => _name;
    public Sprite Icon => _icon;

    public abstract void ExecuteStratigy(PlayerAbilitys abilitys);

    public virtual string GetDescription() => "";
}