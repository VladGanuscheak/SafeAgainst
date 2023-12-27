namespace SafeAgainst
{
    /// <summary>
    ///     Encapsulates the desired value in order to modify it no matter if the generic type is a reference type or not.
    /// </summary>
    /// <typeparam name="T">The generic type.</typeparam>
    public class SafeContainer<T>
    {
        private T _value;

        /// <summary>
        ///     The current value.
        /// </summary>
        public T Value => _value;

        /// <summary>
        ///     Modifies the current value.
        /// </summary>
        /// <param name="value"></param>
        internal void SetValue(T value)
        {
            _value = value;
        }

        /// <summary>
        ///     Instantiates the generic container for the provided value in order to safely apply guard clauses for the value stored inside it.
        /// </summary>
        /// <param name="value">The value which will be stored inside the container.</param>
        /// <returns></returns>
        public static SafeContainer<T> Create(T value) => new SafeContainer<T>(value);

        private SafeContainer(T value)
        {
            _value = value;
        }
    }

    /// <summary>
    ///     Encapsulates the desired value in order to modify it no matter if the generic type is a reference type or not.
    /// </summary>
    public class SafeContainer
    {
        private SafeContainer() 
        { 
        }

        /// <summary>
        ///     Instantiates the generic container for the provided value in order to safely apply guard clauses for the value stored inside it.
        ///     It is a simplified version for instantiating the instance of type SafeContainer<T>. 
        /// </summary>
        /// <param name="value">The value which will be stored inside the container.</param>
        /// <returns></returns>
        public static SafeContainer<T> Create<T>(T value) => SafeContainer<T>.Create(value);
    }
}
