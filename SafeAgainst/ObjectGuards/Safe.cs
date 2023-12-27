namespace SafeAgainst.ObjectGuards
{
    /// <summary>
    ///     Defines basic guard clauses for 'object' type in order to assign either a predefined value or an execution result to the passed value by reference or within a container. 
    /// </summary>
    public partial class Safe : Safe<object>
    {
        /// <summary>
        ///     Verifies if object is equal to NULL. If it is so, the provided default value will be assigned to the passed by reference object.
        /// </summary>
        /// <param name="value">Required. The value passed by reference.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the passed by reference variable, if the mentioned object is equal to zero.</param>
        public static void AgainstNull(ref object value, object defaultValue)
        {
            Against(ref value, x => x is null, defaultValue);
        }

        /// <summary>
        ///     Verifies if object is equal to NULL. If it is so, the provided default value will be assigned to the object passed within a container.
        /// </summary>
        /// <param name="container">Required. The object passed withina a container.</param>
        /// <param name="defaultValue">Required. Required. The default value. It will be applied for the variable passed within the container, if the mentioned object is equal to zero.</param>
        public static void AgainstNull(SafeContainer<object> container, object defaultValue)
        {
            Against(container, x => x is null, defaultValue);
        }
    }
}
