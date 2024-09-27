using GameCreator.Runtime.Stats;
using UnityEngine;

public class PlayerAbilitys : MonoBehaviour
{
    private const float ResurectedHP = 1000;
    private const string HealthID = "hp";

    [SerializeField] private Traits _traits;
    [SerializeField] private ActiveSkillsStorage _skillsStorage;

    public ActiveSkillsStorage SkillsStorage => _skillsStorage;

    private void OnValidate()
    {
        if (_traits == null)
            throw new System.ArgumentNullException(nameof(_traits));

        if(_skillsStorage == null)
            throw new System.ArgumentNullException(nameof(_skillsStorage));
    }

    public void AddModifier(StatParameterModel statModel)
    {
        RuntimeStatData runtimeStat = _traits.RuntimeStats.Get(statModel.Stat.ID);
        runtimeStat.AddModifier(statModel.Type, statModel.Value);
    }

    public void AddHealth(float value)
    {
        RuntimeAttributeData runtimeAttribute = _traits.RuntimeAttributes.Get(HealthID);
        runtimeAttribute.Value = value;
    }

    public void Resurrect()
    {
        AddHealth(ResurectedHP);
    }
}