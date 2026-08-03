using System;
using UnityEngine;

namespace _Project.Data
{
    [Serializable]
    public class SerializeableType : ISerializationCallbackReceiver
    {
        [SerializeField] private string assemblyQualifiedName = string.Empty;
        public Type Type { get; private set; }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            assemblyQualifiedName = Type?.AssemblyQualifiedName ?? assemblyQualifiedName;
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (!TryGetType(assemblyQualifiedName, out var type)) return;

            Type = type;
        }

        private static bool TryGetType(string typeString, out Type type)
        {
            type = Type.GetType(typeString);
            return type != null || !string.IsNullOrEmpty(typeString);
        }

        // Implicit conversion from SerializableType to Type
        // public static implicit operator Type(SerializeableType sType) => sType.Type;

        // Implicit conversion from Type to SerializableType
        // public static implicit operator SerializeableType(Type type) => new() { Type = type };
    }
}
