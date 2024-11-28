using GameCreator.Runtime.Stats;

namespace Skills
{
    public struct AttributeParameterModel
    {
        public Attribute Attribute { get; private set; }
        public float Value { get; private set; }

        public AttributeParameterModel(Attribute attribute, float value)
        {
            Attribute = attribute;
            Value = value;
        }
    }
}