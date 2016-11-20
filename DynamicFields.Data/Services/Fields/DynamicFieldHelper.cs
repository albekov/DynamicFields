using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using DynamicFields.Data.Model;

namespace DynamicFields.Data.Services.Fields
{
    public static class DynamicFieldHelper
    {
        public static DynamicClassInfo GetDynamicClassInfo(this Type type)
        {
            var attribute = type.GetCustomAttribute<DynamicClassAttribute>();
            if (attribute == null)
                throw new InvalidOperationException();

            return new DynamicClassInfo(type);
        }

        public static List<DynamicFieldInfo> GetDynamicFields(this Type type)
        {
            var result = new List<DynamicFieldInfo>();

            var properties = type.GetProperties().ToList();

            result.AddRange(
                properties
                    .Where(IsDynamicField)
                    .Select(p => new DynamicFieldInfo(type, p, null))
            );

            foreach (var property in properties)
            {
                var propertyInfos = property.PropertyType.GetProperties();
                var nestedProperties = propertyInfos
                    .Where(IsDynamicField)
                    .ToList();

                result.AddRange(
                    nestedProperties
                        .Select(p => new DynamicFieldInfo(type, p, property))
                );
            }

            return result;
        }

        private static bool IsDynamicField(PropertyInfo propertyInfo)
        {
            return propertyInfo.CanRead &&
                   propertyInfo.CanWrite &&
                   propertyInfo.Name != nameof(IdentityEntity<int>.Id) &&
                   !propertyInfo.GetGetMethod().IsVirtual &&
                   propertyInfo.GetCustomAttribute<ForeignKeyAttribute>() == null &&
                   IsDynamicPropertyType(propertyInfo.PropertyType);
        }

        private static bool IsDynamicPropertyType(Type type)
        {
            if (type.IsPrimitive) return true;
            if (type == typeof(string)) return true;
            if (type == typeof(DateTime)) return true;

            if (type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsDynamicPropertyType(Nullable.GetUnderlyingType(type)))
                return true;

            return false;
        }
    }
}