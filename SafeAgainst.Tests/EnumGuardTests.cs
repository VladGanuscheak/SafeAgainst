using Xunit;

namespace SafeAgainst.Tests
{
    public class EnumGuardTests
    {
        internal enum PowerOfTwo
        {
            One = 1,
            Two = 2,
            Four = 4,
            Eight = 8,
            Sixteen = 16
        };

        #region AgainstNotInRange

        [Fact]
        public void AgainstNotInRange_NotInRangeCheckByReferenceValue_Modified()
        {
            // Arrange
            PowerOfTwo powerOfTwo = default;
            var initialValue = powerOfTwo;

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNotInRange(ref powerOfTwo, PowerOfTwo.One);

            // Assert
            Assert.True(initialValue == 0);
            Assert.Equal(powerOfTwo, PowerOfTwo.One);
        }

        [Fact]
        public void AgainstNotInRange_InRangeCheckByReferenceValue_NotModified()
        {
            // Arrange
            PowerOfTwo powerOfTwo = PowerOfTwo.Two;
            var initialValue = powerOfTwo;

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNotInRange(ref powerOfTwo, PowerOfTwo.One);

            // Assert
            Assert.Equal(PowerOfTwo.Two, initialValue);
            Assert.Equal(PowerOfTwo.Two, powerOfTwo);
        }

        [Fact]
        public void AgainstNotInRange_NotInRangeCheckByContainer_Modified()
        {
            // Arrange
            PowerOfTwo powerOfTwo = default;
            var initialValue = powerOfTwo;
            var container = SafeContainer<PowerOfTwo>.Create(powerOfTwo);

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNotInRange(container, PowerOfTwo.One);
            powerOfTwo = container.Value;

            // Assert
            Assert.True(initialValue == 0);
            Assert.Equal(PowerOfTwo.One, powerOfTwo);
        }

        [Fact]
        public void AgainstNotInRange_InRangeCheckByContainer_NotModified()
        {
            // Arrange
            PowerOfTwo powerOfTwo = PowerOfTwo.Four;
            var initialValue = powerOfTwo;
            var container = SafeContainer<PowerOfTwo>.Create(powerOfTwo);

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNotInRange(container, PowerOfTwo.Sixteen);
            powerOfTwo = container.Value;

            // Assert
            Assert.Equal(PowerOfTwo.Four, initialValue);
            Assert.Equal(PowerOfTwo.Four, powerOfTwo);
        }

        #endregion

        #region AgainstNotInRangeOrNull

        [Fact]
        public void AgainstNotInRangeOrNull_NullCheckByRefence_Modified()
        {
            // Arrange
            PowerOfTwo? value = null;

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNullOrNotInRange(ref value, PowerOfTwo.One);

            // Assert
            Assert.NotNull(value);
            Assert.Equal(PowerOfTwo.One, value);
        }

        [Fact]
        public void AgainstNotInRangeOrNull_NotInRangeCheckByRefence_Modified()
        {
            // Arrange
            PowerOfTwo? value = 0;

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNullOrNotInRange(ref value, PowerOfTwo.Two);

            // Assert
            Assert.NotNull(value);
            Assert.Equal(PowerOfTwo.Two, value);
        }

        [Fact]
        public void AgainstNotInRangeOrNull_InRangeCheckByRefence_Modified()
        {
            // Arrange
            PowerOfTwo? value = PowerOfTwo.Sixteen;

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNullOrNotInRange(ref value, PowerOfTwo.Two);

            // Assert
            Assert.NotNull(value);
            Assert.Equal(PowerOfTwo.Sixteen, value);
        }

        [Fact]
        public void AgainstNotInRangeOrNull_NullCheckByContainer_Modified()
        {
            // Arrange
            PowerOfTwo? value = null;
            var container = SafeContainer.Create(value);

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNullOrNotInRange(container, PowerOfTwo.One);
            value = container.Value;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(PowerOfTwo.One, value);
        }

        [Fact]
        public void AgainstNotInRangeOrNull_NotInRangeCheckByContainer_Modified()
        {
            // Arrange
            PowerOfTwo? value = 0;
            var container = SafeContainer.Create(value);

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNullOrNotInRange(container, PowerOfTwo.Two);
            value = container.Value;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(PowerOfTwo.Two, value);
        }

        [Fact]
        public void AgainstNotInRangeOrNull_InRangeCheckByContainer_Modified()
        {
            // Arrange
            PowerOfTwo? value = PowerOfTwo.Sixteen;
            var container = SafeContainer.Create(value);

            // Act
            EnumGuards.Safe<PowerOfTwo>.AgainstNullOrNotInRange(container, PowerOfTwo.Two);
            value = container.Value;

            // Assert
            Assert.NotNull(value);
            Assert.Equal(PowerOfTwo.Sixteen, value);
        }

        #endregion
    }
}
