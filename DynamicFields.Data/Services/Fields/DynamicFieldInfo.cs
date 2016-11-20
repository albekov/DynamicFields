using System;
using System.Reflection;

namespace DynamicFields.Data.Services.Fields
{
    public class DynamicFieldInfo
    {
        public DynamicFieldInfo(Type classType, PropertyInfo property, PropertyInfo baseProperty)
        {
            ClassType = classType;
            Property = property;
            BaseProperty = baseProperty;

            Name = $"{ClassType.Name}." +
                   (BaseProperty == null ? "" : $"{BaseProperty.Name}.") +
                   $"{Property.Name}";
            Type = property.PropertyType;
        }

        public Type ClassType { get; set; }
        public PropertyInfo Property { get; set; }
        public PropertyInfo BaseProperty { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }

        public override string ToString()
        {
            return $"{ClassType.Name} -> " +
                   (BaseProperty == null ? "" : $"{BaseProperty.Name} -> ") +
                   $"{Property.Name} ({Property.PropertyType.Name})";
        }
    }
}