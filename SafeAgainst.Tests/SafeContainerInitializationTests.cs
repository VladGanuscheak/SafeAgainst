using Xunit;

namespace SafeAgainst.Tests
{
    public class SafeContainerInitializationTests
    {
        internal abstract class BaseClass
        {
        }

        internal class ConcreteClassA : BaseClass
        {
        }

        internal class ConcreteClassB : BaseClass
        {
        }

        [Fact]
        public void Create_ExplicitlySpecifyingType_Matches()
        {
            // Arrange
            var container = SafeContainer<int>.Create(1);

            // Assert
            Assert.IsType<int>(container.Value);
        }

        [Fact]
        public void Create_NotSpecifyingType_Mathces()
        {
            // Arrange
            var container = SafeContainer.Create(1);

            // Assert
            Assert.IsType<int>(container.Value);
        }

        [Fact]
        public void Create_NotSpecifyingAbstractType_ConcreteTypeStored()
        {
            // Arange
            BaseClass value = new ConcreteClassA();
            var container = SafeContainer.Create(value);

            // Assert
            Assert.IsType<ConcreteClassA>(container.Value);
        }

        [Fact]
        public void Create_SpecifyingAbstractType_ConcreteTypeStored()
        {
            // Arrange
            BaseClass value = new ConcreteClassA();
            var container = SafeContainer<BaseClass>.Create(value);

            // Act
            Safe<BaseClass>.Against(container, x => x != null, new ConcreteClassB());

            // Assert
            Assert.IsType<ConcreteClassB>(container.Value);
        }
    }
}
