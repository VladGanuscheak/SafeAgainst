using System.Collections.Generic;
using System.Linq;

namespace SafeAgainst.CollectionGuards
{
    /// <summary>
    ///     Defines both basic synchronous and asynchronous guard clauses for any collection with a generic type in order to assign either a predefined value or an execution result to the passed value by reference or within a container.
    /// </summary>
    /// <typeparam name="T">The generic type.</typeparam>
    public partial class Safe<T> : SafeAgainst.Safe<IEnumerable<T>>
    {
        /// <summary>
        ///     Verifies if the collection has not been initialized (is null). If it is so, the provided default value will be assigned to the passed by reference enumeration.
        /// </summary>
        /// <param name="value">Required. The collection.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the mentioned collection has not been initialized.</param>
        public static void AgainstNull(ref IEnumerable<T> value, IEnumerable<T> defaultValue)
        {
            Against(ref value, x => x is null, defaultValue);
        }

        /// <summary>
        ///     Verifies if the collection has not been initialized (is null). If it is so, the provided default value will be assigned to the passed enumeration within a container.
        /// </summary>
        /// <param name="container">Required. The collection passed within a container.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the mentioned collection has not been initialized.</param>
        public static void AgainstNull(SafeContainer<IEnumerable<T>> container, IEnumerable<T> defaultValue)
        {
            Against(container, x => x is null, defaultValue);
        }

        /// <summary>
        ///     Verifies if the collection is empty (do not contain any element). If it is so, the provided default value will be assigned to the passed by reference enumeration.
        /// </summary>
        /// <param name="value">Required. The collection.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the mentioned collection is empty.</param>
        public static void AgainstEmpty(ref IEnumerable<T> value, IEnumerable<T> defaultValue)
        {
            Against(ref value, x => !x.Any(), defaultValue);
        }

        /// <summary>
        ///     Verifies if the collection is empty (do not contain any element). If it is so, the provided default value will be assigned to the passed enumeration within a container.
        /// </summary>
        /// <param name="container">Required. The collection passed within a container.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the mentioned collection has not been initialized.</param>
        public static void AgainstEmpty(SafeContainer<IEnumerable<T>> container, IEnumerable<T> defaultValue)
        {
            Against(container, x => !x.Any(), defaultValue);
        }

        /// <summary>
        ///     Verifies if the collection has not been initialized or is empty (is null or do not contain any element). If it is so, the provided default value will be assigned to the passed by reference enumeration.
        /// </summary>
        /// <param name="value">Required. The collection.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed by reference variable, if the mentioned collection has not been initialized or is empty.</param>
        public static void AgainstNullOrEmpty(ref IEnumerable<T> value, IEnumerable<T> defaultValue)
        {
            Against(ref value, x => x is null || !x.Any(), defaultValue);
        }

        /// <summary>
        ///     Verifies if the collection has not been initialized or is empty (is null or do not contain any element). If it is so, the provided default value will be assigned to the passed by reference enumeration.
        /// </summary>
        /// <param name="container">Required. The collection passed within a container.</param>
        /// <param name="defaultValue">Required. The default value. It will be applied for the passed variable within a container, if the mentioned collection has not been initialized or is empty.</param>
        public static void AgainstNullOrEmpty(SafeContainer<IEnumerable<T>> container, IEnumerable<T> defaultValue)
        {
            Against(container, x => x is null || !x.Any(), defaultValue);
        }

        /// <summary>
        ///     Verifies if the collection passed by reference has NULL elements. If it is so, the corresponding invalid items will be eliminated from the mentioned enumeration.
        /// </summary>
        /// <param name="value">Required. The collection.</param>
        public static void AgainstNullElements(ref IEnumerable<T> value)
        {
            Against(ref value, x => x.Any(item => item == null), x => x.Where(item => item != null));
        }

        /// <summary>
        ///     Verifies if the collection passed within container has NULL elements. If it is so, the corresponding invalid items will be eliminated from the mentioned enumeration.
        /// </summary>
        /// <param name="container">Required. The collection passed within a container.</param>
        public static void AgainstNullElements(SafeContainer<IEnumerable<T>> container)
        {
            Against(container, x => x.Any(item => item == null), x => x.Where(item => item != null));
        }

        /// <summary>
        ///     Verifies if the collection passed by reference has default elements. If it is so, the corresponding invalid items will be eliminated from the mentioned enumeration.
        /// </summary>
        /// <param name="value">Required. The collection.</param>
        public static void AgainstDefaultElements(ref IEnumerable<T> value)
        {
            Against(ref value, x => x.Any(item => item.Equals((T)default)), x => x.Where(item => !item.Equals((T)default)));
        }

        /// <summary>
        ///     Verifies if the collection passed by reference has default elements. If it is so, the corresponding invalid items will be eliminated from the mentioned enumeration.
        /// </summary>
        /// <param name="container">Required. The collection passed within a container.</param>
        public static void AgainstDefaultElements(SafeContainer<IEnumerable<T>> container)
        {
            Against(container, x => x.Any(item => item.Equals((T)default)), x => x.Where(item => !item.Equals((T)default)));
        }

        /// <summary>
        ///     Verifies if the collection contains out-of-range elements. If it is so, the corresponding invalid items will be eliminated from the mentioned enumeration.
        /// </summary>
        /// <param name="value">Required. The collection.</param>
        /// <param name="desiredSet">Required. The enumeration which contains all valid (expected) values.</param>
        public static void AgainstValuesNotInSet(ref IEnumerable<T> value, IEnumerable<T> desiredSet)
        {
            Against(ref value, x => x.Any(item => !desiredSet.Contains(item)), x => x.Where(item => desiredSet.Contains(item)));
        }

        /// <summary>
        ///     Verifies if the collection contains out-of-range elements. If it is so, the corresponding invalid items will be eliminated from the mentioned enumeration.
        /// </summary>
        /// <param name="value">Required. The collection passed within a container.</param>
        /// <param name="desiredSet">Required. The enumeration which contains all valid (expected) values.</param>
        public static void AgainstValuesNotInSet(SafeContainer<IEnumerable<T>> container, IEnumerable<T> desiredSet)
        {
            Against(container, x => x.Any(item => !desiredSet.Contains(item)), x => x.Where(item => desiredSet.Contains(item)));
        }
    }
}
