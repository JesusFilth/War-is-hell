using GameCreator.Runtime.Stats;

namespace Skills
{
    public struct StatParameterModel
    {
        public Stat Stat { get; private set; }
        public ModifierType Type { get; private set; }
        public float Value { get; private set; }

        public StatParameterModel(Stat stat, ModifierType type, float value)
        {
            Stat = stat;
            Type = type;
            Value = value;
        }
    }
}
