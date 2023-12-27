using Xunit;

namespace SafeAgainst.Tests
{
    public class ObjectGuardTests
    {
        #region AgainstNull

        [Fact]
        public void AgainstNull_NullCheckByReference_Modified()
        {
            // Arrange
            object obj = null;
            var expectedValue = new object();

            // Act
            ObjectGuards.Safe.AgainstNull(ref obj, expectedValue);

            // Assert
            Assert.NotNull(obj);
            Assert.Equal(expectedValue, obj);
        }

        [Fact]
        public void AgainstNull_NotNullCheckByReference_NotModified()
        {
            // Arrange
            var obj = new object();
            var initialValue = obj;

            // Act
            ObjectGuards.Safe.AgainstNull(ref obj, new { a = 1 });

            // Assert
            Assert.Equal(initialValue, obj);
        }

        [Fact]
        public void AgainstNull_NullCheckByContainer_Modified()
        {
            // Arrange
            object obj = null;
            var expectedValue = new object();
            var container = SafeContainer.Create(obj);

            // Act
            ObjectGuards.Safe.AgainstNull(container, expectedValue);
            obj = container.Value;

            // Assert
            Assert.NotNull(obj);
            Assert.Equal(expectedValue, obj);
        }

        [Fact]
        public void AgainstNull_NotNullCheckByContainer_NotModified()
        {
            // Arrange
            var obj = new object();
            var initialValue = obj;
            var container = SafeContainer.Create(obj);

            // Act
            ObjectGuards.Safe.AgainstNull(container, new { a = 1 });
            obj = container.Value;

            // Assert
            Assert.Equal(initialValue, obj);
        }

        #endregion
    }
}
