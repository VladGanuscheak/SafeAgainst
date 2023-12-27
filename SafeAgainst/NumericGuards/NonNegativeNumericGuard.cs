using System;

namespace SafeAgainst.NumericGuards
{
    /// <summary>
    ///     Defines basic guard clauses for any numeric type in order to assign either a predefined value or an execution result to the passed value by reference or within a container.
    /// </summary>
    /// <typeparam name="T">The generic type which accepts only numerics.</typeparam>
    public abstract class NonNegativeNumericGuard<T> : Safe<T>
        where T : struct, IComparable<T>, IComparable, IConvertible, IEquatable<T>, IFormattable
    {
        /// <summary>
        ///     Verifies if the value passed by reference is equal to zero. If it is so, the provided default value will be assigned to the passed by reference variable.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the reference value is zero.</param>
        public static void AgainstZero(ref T value, T defaultValue)
        {
            Against(ref value, x => x.Equals(default), defaultValue);
        }

        /// <summary>
        ///     Verifies if the value passed within a container is equal to zero. If it is so, the provided default value will be assigned to the variable passed within the container.
        /// </summary>
        /// <param name="container">Required. The value within a container.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the corresponding value is zero.</param>
        public static void AgainstZero(SafeContainer<T> container, T defaultValue)
        {
            Against(container, x => x.Equals(default), defaultValue);
        }

        /// <summary>
        ///     Verifies if the reference value is not in the desired range. If it is so, the provided default value will be assigned to the referenced one.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="minValue">Required. The minimal valid value.</param>
        /// <param name="maxValue">Required. The maximal valid value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable by reference, if the mentioned value is out of the specified range.</param>
        public static void AgainstNotInRange(ref T value, T minValue, T maxValue, T defaultValue)
        {
            Against(ref value, x => x.CompareTo(minValue) < 0 || x.CompareTo(maxValue) > 0, defaultValue);
        }

        /// <summary>
        ///     Verifies if the value within a container is not in the desired range. If it is so, the provided default value will be assigned to the one from the corresponding container.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="minValue">Required. The minimal valid value.</param>
        /// <param name="maxValue">Required. The maximal valid value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the mentioned value is out of the specified range.</param>
        public static void AgainstNotInRange(SafeContainer<T> container, T minValue, T maxValue, T defaultValue)
        {
            Against(container, x => x.CompareTo(minValue) < 0 || x.CompareTo(maxValue) > 0, defaultValue);
        }

        #region Nullable overloads

        /// <summary>
        ///     Verifies if the value passed by reference is NULL or is equal to zero. If it is so, the provided default value will be assigned to the passed by reference variable.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the reference value is NULL or is equal to zero.</param>
        public static void AgainstNullOrZero(ref T? value, T defaultValue)
        {
            if (!value.HasValue)
            {
                value = defaultValue;
                return;
            }

            var property = value.Value;
            AgainstZero(ref property, defaultValue);
            value = property;
        }

        /// <summary>
        ///     Verifies if the value passed within a container is NULL or is equal to zero. If it is so, the provided default value will be assigned to the variable passed within the container.
        /// </summary>
        /// <param name="container">Required. The value within a container.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the corresponding value is zero.</param>
        public static void AgainstNullOrZero(SafeContainer<T?> container, T defaultValue)
        {
            if (!container.Value.HasValue)
            {
                container.SetValue(defaultValue);
                return;
            }

            var property = container.Value.Value;
            AgainstZero(ref property, defaultValue);
            container.SetValue(property);
        }

        /// <summary>
        ///     Verifies if the reference value is NULL or is not in the desired range. If it is so, the provided default value will be assigned to the referenced one.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="minValue">Required. The minimal valid value.</param>
        /// <param name="maxValue">Required. The maximal valid value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable by reference, if the mentioned value is NULL or is out of the specified range.</param>
        public static void AgainstNullOrNotInRange(ref T? value, T minValue, T maxValue, T defaultValue)
        {
            if (!value.HasValue)
            {
                value = defaultValue;
                return;
            }

            var property = value.Value;
            AgainstNotInRange(ref property, minValue, maxValue, defaultValue);
            value = property;
        }

        /// <summary>
        ///     Verifies if the value within a container is NULL or is not in the desired range. If it is so, the provided default value will be assigned to the one from the corresponding container.
        /// </summary>
        /// <param name="value">Required. The numeric value.</param>
        /// <param name="minValue">Required. The minimal valid value.</param>
        /// <param name="maxValue">Required. The maximal valid value.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the mentioned value is NULL or is out of the specified range.</param>
        public static void AgainstNullOrNotInRange(SafeContainer<T?> container, T minValue, T maxValue, T defaultValue)
        {
            if (!container.Value.HasValue)
            {
                container.SetValue(defaultValue);
                return;
            }

            var property = container.Value.Value;
            AgainstNotInRange(ref property, minValue, maxValue, defaultValue);
            container.SetValue(property);
        }

        #endregion
    }
}
