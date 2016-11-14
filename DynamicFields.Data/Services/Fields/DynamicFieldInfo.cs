using System;
using System.Reflection;

namespace DynamicFields.Data.Services.Fields
{
    public class DynamicFieldInfo
    {
        public Type ClassType { get; set; }
        public PropertyInfo Property { get; set; }
        public PropertyInfo BaseProperty { get; set; }

        public DynamicFieldInfo(Type classType, PropertyInfo property, PropertyInfo baseProperty)
        {
            ClassType = classType;
            Property = property;
            BaseProperty = baseProperty;
        }

        public override string ToString()
        {
            return $"{ClassType.Name} -> " +
                   (BaseProperty == null ? "" : $"{BaseProperty.Name} -> ") +
                   $"{Property.Name} ({Property.PropertyType.Name})";
        }
    }
}