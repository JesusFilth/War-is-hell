using GameCreator.Runtime.Stats;
using Skills;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerAbilities : MonoBehaviour
    {
        private const float ResurectedHP = 10000;
        private const string HealthID = "hp";
        private const string ExperienceID = "xp";

        [SerializeField] private Traits _traits;
        [SerializeField] private ActiveSkillsStorage _skillsStorage;

        public ActiveSkillsStorage SkillsStorage => _skillsStorage;
        public Traits Traits => _traits;

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

        public void AddModifier(AttributeParameterModel attributeModel)
        {
            RuntimeAttributeData runtimeAttribute = _traits.RuntimeAttributes.Get(attributeModel.Attribute.ID);
            runtimeAttribute.Value = Mathf.Clamp(
                (float)runtimeAttribute.Value + attributeModel.Value,
                (float)runtimeAttribute.MinValue,
                (float)runtimeAttribute.MaxValue);
        }

        public void AddHealth(float value)
        {
            RuntimeAttributeData runtimeAttribute = _traits.RuntimeAttributes.Get(HealthID);
            runtimeAttribute.Value = value;
        }

        public void AddExperience(float value)
        {
            RuntimeStatData runtimeStat = _traits.RuntimeStats.Get(ExperienceID);
            runtimeStat.Base += value;
        }

        public void Resurrect()
        {
            AddHealth(ResurectedHP);
        }
    }
}