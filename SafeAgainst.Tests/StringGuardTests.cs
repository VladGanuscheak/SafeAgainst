using Xunit;

namespace SafeAgainst.Tests
{
    public class StringGuardTests
    {
        #region AgainstNull

        [Fact]
        public void AgainstNull_NullCheckByReference_Modified()
        {
            // Arrange
            string value = null;
            var defaultValue = "The message has not been specified";

            // Act
            StringGuards.Safe.AgainstNull(ref value, defaultValue);

            // Assert
            Assert.Equal(value, defaultValue);
        }

        [Fact]
        public void AgainstNull_NotNullCheckByReference_NotModified()
        {
            // Arrange
            var value = "Hi, world!";
            var initialValue = value;
            var defaultValue = "The message has not been specified";

            // Act
            StringGuards.Safe.AgainstNull(ref value, defaultValue);

            // Assert
            Assert.NotEqual(value, defaultValue);
            Assert.Equal(initialValue, value);
        }

        [Fact]
        public void AgainstNull_NullCheckByContainer_Modified()
        {
            // Arrange
            string value = null;
            var defaultValue = "The message has not been specified";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNull(container, defaultValue);
            value = container.Value;

            // Assert
            Assert.Equal(value, defaultValue);
        }

        [Fact]
        public void AgainstNull_NotNullCheckByContainer_NotModified()
        {
            // Arrange
            var value = "Hi, world!";
            var initialValue = value;
            var defaultValue = "The message has not been specified";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNull(container, defaultValue);
            value = container.Value;

            // Assert
            Assert.NotEqual(value, defaultValue);
            Assert.Equal(initialValue, value);
        }

        #endregion

        #region AgainstEmpty

        [Fact]
        public void AgainstEmpty_EmptyCheckByReference_Modified()
        {
            // Arrange
            var value = string.Empty;
            var defaultValue = "The message has not been provided";

            // Act
            StringGuards.Safe.AgainstEmpty(ref value, defaultValue);

            // Assert
            Assert.NotEqual(string.Empty, value);
            Assert.Equal(defaultValue, value);
        }

        [Fact]
        public void AgainstEmpty_NotEmptyCheckByReference_NotModified()
        {
            // Arrange
            var value = "Some value here";
            var initialValue = value;
            var defaultValue = "The message has not been provided";

            // Act
            StringGuards.Safe.AgainstEmpty(ref value, defaultValue);

            // Assert
            Assert.NotEqual(string.Empty, value);
            Assert.Equal(initialValue, value);
        }

        [Fact]
        public void AgainstEmpty_EmptyCheckByContainer_Modified()
        {
            // Arrange
            var value = string.Empty;
            var defaultValue = "The message has not been provided";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstEmpty(container, defaultValue);
            value = container.Value;

            // Assert
            Assert.NotEqual(string.Empty, value);
            Assert.Equal(defaultValue, value);
        }

        [Fact]
        public void AgainstEmpty_NotEmptyCheckByContainer_NotModified()
        {
            // Arrange
            var value = "Some value here";
            var initialValue = value;
            var defaultValue = "The message has not been provided";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstEmpty(container, defaultValue);
            value = container.Value;

            // Assert
            Assert.NotEqual(string.Empty, value);
            Assert.Equal(initialValue, value);
        }

        #endregion

        #region AgainstNullOrEmpty

        [Fact]
        public void AgainstNullOrEmpty_NullCheckByReference_Modified()
        {
            // Arrange
            string value = null;
            var defaultMessage = "The message has not been provided!";

            // Act
            StringGuards.Safe.AgainstNullOrEmpty(ref value, defaultMessage);

            // Assert
            Assert.NotNull(value);
            Assert.Equal(defaultMessage, value);
        }

        [Fact]
        public void AgainstNullOrEmpty_EmptyCheckByReference_Modified()
        {
            // Arrange
            var value = string.Empty;
            var defaultMessage = "This is the default message";

            // Act
            StringGuards.Safe.AgainstNullOrEmpty(ref value, defaultMessage);

            // Assert
            Assert.NotEqual(string.Empty, value);
            Assert.Equal(defaultMessage, value);
        }

        [Fact]
        public void AgainstNullOrEmpty_NotNullNotEmptyCheckByReference_NotModified()
        {
            // Arrange
            var value = "Some value here";
            var initialValue = value;
            var defaultMessage = "The message has not to change";

            // Act
            StringGuards.Safe.AgainstNullOrEmpty(ref value, defaultMessage);

            // Assert
            Assert.Equal(initialValue, value);
        }

        [Fact]
        public void AgainstNullOrEmpty_NullCheckByContainer_Modified()
        {
            // Arrange
            string value = null;
            var defaultMessage = "The message has not been provided!";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNullOrEmpty(container, defaultMessage);
            value = container.Value;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(defaultMessage, value);
        }

        [Fact]
        public void AgainstNullOrEmpty_EmptyCheckByContainer_Modified()
        {
            // Arrange
            var value = string.Empty;
            var defaultMessage = "This is the default message";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNullOrEmpty(container, defaultMessage);
            value = container.Value;

            // Assert
            Assert.NotEqual(string.Empty, value);
            Assert.Equal(defaultMessage, value);
        }

        [Fact]
        public void AgainstNullOrEmpty_NotNullNotEmptyCheckByContainer_NotModified()
        {
            // Arrange
            var value = "Some value here";
            var initialValue = value;
            var defaultMessage = "The message has not to change";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNullOrEmpty(ref value, defaultMessage);
            value = container.Value;

            // Assert
            Assert.Equal(initialValue, value);
        }

        #endregion

        #region AgainstNullOrWhiteSpace

        [Fact]
        public void AgainstNullOrWhiteSpace_NullCheckByReference_Modified()
        {
            // Arrange
            string value = null;
            var defaultValue = "The default message";

            // Act
            StringGuards.Safe.AgainstNullOrWhiteSpace(ref value, defaultValue);

            // Assert
            Assert.NotNull(value);
            Assert.Equal(defaultValue, value);
        }

        [Fact]
        public void AgainstNullOrWhiteSpace_WhiteSpacesCheckByReference_Modified()
        {
            // Arrange
            string value = "     ";
            var defaultValue = "The default message";

            // Act
            StringGuards.Safe.AgainstNullOrWhiteSpace(ref value, defaultValue);

            // Assert
            Assert.NotNull(value);
            Assert.Equal(defaultValue, value);
        }

        [Fact]
        public void AgainstNullOrWhiteSpace_ValidCheckByReference_NotModified()
        {
            // Arrange
            var value = "Some value here";
            var initialValue = value;
            var defaultValue = "Default value";

            // Act
            StringGuards.Safe.AgainstNullOrWhiteSpace(ref value, defaultValue);

            // Assert
            Assert.NotEqual(defaultValue, value);
            Assert.Equal(initialValue, value);
        }

        [Fact]
        public void AgainstNullOrWhiteSpace_NullCheckByContainer_Modified()
        {
            // Arrange
            string value = null;
            var defaultValue = "The default message";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNullOrWhiteSpace(container, defaultValue);
            value = container.Value;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(defaultValue, value);
        }

        [Fact]
        public void AgainstNullOrWhiteSpace_WhiteSpacesCheckByContainer_Modified()
        {
            // Arrange
            string value = "     ";
            var defaultValue = "The default message";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNullOrWhiteSpace(container, defaultValue);
            value = container.Value;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(defaultValue, value);
        }

        [Fact]
        public void AgainstNullOrWhiteSpace_ValidCheckByContainer_NotModified()
        {
            // Arrange
            var value = "Some value here";
            var initialValue = value;
            var defaultValue = "Default value";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstNullOrWhiteSpace(container, defaultValue);
            value = container.Value;

            // Assert
            Assert.NotEqual(defaultValue, value);
            Assert.Equal(initialValue, value);
        }

        #endregion

        #region AgainstLeadingWhiteSpaces

        [Fact]
        public void AgainstLeadingWhitespaces_LeadingWhitespacesCheckByReference_Modified()
        {
            // Arrange 
            var expectedValue = "Text after leading whitespaces";
            var value = $"   {expectedValue}";

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingWhitespaces_NullCheckByReference_NotModified()
        {
            // Arrange
            string value = null;

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(ref value);

            // Assert
            Assert.Null(value);
        }

        [Fact]
        public void AgainstLeadingWhitespaces_EmptyCheckByReference_NotModified()
        {
            // Arrange
            var value = string.Empty;

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(string.Empty, value);
        }

        [Fact]
        public void AgainstLeadingWhitespaces_ValidCheckByReference_NotModified()
        {
            // Arrange
            const string initialValue = "Without leading whitespaces";
            var value = initialValue;

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(initialValue, value);
        }

        [Fact]
        public void AgainstLeadingWhitespaces_LeadingWhitespacesCheckByContainer_Modified()
        {
            // Arrange 
            var expectedValue = "Text after leading whitespaces";
            var value = $"   {expectedValue}";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingWhitespaces_NullCheckByContainer_NotModified()
        {
            // Arrange
            string value = null;
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Null(value);
        }

        [Fact]
        public void AgainstLeadingWhitespaces_EmptyCheckByContainer_NotModified()
        {
            // Arrange
            var value = string.Empty;
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(string.Empty, value);
        }

        [Fact]
        public void AgainstLeadingWhitespaces_ValidCheckByContainer_NotModified()
        {
            // Arrange
            const string initialValue = "Without leading whitespaces";
            var value = initialValue;
            
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(initialValue, value);
        }

        #endregion

        #region AgainstTrailingWhiteSpaces

        [Fact]
        public void AgainstTrailingWhitespaces_TrailingWhitespacesCheckByReference_Modified()
        {
            // Arrange 
            var expectedValue = "Text after trailing whitespaces";
            var value = $"{expectedValue}     ";

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstTrailingWhitespaces_NullCheckByReference_NotModified()
        {
            // Arrange
            string value = null;

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Null(value);
        }

        [Fact]
        public void AgainstTrailingWhitespaces_EmptyCheckByReference_NotModified()
        {
            // Arrange
            var value = string.Empty;

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(string.Empty, value);
        }

        [Fact]
        public void AgainstTrailingWhitespaces_ValidCheckByReference_NotModified()
        {
            // Arrange
            const string initialValue = "Without trailing whitespaces";
            var value = initialValue;

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(initialValue, value);
        }

        [Fact]
        public void AgainstTrailingWhitespaces_TrailingWhitespacesCheckByContainer_Modified()
        {
            // Arrange 
            var expectedValue = "Text after trailing whitespaces";
            var value = $"{expectedValue}   ";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstTrailingWhitespaces_NullCheckByContainer_NotModified()
        {
            // Arrange
            string value = null;
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Null(value);
        }

        [Fact]
        public void AgainstTrailingWhitespaces_EmptyCheckByContainer_NotModified()
        {
            // Arrange
            var value = string.Empty;
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(string.Empty, value);
        }

        [Fact]
        public void AgainstTrailingWhitespaces_ValidCheckByContainer_NotModified()
        {
            // Arrange
            const string initialValue = "Without leading whitespaces";
            var value = initialValue;

            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(initialValue, value);
        }

        #endregion

        #region AgainstLeadingOrTrailingWhiteSpaces

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_ValidCheckByReference_NotModified()
        {
            // Arrange 
            const string expectedValue = "Valid example";
            var value = $"{expectedValue}";

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_LeadingWhitespacesCheckByReference_Modified()
        {
            // Arrange
            var expectedValue = "Without leading or trailing whitespaces";
            var value = $"    {expectedValue}";

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_TrailingWhitespacesCheckByReference_Modified()
        {
            // Arrange
            var expectedValue = "Without leading or trailing whitespaces";
            var value = $"{expectedValue}   ";

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_LeadingAndTrailingWhitespacesCheckByReference_Modified()
        {
            // Arrange
            var expectedValue = "Without leading or trailing whitespaces";
            var value = $"   {expectedValue}   ";

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_NullCheckByReference_NotModified()
        {
            // Arrange;
            string value = null;

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Null(value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_EmptyCheckByReference_NotModified()
        {
            // Arrange;
            var value = string.Empty;

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(ref value);

            // Assert
            Assert.Equal(string.Empty, value);
        }


        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_ValidCheckByContainer_NotModified()
        {
            // Arrange 
            const string expectedValue = "Valid example";
            var value = $"{expectedValue}";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_LeadingWhitespacesCheckByContainer_Modified()
        {
            // Arrange
            var expectedValue = "Without leading or trailing whitespaces";
            var value = $"    {expectedValue}";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_TrailingWhitespacesCheckByContainer_Modified()
        {
            // Arrange
            var expectedValue = "Without leading or trailing whitespaces";
            var value = $"{expectedValue}   ";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_LeadingAndTrailingWhitespacesCheckByContainer_Modified()
        {
            // Arrange
            var expectedValue = "Without leading or trailing whitespaces";
            var value = $"   {expectedValue}   ";
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_NullCheckByContainer_NotModified()
        {
            // Arrange;
            string value = null;
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Null(value);
        }

        [Fact]
        public void AgainstLeadingOrTrailingWhitespaces_EmptyCheckByContainer_NotModified()
        {
            // Arrange;
            var value = string.Empty;
            var container = SafeContainer.Create(value);

            // Act
            StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(container);
            value = container.Value;

            // Assert
            Assert.Equal(string.Empty, value);
        }

        #endregion
    }
}
