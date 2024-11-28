using System;
using UnityEngine;

namespace Core
{
    public class SerializeInterfaceAttribute : PropertyAttribute
    {
        public SerializeInterfaceAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}