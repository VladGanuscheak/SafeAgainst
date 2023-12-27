using System;

namespace SafeAgainst.EnumGuards
{
    /// <summary>
    ///     Defines basic guard clauses for any enum in order to assign either a predefined value or an execution result to the passed value by reference or within a container.
    /// </summary>
    /// <typeparam name="T">The generic type which accepts only enums.</typeparam>
    public partial class Safe<T> : SafeAgainst.Safe<T> where T : struct, Enum
    {
        /// <summary>
        ///     Verifies if the value passed by reference is not valid for the specified enum (is not in range of enum's values). If it is so, the provided default value will be assigned to the passed by reference variable.
        /// </summary>
        /// <param name="value">Required. The enum.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the mentioned enum is not in the range of the corrsponding type.</param>
        public static void AgainstNotInRange(ref T value, T defaultValue)
        {
            Against(ref value, x => !Enum.IsDefined(x.GetType(), x), defaultValue);
        }

        /// <summary>
        ///     Verifies if the value passed within a container is not valid for the specified enum (is not in range of enum's values). If it is so, the provided default value will be assigned to the passed variable within a container.
        /// </summary>
        /// <param name="value">Required. The enum.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the mentioned enum is not in the range of the corrsponding type.</param>
        public static void AgainstNotInRange(SafeContainer<T> container, T defaultValue)
        {
            Against(container, x => !Enum.IsDefined(x.GetType(), x), defaultValue);
        }

        #region Nullable overloads

        /// <summary>
        ///     Verifies if the value passed by reference is NULL or not valid for the specified enum (is not in range of enum's values). If it is so, the provided default value will be assigned to the passed by reference variable.
        /// </summary>
        /// <param name="value">Required. The enum.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the mentioned enum is NULL or is not in the range of the corrsponding type.</param>
        public static void AgainstNullOrNotInRange(ref T? value, T defaultValue)
        {
            if (!value.HasValue)
            {
                value = defaultValue;
                return;
            }

            var property = value.Value;
            Against(ref property, x => !Enum.IsDefined(x.GetType(), x), defaultValue);
            value = property;
        }

        /// <summary>
        ///     Verifies if the value passed within a container is NULL or not valid for the specified enum (is not in range of enum's values). If it is so, the provided default value will be assigned to the passed variable within a container.
        /// </summary>
        /// <param name="value">Required. The enum.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the mentioned enum NULL or is not in the range of the corrsponding type.</param>
        public static void AgainstNullOrNotInRange(SafeContainer<T?> container, T defaultValue)
        {
            if (!container.Value.HasValue)
            {
                container.SetValue(defaultValue);
                return;
            }

            var property = container.Value.Value;
            Against(ref property, x => !Enum.IsDefined(x.GetType(), x), defaultValue);
            container.SetValue(property);
        }

        #endregion
    }
}

