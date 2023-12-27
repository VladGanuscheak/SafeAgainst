using Xunit;

namespace SafeAgainst.Tests
{
    public class NumericGuardTests
    {
        #region AgainstNegative

        [Fact]
        public void AgainstNegative_NonNegativeCheckByReference_NotModified()
        {
            // Arrange
            decimal decimalValue = 1;
            var decimalInitialValue = decimalValue;

            double doubleValue = 1;
            var doubleInitialValue = doubleValue;

            float floatValue = 1;
            var floatInitialValue = floatValue;

            int intValue = 1;
            var intInitialValue = intValue;

            long longValue = 1;
            var longInitialValue = longValue;

            sbyte sbyteValue = 1;
            var sbyteInitialValue = sbyteValue;

            short shortValue = 1;
            var shortInitialValue = shortValue;

            // Act
            NumericGuards.Decimal.Safe.AgainstNegative(ref decimalValue, 0);
            NumericGuards.Double.Safe.AgainstNegative(ref doubleValue, 0);
            NumericGuards.Float.Safe.AgainstNegative(ref floatValue, 0);
            NumericGuards.Int.Safe.AgainstNegative(ref intValue, 0);
            NumericGuards.Long.Safe.AgainstNegative(ref longValue, 0);
            NumericGuards.Sbyte.Safe.AgainstNegative(ref sbyteValue, 0);
            NumericGuards.Short.Safe.AgainstNegative(ref shortValue, 0);

            // Assert
            Assert.Equal(1, decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Equal(1, doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Equal(1, floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Equal(1, intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Equal(1, longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Equal(1, sbyteInitialValue);
            Assert.Equal(1, sbyteValue);

            Assert.Equal(1, shortInitialValue);
            Assert.Equal(1, shortValue);
        }

        [Fact]
        public void AgainstNegative_NegativeCheckByReference_Modified()
        {
            // Arrange
            decimal decimalValue = -1;
            var decimalInitialValue = decimalValue;

            double doubleValue = -1;
            var doubleInitialValue = doubleValue;

            float floatValue = -1;
            var floatInitialValue = floatValue;

            int intValue = -1;
            var intInitialValue = intValue;

            long longValue = -1;
            var longInitialValue = longValue;

            sbyte sbyteValue = -1;
            var sbyteInitialValue = sbyteValue;

            short shortValue = -1;
            var shortInitialValue = shortValue;

            // Act
            NumericGuards.Decimal.Safe.AgainstNegative(ref decimalValue, 0);
            NumericGuards.Double.Safe.AgainstNegative(ref doubleValue, 0);
            NumericGuards.Float.Safe.AgainstNegative(ref floatValue, 0);
            NumericGuards.Int.Safe.AgainstNegative(ref intValue, 0);
            NumericGuards.Long.Safe.AgainstNegative(ref longValue, 0);
            NumericGuards.Sbyte.Safe.AgainstNegative(ref sbyteValue, 0);
            NumericGuards.Short.Safe.AgainstNegative(ref shortValue, 0);

            // Assert
            Assert.Equal(-1, decimalInitialValue);
            Assert.Equal(0, decimalValue);

            Assert.Equal(-1, doubleInitialValue);
            Assert.Equal(0, doubleValue);

            Assert.Equal(-1, floatInitialValue);
            Assert.Equal(0, floatValue);

            Assert.Equal(-1, intInitialValue);
            Assert.Equal(0, intValue);

            Assert.Equal(-1, longInitialValue);
            Assert.Equal(0, longValue);

            Assert.Equal(-1, sbyteInitialValue);
            Assert.Equal(0, sbyteValue);

            Assert.Equal(-1, shortInitialValue);
            Assert.Equal(0, shortValue);
        }

        [Fact]
        public void AgainstNegative_NonNegativeCheckByContainer_NotModified()
        {
            // Arrange
            decimal decimalValue = 1;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double doubleValue = 1;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float floatValue = 1;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int intValue = 1;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long longValue = 1;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte sbyteValue = 1;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short shortValue = 1;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            // Act
            NumericGuards.Decimal.Safe.AgainstNegative(decimalContainer, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNegative(doubleContainer, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNegative(floatContainer, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNegative(intContainer, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNegative(longContainer, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNegative(sbyteContainer, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNegative(shortContainer, 0);
            shortValue = shortContainer.Value;

            // Assert
            Assert.Equal(1, decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Equal(1, doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Equal(1, floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Equal(1, intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Equal(1, longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Equal(1, sbyteInitialValue);
            Assert.Equal(1, sbyteValue);

            Assert.Equal(1, shortInitialValue);
            Assert.Equal(1, shortValue);
        }

        [Fact]
        public void AgainstNegative_NegativeCheckByContainer_Modified()
        {
            // Arrange
            decimal decimalValue = -1;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double doubleValue = -1;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float floatValue = -1;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int intValue = -1;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long longValue = -1;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte sbyteValue = -1;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short shortValue = -1;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            // Act
            NumericGuards.Decimal.Safe.AgainstNegative(decimalContainer, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNegative(doubleContainer, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNegative(floatContainer, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNegative(intContainer, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNegative(longContainer, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNegative(sbyteContainer, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNegative(shortContainer, 0);
            shortValue = shortContainer.Value;

            // Assert
            Assert.Equal(-1, decimalInitialValue);
            Assert.Equal(0, decimalValue);

            Assert.Equal(-1, doubleInitialValue);
            Assert.Equal(0, doubleValue);

            Assert.Equal(-1, floatInitialValue);
            Assert.Equal(0, floatValue);

            Assert.Equal(-1, intInitialValue);
            Assert.Equal(0, intValue);

            Assert.Equal(-1, longInitialValue);
            Assert.Equal(0, longValue);

            Assert.Equal(-1, sbyteInitialValue);
            Assert.Equal(0, sbyteValue);

            Assert.Equal(-1, shortInitialValue);
            Assert.Equal(0, shortValue);
        }

        #endregion

        #region AgainstNullOrNegative

        [Fact]
        public void AgainstNullOrNegative_NonNegativeCheckByReference_NotModified()
        {
            // Arrange
            decimal? decimalValue = 1;
            var decimalInitialValue = decimalValue;

            double? doubleValue = 1;
            var doubleInitialValue = doubleValue;

            float? floatValue = 1;
            var floatInitialValue = floatValue;

            int? intValue = 1;
            var intInitialValue = intValue;

            long? longValue = 1;
            var longInitialValue = longValue;

            sbyte? sbyteValue = 1;
            var sbyteInitialValue = sbyteValue;

            short? shortValue = 1;
            var shortInitialValue = shortValue;

            // Act
            NumericGuards.Decimal.Safe.AgainstNullOrNegative(ref decimalValue, 0);
            NumericGuards.Double.Safe.AgainstNullOrNegative(ref doubleValue, 0);
            NumericGuards.Float.Safe.AgainstNullOrNegative(ref floatValue, 0);
            NumericGuards.Int.Safe.AgainstNullOrNegative(ref intValue, 0);
            NumericGuards.Long.Safe.AgainstNullOrNegative(ref longValue, 0);
            NumericGuards.Sbyte.Safe.AgainstNullOrNegative(ref sbyteValue, 0);
            NumericGuards.Short.Safe.AgainstNullOrNegative(ref shortValue, 0);

            // Assert
            Assert.Equal(1, decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Equal(1, doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Equal(1, floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Equal(1, intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Equal(1, longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Equal((sbyte)1, sbyteInitialValue);
            Assert.Equal((sbyte)1, sbyteValue);

            Assert.Equal((short)1, shortInitialValue);
            Assert.Equal((short)1, shortValue);
        }

        [Fact]
        public void AgainstNullOrNegative_NegativeCheckByReference_Modified()
        {
            // Arrange
            decimal? decimalValue = -1;
            var decimalInitialValue = decimalValue;

            double? doubleValue = -1;
            var doubleInitialValue = doubleValue;

            float? floatValue = -1;
            var floatInitialValue = floatValue;

            int? intValue = -1;
            var intInitialValue = intValue;

            long? longValue = -1;
            var longInitialValue = longValue;

            sbyte? sbyteValue = -1;
            var sbyteInitialValue = sbyteValue;

            short? shortValue = -1;
            var shortInitialValue = shortValue;

            // Act
            NumericGuards.Decimal.Safe.AgainstNullOrNegative(ref decimalValue, 0);
            NumericGuards.Double.Safe.AgainstNullOrNegative(ref doubleValue, 0);
            NumericGuards.Float.Safe.AgainstNullOrNegative(ref floatValue, 0);
            NumericGuards.Int.Safe.AgainstNullOrNegative(ref intValue, 0);
            NumericGuards.Long.Safe.AgainstNullOrNegative(ref longValue, 0);
            NumericGuards.Sbyte.Safe.AgainstNullOrNegative(ref sbyteValue, 0);
            NumericGuards.Short.Safe.AgainstNullOrNegative(ref shortValue, 0);

            // Assert
            Assert.Equal(-1, decimalInitialValue);
            Assert.Equal(0, decimalValue);

            Assert.Equal(-1, doubleInitialValue);
            Assert.Equal(0, doubleValue);

            Assert.Equal(-1, floatInitialValue);
            Assert.Equal(0, floatValue);

            Assert.Equal(-1, intInitialValue);
            Assert.Equal(0, intValue);

            Assert.Equal(-1, longInitialValue);
            Assert.Equal(0, longValue);

            Assert.Equal((sbyte)-1, sbyteInitialValue);
            Assert.Equal((sbyte)0, sbyteValue);

            Assert.Equal((short)-1, shortInitialValue);
            Assert.Equal((short)0, shortValue);
        }

        [Fact]
        public void AgainstNullOrNegative_NullCheckByReference_Modified()
        {
            // Arrange
            decimal? decimalValue = null;
            var decimalInitialValue = decimalValue;

            double? doubleValue = null;
            var doubleInitialValue = doubleValue;

            float? floatValue = null;
            var floatInitialValue = floatValue;

            int? intValue = null;
            var intInitialValue = intValue;

            long? longValue = null;
            var longInitialValue = longValue;

            sbyte? sbyteValue = null;
            var sbyteInitialValue = sbyteValue;

            short? shortValue = null;
            var shortInitialValue = shortValue;

            // Act
            NumericGuards.Decimal.Safe.AgainstNullOrNegative(ref decimalValue, 0);
            NumericGuards.Double.Safe.AgainstNullOrNegative(ref doubleValue, 0);
            NumericGuards.Float.Safe.AgainstNullOrNegative(ref floatValue, 0);
            NumericGuards.Int.Safe.AgainstNullOrNegative(ref intValue, 0);
            NumericGuards.Long.Safe.AgainstNullOrNegative(ref longValue, 0);
            NumericGuards.Sbyte.Safe.AgainstNullOrNegative(ref sbyteValue, 0);
            NumericGuards.Short.Safe.AgainstNullOrNegative(ref shortValue, 0);

            // Assert
            Assert.Null(decimalInitialValue);
            Assert.Equal(0, decimalValue);

            Assert.Null(doubleInitialValue);
            Assert.Equal(0, doubleValue);

            Assert.Null(floatInitialValue);
            Assert.Equal(0, floatValue);

            Assert.Null(intInitialValue);
            Assert.Equal(0, intValue);

            Assert.Null(longInitialValue);
            Assert.Equal(0, longValue);

            Assert.Null(sbyteInitialValue);
            Assert.Equal((sbyte)0, sbyteValue);

            Assert.Null(shortInitialValue);
            Assert.Equal((short)0, shortValue);
        }

        [Fact]
        public void AgainstNullOrNegative_NonNegativeCheckByContainer_NotModified()
        {
            // Arrange
            decimal? decimalValue = 1;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double? doubleValue = 1;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float? floatValue = 1;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int? intValue = 1;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long? longValue = 1;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte? sbyteValue = 1;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short? shortValue = 1;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            // Act
            NumericGuards.Decimal.Safe.AgainstNullOrNegative(decimalContainer, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrNegative(doubleContainer, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrNegative(floatContainer, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrNegative(intContainer, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrNegative(longContainer, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrNegative(sbyteContainer, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrNegative(shortContainer, 0);
            shortValue = shortContainer.Value;

            // Assert
            Assert.Equal(1, decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Equal(1, doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Equal(1, floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Equal(1, intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Equal(1, longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Equal((sbyte)1, sbyteInitialValue);
            Assert.Equal((sbyte)1, sbyteValue);

            Assert.Equal((short)1, shortInitialValue);
            Assert.Equal((short)1, shortValue);
        }

        [Fact]
        public void AgainstNullOrNegative_NegativeCheckByContainer_Modified()
        {
            // Arrange
            decimal? decimalValue = -1;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double? doubleValue = -1;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float? floatValue = -1;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int? intValue = -1;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long? longValue = -1;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte? sbyteValue = -1;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short? shortValue = -1;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            // Act
            NumericGuards.Decimal.Safe.AgainstNullOrNegative(decimalContainer, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrNegative(doubleContainer, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrNegative(floatContainer, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrNegative(intContainer, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrNegative(longContainer, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrNegative(sbyteContainer, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrNegative(shortContainer, 0);
            shortValue = shortContainer.Value;

            // Assert
            Assert.Equal(-1, decimalInitialValue);
            Assert.Equal(0, decimalValue);

            Assert.Equal(-1, doubleInitialValue);
            Assert.Equal(0, doubleValue);

            Assert.Equal(-1, floatInitialValue);
            Assert.Equal(0, floatValue);

            Assert.Equal(-1, intInitialValue);
            Assert.Equal(0, intValue);

            Assert.Equal(-1, longInitialValue);
            Assert.Equal(0, longValue);

            Assert.Equal((sbyte)-1, sbyteInitialValue);
            Assert.Equal((sbyte)0, sbyteValue);

            Assert.Equal((short)-1, shortInitialValue);
            Assert.Equal((short)0, shortValue);
        }

        [Fact]
        public void AgainstNullOrNegative_NullCheckByContainer_Modified()
        {
            // Arrange
            decimal? decimalValue = null;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double? doubleValue = null;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float? floatValue = null;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int? intValue = null;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long? longValue = null;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte? sbyteValue = null;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short? shortValue = null;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            // Act
            NumericGuards.Decimal.Safe.AgainstNullOrNegative(decimalContainer, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrNegative(doubleContainer, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrNegative(floatContainer, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrNegative(intContainer, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrNegative(longContainer, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrNegative(sbyteContainer, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrNegative(shortContainer, 0);
            shortValue = shortContainer.Value;

            // Assert
            Assert.Null(decimalInitialValue);
            Assert.Equal(0, decimalValue);

            Assert.Null(doubleInitialValue);
            Assert.Equal(0, doubleValue);

            Assert.Null(floatInitialValue);
            Assert.Equal(0, floatValue);

            Assert.Null(intInitialValue);
            Assert.Equal(0, intValue);

            Assert.Null(longInitialValue);
            Assert.Equal(0, longValue);

            Assert.Null(sbyteInitialValue);
            Assert.Equal((sbyte)0, sbyteValue);

            Assert.Null(shortInitialValue);
            Assert.Equal((short)0, shortValue);
        }

        #endregion
    }
}
