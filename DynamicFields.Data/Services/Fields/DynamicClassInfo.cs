using System;
using System.Reflection;

namespace DynamicFields.Data.Services.Fields
{
    public class DynamicClassInfo
    {
        public DynamicClassInfo(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }

        public static bool IsDynamicClass(Type type)
        {
            return type.GetCustomAttribute<DynamicClassAttribute>() != null;
        }
    }
}