namespace SafeAgainst.StringGuards
{
    /// <summary>
    ///     Defines basic guard clauses for 'string' type in order to assign either a predefined value or an execution result to the passed value by reference or within a container. 
    /// </summary>
    public partial class Safe : Safe<string>
    {
        /// <summary>
        ///     Verifies if string equal to NULL. If it is so, the provided default value will be assigned to the passed by reference string.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the passed by reference variable, if the mentioned string is equal to NULL.</param>
        public static void AgainstNull(ref string value, string defaultValue)
        {
            Against(ref value, x => x is null, defaultValue);
        }

        /// <summary>
        ///     Verifies if string is equal to NULL. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="container">Required. The value passed within a container.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the variable passed within the container, if the mentioned string is equal to NULL.</param>
        public static void AgainstNull(SafeContainer<string> container, string defaultValue)
        {
            Against(container, x => x == null, defaultValue);
        }

        /// <summary>
        ///     Verifies if string is empty. If it is so, the provided default value will be assigned to the passed by reference string.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the passed by reference variable, if the mentioned string is empty.</param>
        public static void AgainstEmpty(ref string value, string defaultValue)
        {
            Against(ref value, x => x == string.Empty, defaultValue);
        }

        /// <summary>
        ///     Verifies if string is empty If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="container">Required. The value passed within a container.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the variable passed within the container, if the mentioned string is empty.</param>
        public static void AgainstEmpty(SafeContainer<string> container, string defaultValue)
        {
            Against(container, x => x == string.Empty, defaultValue);
        }

        /// <summary>
        ///     Verifies if string is null or empty. If it is so, the provided default value will be assigned to the passed by reference string.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the passed by reference variable, if the mentioned string is null or empty.</param>
        public static void AgainstNullOrEmpty(ref string value, string defaultValue)
        {
            Against(ref value, x => string.IsNullOrEmpty(x), defaultValue);
        }

        /// <summary>
        ///     Verifies if string is null or empty. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="container">Required. The value passed within a container.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the variable passed within the container, if the mentioned string is null or empty.</param>
        public static void AgainstNullOrEmpty(SafeContainer<string> container, string defaultValue)
        {
            Against(container, x => string.IsNullOrEmpty(x), defaultValue);
        }

        /// <summary>
        ///     Verifies if string is null or contains only white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the variable passed within the container, if the mentioned string is null or contains only white spaces.</param>
        public static void AgainstNullOrWhiteSpace(ref string value, string defaultValue)
        {
            Against(ref value, x => string.IsNullOrWhiteSpace(x), defaultValue);
        }

        /// <summary>
        ///     Verifies if string is null or contains only white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="container">Required. The value passed within a container.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the variable passed within the container, if the mentioned string is null or contains only white spaces.</param>
        public static void AgainstNullOrWhiteSpace(SafeContainer<string> container, string defaultValue)
        {
            Against(container, x => string.IsNullOrWhiteSpace(x), defaultValue);
        }

        /// <summary>
        ///     Verifies if string contains leading white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        public static void AgainstLeadingWhiteSpaces(ref string value)
        {
            Against(ref value, x => !string.IsNullOrEmpty(x) && char.IsWhiteSpace(x[0]), x => x?.TrimStart());
        }

        /// <summary>
        ///     Verifies if string contains leading white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="container">Required. The value passed within a container.</param>
        public static void AgainstLeadingWhiteSpaces(SafeContainer<string> container)
        {
            Against(container, x => !string.IsNullOrEmpty(x) && char.IsWhiteSpace(x[0]), x => x?.TrimStart());
        }

        /// <summary>
        ///     Verifies if string contains trailing white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        public static void AgainstTrailingWhiteSpaces(ref string value)
        {
            Against(ref value, x => !string.IsNullOrEmpty(x) && char.IsWhiteSpace(x[x.Length - 1]), x => x?.TrimEnd());
        }

        /// <summary>
        ///     Verifies if string contains trailing white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="container">Required. The value passed within a container.</param>
        public static void AgainstTrailingWhiteSpaces(SafeContainer<string> container)
        {
            Against(container, x => !string.IsNullOrEmpty(x) && char.IsWhiteSpace(x[x.Length - 1]), x => x?.TrimEnd());
        }

        /// <summary>
        ///     Verifies if string contains leading or trailing white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        public static void AgainstLeadingOrTrailingWhiteSpaces(ref string value)
        {
            AgainstLeadingWhiteSpaces(ref value);
            AgainstTrailingWhiteSpaces(ref value);
        }

        /// <summary>
        ///     Verifies if string contains leading or trailing white spaces. If it is so, the provided default value will be assigned to the string passed within a container.
        /// </summary>
        /// <param name="container">Required. The value passed within a container.</param>
        public static void AgainstLeadingOrTrailingWhiteSpaces(SafeContainer<string> container)
        {
            AgainstLeadingWhiteSpaces(container);
            AgainstTrailingWhiteSpaces(container);
        }
    }
}