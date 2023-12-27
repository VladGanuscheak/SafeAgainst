using System;

namespace SafeAgainst.NumericGuards
{
    /// <summary>
    ///     Defines basic guard clauses for any numeric type in order to assign either a predefined value or an execution result to the passed value by reference or within a container.
    /// </summary>
    /// <typeparam name="T">The generic type which accepts only numerics.</typeparam>
    public abstract class NumericGuard<T> : NonNegativeNumericGuard<T>
        where T : struct, IComparable<T>, IComparable, IConvertible, IEquatable<T>, IFormattable
    {
        /// <summary>
        ///     Verifies if the value passed by reference is a negative one. If it is so, the provided default value will be assigned to the passed by reference variable.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the reference value is a negative one.</param>
        public static void AgainstNegative(ref T value, T defaultValue)
        {
            Against(ref value, x => x.CompareTo(default) < 0, defaultValue);
        }

        /// <summary>
        ///     Verifies if the value passed within a container is a negative one. If it is so, the provided default value will be assigned to the variable passed within the container.
        /// </summary>
        /// <param name="container">Required. The value within a container.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the corresponding value is a negative one.</param>
        public static void AgainstNegative(SafeContainer<T> container, T defaultValue)
        {
            Against(container, x => x.CompareTo(default) < 0, defaultValue);
        }

        #region Nullable overloads

        /// <summary>
        ///     Verifies if the value passed by reference is NULL or is a negative one. If it is so, the provided default value will be assigned to the passed by reference variable.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the reference value is NULL or is a negative one.</param>
        public static void AgainstNullOrNegative(ref T? value, T defaultValue)
        {
            if (!value.HasValue)
            {
                value = defaultValue;
                return;
            }

            var property = value.Value;
            AgainstNegative(ref property, defaultValue);
            value = property;
        }

        /// <summary>
        ///     Verifies if the value passed within a container is NULL or a negative one. If it is so, the provided default value will be assigned to the variable passed within the container.
        /// </summary>
        /// <param name="container">Required. The value within a container.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the corresponding value is NULL or is a negative one.</param>
        public static void AgainstNullOrNegative(SafeContainer<T?> container, T defaultValue)
        {
            if (!container.Value.HasValue)
            {
                container.SetValue(defaultValue);
                return;
            }

            var property = container.Value.Value;
            AgainstNegative(ref property, defaultValue);
            container.SetValue(property);
        }

        #endregion
    }
}
