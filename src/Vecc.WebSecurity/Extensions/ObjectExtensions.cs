using System;
using System.ComponentModel;

namespace Vecc.WebSecurity.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///     Gets the default value from the DefaultValueAttribute on a enum member.
        /// </summary>
        /// <param name="value">The enum value to get the object from.</param>
        /// <returns>The object from the DefaultValueAttribute, null if the attribute isn't found.</returns>
        public static object GetDefaultValue(this Enum value)
        {
            var attribute = GetAttribute<DefaultValueAttribute>(value);

            return attribute != null ? attribute.Value : null;
        }

        /// <summary>
        ///     Gets the first attribute of the specified type (T) on an enum value.
        /// </summary>
        /// <typeparam name="T">Type of attribute to get.</typeparam>
        /// <param name="value">The enum value to get the attribute from.</param>
        /// <returns>The first attribute of the specified type from the value, if the attribute is not found, it will return null.</returns>
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof (T), false);

            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}