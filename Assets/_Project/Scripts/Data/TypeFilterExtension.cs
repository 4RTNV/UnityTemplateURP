using System;
using System.Linq;

namespace _Project.Data
{
    public static class TypeFilterExtension
    {
        /// <summary>
        /// Checks if a given type inherits or implements a specified base type
        /// </summary>
        /// <param name="type">To be checked type</param>
        /// <param name="baseType">The ancestor type</param>
        /// <returns>True if type implements base type</returns>
        public static bool InheritsOrImplements(this Type type, Type baseType)
        {
            type = ResolveGenericType(type);
            baseType = ResolveGenericType(baseType);

            while (type != typeof(object))
            {
                if (baseType == type || HasAnyInterfaces(type, baseType)) return true;

                type = ResolveGenericType(type.BaseType);
                if (type == null) return false;
            }

            return false;
        }

        private static bool HasAnyInterfaces(Type type, Type interfaceType)
        {
            return type.GetInterfaces().Any(i => ResolveGenericType(i) == interfaceType);
        }

        private static Type ResolveGenericType(Type type)
        {
            if (type is not { IsGenericType: true }) return type;

            var genericType = type.GetGenericTypeDefinition();
            return genericType != type ? genericType : type;
        }
    }
}
