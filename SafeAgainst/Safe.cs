using System;
using System.Threading.Tasks;

namespace SafeAgainst
{
    /// <summary>
    ///     Defines both basic synchronous and asynchronous guard clauses for a generic type in order to assign either a predefined value or an execution result to the passed value by reference or within a container.
    /// </summary>
    /// <typeparam name="T">The generic type.</typeparam>
    public partial class Safe<T>
    {
        /// <summary>
        ///     Assigns the provided default value to the passed one by reference, if the predicate will be evaluated as True.
        /// </summary>
        /// <param name="value">Required. The reference value.</param>
        /// <param name="predicate">Required. The predicate. If it will be evaluated to true, the current reference value will be assigned with the provided default value.</param>
        /// <param name="defaultValue">Required. The default value.</param>
        public static void Against(ref T value, Func<T, bool> predicate, T defaultValue)
        {
            if (predicate(value))
            {
                value = defaultValue;
            }
        }

        /// <summary>
        ///     Assigns the provided default value to the passed one inside the container, if the predicate will be evaluated as True.
        /// </summary>
        /// <param name="container">Required. The container which stores the value that can be modified.</param>
        /// <param name="predicate">Required. The predicate. If it will be evaluated to true, the current reference value will be assigned with the provided default value.</param>
        /// <param name="defaultValue">Required. The default value.</param>
        public static void Against(SafeContainer<T> container, Func<T, bool> predicate, T defaultValue)
        {
            if (predicate(container.Value))
            {
                container.SetValue(defaultValue);
            }
        }

        /// <summary>
        ///     Invokes the replace function and assigns the evaluated result to the passed value by reference, if the predicate will be evaluated as True.
        /// </summary>
        /// <param name="value">Required. The reference value.</param>
        /// <param name="predicate">Required. The predicate. If it will be evaluated to true, the current reference value will be assigned with the evaluated result of the specified function.</param>
        /// <param name="replace">Required. The function which will evaluate the final result.</param>
        public static void Against(ref T value, Func<T, bool> predicate, Func<T> replace)
        {
            if (predicate(value))
            {
                value = replace();
            }
        }

        /// <summary>
        ///     Invokes the replace function and assigns the evaluated result to the passed value within a container, if the predicate will be evaluated as True.
        /// </summary>
        /// <param name="container">Required. The container which stores the value that can be modified.</param>
        /// <param name="predicate">Required. The predicate. If it will be evaluated to true, the current value inside the container will be assigned with the evaluated result of the replace function.</param>
        /// <param name="replace">Required. The function which will evaluate the final result.</param>
        public static void Against(SafeContainer<T> container, Func<T, bool> predicate, Func<T> replace)
        {
            if (predicate(container.Value))
            {
                container.SetValue(replace());
            }
        }

        /// <summary>
        ///     Invokes the replace function and assigns the evaluated result to the passed value by reference, if the predicate will be evaluated as True.
        /// </summary>
        /// <param name="value">Required. The reference value.</param>
        /// <param name="predicate">Required. The predicate. If it will be evaluated to true, the current reference value will be assigned with the evaluated result of the specified function.</param>
        /// <param name="replace">Required. The function which will evaluate the final result.</param>
        public static void Against(ref T value, Func<T, bool> predicate, Func<T, T> replace)
        {
            if (predicate(value))
            {
                value = replace(value);
            }
        }

        /// <summary>
        ///     Invokes the replace function and assigns the evaluated result to the passed value within a container, if the predicate will be evaluated as True.
        /// </summary>
        /// <param name="container">Required. The container which stores the value that can be modified.</param>
        /// <param name="predicate">Required. The predicate. If it will be evaluated to true, the current value inside the container will be assigned with the evaluated result of the replace function.</param>
        /// <param name="replace">Required. The function which will evaluate the final result.</param>
        public static void Against(SafeContainer<T> container, Func<T, bool> predicate, Func<T, T> replace)
        {
            if (predicate(container.Value))
            {
                container.SetValue(replace(container.Value));
            }
        }

        /// <summary>
        ///     Asynchronously invokes the replace function and assigns the evaluated result to the passed value within a container, if the predicate will be evaluated as True.
        /// </summary>
        /// <param name="container">Required. The container which stores the value that can be modified.</param>
        /// <param name="predicate">Required. The predicate. If it will be evaluated to true, the current value inside the container will be assigned with the evaluated result of the replace function.</param>
        /// <param name="replace">Required. The function which will asynchronously evaluate the final result.</param>
        public static async Task AsyncAgainst(SafeContainer<T> container, Func<T, bool> predicate, Func<Task<T>> replace)
        {
            if (predicate(container.Value))
            {
                container.SetValue(await replace());
            }
        }

        /// <summary>
        ///     Asynchronously invokes the replace function and assigns the evaluated result to the passed value within a container, if the asynchronously executed predicate will be evaluated as True.
        /// </summary>
        /// <param name="container">Required. The container which stores the value that can be modified.</param>
        /// <param name="predicate">Required. The predicate. Is invoked asynchronously. If it will be evaluated to true, the current value inside the container will be assigned with the evaluated result of the replace function.</param>
        /// <param name="replace">Required. The function which will asynchronously evaluate the final result.</param>
        public static async Task AsyncAgainst(SafeContainer<T> container, Func<T, Task<bool>> predicate, Func<Task<T>> replace)
        {
            if (await predicate(container.Value))
            {
                container.SetValue(await replace());
            }
        }

        /// <summary>
        ///     Asynchronously invokes the replace function and assigns the evaluated result to the passed value within a container, if the asynchronously executed predicate will be evaluated as True.
        /// </summary>
        /// <param name="container">Required. The container which stores the value that can be modified.</param>
        /// <param name="predicate">Required. The predicate. Is invoked asynchronously. If it will be evaluated to true, the current value inside the container will be assigned with the evaluated result of the replace function.</param>
        /// <param name="replace">Required. The function which will asynchronously evaluate the final result.</param>
        public static async Task AsyncAgainst(SafeContainer<T> container, Func<T, bool> predicate, Func<T, Task<T>> replace)
        {
            if (predicate(container.Value))
            {
                container.SetValue(await replace(container.Value));
            }
        }

        /// <summary>
        ///     Asynchronously invokes the replace function and assigns the evaluated result to the passed value within a container, if the asynchronously executed predicate will be evaluated as True.
        /// </summary>
        /// <param name="container">Required. The container which stores the value that can be modified.</param>
        /// <param name="predicate">Required. The predicate. Is invoked asynchronously. If it will be evaluated to true, the current value inside the container will be assigned with the evaluated result of the replace function.</param>
        /// <param name="replace">Required. The function which will asynchronously evaluate the final result.</param>
        public static async Task AsyncAgainst(SafeContainer<T> container, Func<T, Task<bool>> predicate, Func<T, Task<T>> replace)
        {
            if (await predicate(container.Value))
            {
                container.SetValue(await replace(container.Value));
            }
        }
    }
}