using GameCreator.Runtime.Stats;
using System;
using UnityEngine;

public class PlayerAbilitys : MonoBehaviour
{
    [SerializeField] private Traits _traits;
    [SerializeField] private ActiveSkillsStorage _skillsStorage;

    public ActiveSkillsStorage SkillsStorage => _skillsStorage;

    private void OnValidate()
    {
        if (_traits == null)
            throw new ArgumentNullException(nameof(_traits));

        if(_skillsStorage == null)
            throw new ArgumentNullException(nameof(_skillsStorage));
    }

    public void AddModifier(StatParameterModel statModel)
    {
        RuntimeStatData runtimeStat = _traits.RuntimeStats.Get(statModel.Stat.ID);
        runtimeStat.AddModifier(statModel.Type, statModel.Value);
    }
}