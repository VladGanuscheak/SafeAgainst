using Xunit;

namespace SafeAgainst.Tests
{
    public class NonNegativeNumericGuardTests
    {
        #region AgainstZero

        [Fact]
        public void AgainstZero_ZeroCheckByReference_Modified()
        {
            // Arrange
            byte byteValue = default;
            var byteInitialValue = byteValue;

            decimal decimalValue = default;
            var decimalInitialValue = decimalValue;

            double doubleValue = default;
            var doubleInitialValue = doubleValue;

            float floatValue = default;
            var floatInitialValue = floatValue;

            int intValue = default;
            var intInitialValue = intValue;

            long longValue = default;
            var longInitialValue = longValue;

            sbyte sbyteValue = default;
            var sbyteInitialValue = sbyteValue;

            short shortValue = default;
            var shortInitialValue = shortValue;

            uint uintValue = default;
            var uintInitialValue = uintValue;

            ulong ulongValue = default;
            var ulongInitialValue = ulongValue;

            ushort ushortValue = default;
            var ushortInitialValue = ushortValue;

            // Act
            NumericGuards.Byte.Safe.AgainstZero(ref byteValue, 1);
            NumericGuards.Decimal.Safe.AgainstZero(ref decimalValue, 1);
            NumericGuards.Double.Safe.AgainstZero(ref doubleValue, 1);
            NumericGuards.Float.Safe.AgainstZero(ref floatValue, 1);
            NumericGuards.Int.Safe.AgainstZero(ref intValue, 1);
            NumericGuards.Long.Safe.AgainstZero(ref longValue, 1);
            NumericGuards.Sbyte.Safe.AgainstZero(ref sbyteValue, 1);
            NumericGuards.Short.Safe.AgainstZero(ref shortValue, 1);
            NumericGuards.Uint.Safe.AgainstZero(ref uintValue, 1);
            NumericGuards.Ulong.Safe.AgainstZero(ref ulongValue, 1);
            NumericGuards.Ushort.Safe.AgainstZero(ref ushortValue, 1);

            // Assert
            Assert.Equal(0, byteInitialValue);
            Assert.Equal(1, byteValue);

            Assert.Equal(0, decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Equal(0, doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Equal(0, floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Equal(0, intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Equal(0, longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Equal(0, sbyteInitialValue);
            Assert.Equal(1, sbyteValue);

            Assert.Equal(0, shortInitialValue);
            Assert.Equal(1, shortValue);

            Assert.Equal(0u, uintInitialValue);
            Assert.Equal(1u, uintValue);

            Assert.Equal(0ul, ulongInitialValue);
            Assert.Equal(1ul, ulongValue);

            Assert.Equal(0, ushortInitialValue);
            Assert.Equal(1, ushortValue);
        }

        [Fact]
        public void AgainstZero_NotZeroCheckByReference_NotModified()
        {
            // Arrange
            byte byteValue = 1;
            decimal decimalValue = 1;
            double doubleValue = 1;
            float floatValue = 1;
            int intValue = 1;
            long longValue = 1;
            sbyte sbyteValue = 1;
            short shortValue = 1;
            uint uintValue = 1;
            ulong ulongValue = 1;
            ushort ushortValue = 1;

            // Act
            NumericGuards.Byte.Safe.AgainstZero(ref byteValue, 2);
            NumericGuards.Decimal.Safe.AgainstZero(ref decimalValue, 2);
            NumericGuards.Double.Safe.AgainstZero(ref doubleValue, 2);
            NumericGuards.Float.Safe.AgainstZero(ref floatValue, 2);
            NumericGuards.Int.Safe.AgainstZero(ref intValue, 2);
            NumericGuards.Long.Safe.AgainstZero(ref longValue, 2);
            NumericGuards.Sbyte.Safe.AgainstZero(ref sbyteValue, 2);
            NumericGuards.Short.Safe.AgainstZero(ref shortValue, 2);
            NumericGuards.Uint.Safe.AgainstZero(ref uintValue, 2);
            NumericGuards.Ulong.Safe.AgainstZero(ref ulongValue, 2);
            NumericGuards.Ushort.Safe.AgainstZero(ref ushortValue, 2);

            // Assert
            Assert.Equal(1, byteValue);
            Assert.Equal(1, decimalValue);
            Assert.Equal(1, doubleValue);
            Assert.Equal(1, floatValue);
            Assert.Equal(1, intValue);
            Assert.Equal(1, longValue);
            Assert.Equal(1, sbyteValue);
            Assert.Equal(1, shortValue);
            Assert.Equal(1u, uintValue);
            Assert.Equal(1ul, ulongValue);
            Assert.Equal(1, ushortValue);
        }

        [Fact]
        public void AgainstZero_ZeroCheckByContainer_Modified()
        {
            // Arrange
            byte byteValue = default;
            var byteInitialValue = byteValue;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal decimalValue = default;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double doubleValue = default;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float floatValue = default;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int intValue = default;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long longValue = default;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte sbyteValue = default;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short shortValue = default;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            uint uintValue = default;
            var uintInitialValue = uintValue;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong ulongValue = default;
            var ulongInitialValue = ulongValue;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort ushortValue = default;
            var ushortInitialValue = ushortValue;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstZero(byteContainer, 1);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstZero(decimalContainer, 1);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstZero(doubleContainer, 1);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstZero(floatContainer, 1);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstZero(intContainer, 1);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstZero(longContainer, 1);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstZero(sbyteContainer, 1);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstZero(shortContainer, 1);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstZero(uintContainer, 1);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstZero(ulongContainer, 1);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstZero(ushortContainer, 1);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.Equal(0, byteInitialValue);
            Assert.Equal(1, byteValue);

            Assert.Equal(0, decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Equal(0, doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Equal(0, floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Equal(0, intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Equal(0, longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Equal(0, sbyteInitialValue);
            Assert.Equal(1, sbyteValue);

            Assert.Equal(0, shortInitialValue);
            Assert.Equal(1, shortValue);

            Assert.Equal(0u, uintInitialValue);
            Assert.Equal(1u, uintValue);

            Assert.Equal(0ul, ulongInitialValue);
            Assert.Equal(1ul, ulongValue);

            Assert.Equal(0, ushortInitialValue);
            Assert.Equal(1, ushortValue);
        }

        [Fact]
        public void AgainstZero_NotZeroCheckByContainer_NotModified()
        {
            // Arrange
            byte byteValue = 1;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal decimalValue = 1;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double doubleValue = 1;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float floatValue = 1;
            var floatContainer = SafeContainer.Create(floatValue);

            int intValue = 1;
            var intContainer = SafeContainer.Create(intValue);

            long longValue = 1;
            var longContainer = SafeContainer.Create(longValue);

            sbyte sbyteValue = 1;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short shortValue = 1;
            var shortContainer = SafeContainer.Create(shortValue);

            uint uintValue = 1;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong ulongValue = 1;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort ushortValue = 1;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstZero(byteContainer, 2);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstZero(decimalContainer, 2);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstZero(doubleContainer, 2);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstZero(floatContainer, 2);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstZero(intContainer, 2);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstZero(longContainer, 2);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstZero(sbyteContainer, 2);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstZero(shortContainer, 2);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstZero(uintContainer, 2);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstZero(ulongContainer, 2);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstZero(ushortContainer, 2);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.Equal(1, byteValue);
            Assert.Equal(1, decimalValue);
            Assert.Equal(1, doubleValue);
            Assert.Equal(1, floatValue);
            Assert.Equal(1, intValue);
            Assert.Equal(1, longValue);
            Assert.Equal(1, sbyteValue);
            Assert.Equal(1, shortValue);
            Assert.Equal(1u, uintValue);
            Assert.Equal(1ul, ulongValue);
            Assert.Equal(1, ushortValue);
        }

        #endregion

        #region AgainstNotInRange

        [Fact]
        public void AgainstNotInRange_NotInRangeCheckByReference_Modified()
        {
            // Arrange
            byte byteValue = 10;
            var byteInitialValue = byteValue;

            decimal decimalValue = 10;
            var decimalInitialValue = decimalValue;

            double doubleValue = 10;
            var doubleInitialValue = doubleValue;

            float floatValue = 10;
            var floatInitialValue = floatValue;

            int intValue = 10;
            var intInitialValue = intValue;

            long longValue = 10;
            var longInitialValue = longValue;

            sbyte sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;

            short shortValue = 10;
            var shortInitialValue = shortValue;

            uint uintValue = 10;
            var uintInitialValue = uintValue;

            ulong ulongValue = 10;
            var ulongInitialValue = ulongValue;

            ushort ushortValue = 10;
            var ushortInitialValue = ushortValue;

            // Act
            NumericGuards.Byte.Safe.AgainstNotInRange(ref byteValue, 0, 9, 0);
            NumericGuards.Decimal.Safe.AgainstNotInRange(ref decimalValue, 0, 9, 0);
            NumericGuards.Double.Safe.AgainstNotInRange(ref doubleValue, 0, 9, 0);
            NumericGuards.Float.Safe.AgainstNotInRange(ref floatValue, 0, 9, 0);
            NumericGuards.Int.Safe.AgainstNotInRange(ref intValue, 0, 9, 0);
            NumericGuards.Long.Safe.AgainstNotInRange(ref longValue, 0, 9, 0);
            NumericGuards.Sbyte.Safe.AgainstNotInRange(ref sbyteValue, 0, 9, 0);
            NumericGuards.Short.Safe.AgainstNotInRange(ref shortValue, 0, 9, 0);
            NumericGuards.Uint.Safe.AgainstNotInRange(ref uintValue, 0, 9, 0);
            NumericGuards.Ulong.Safe.AgainstNotInRange(ref ulongValue, 0, 9, 0);
            NumericGuards.Ushort.Safe.AgainstNotInRange(ref ushortValue, 0, 9, 0);

            // Assert
            Assert.NotInRange(byteInitialValue, 0, 9);
            Assert.Equal(0, byteValue);

            Assert.NotInRange(decimalInitialValue, 0, 9);
            Assert.Equal(0, decimalValue);

            Assert.NotInRange(doubleInitialValue, 0, 9);
            Assert.Equal(0, doubleValue);

            Assert.NotInRange(floatInitialValue, 0, 9);
            Assert.Equal(0, floatValue);

            Assert.NotInRange(intInitialValue, 0, 9);
            Assert.Equal(0, intValue);

            Assert.NotInRange(longInitialValue, 0, 9);
            Assert.Equal(0, longValue);

            Assert.NotInRange(sbyteInitialValue, 0, 9);
            Assert.Equal(0, sbyteValue);

            Assert.NotInRange(shortInitialValue, 0, 9);
            Assert.Equal(0, shortValue);

            Assert.NotInRange(uintInitialValue, 0u, 9u);
            Assert.Equal(0u, uintValue);

            Assert.NotInRange(ulongInitialValue, 0ul, 9ul);
            Assert.Equal(0ul, ulongValue);

            Assert.NotInRange(ushortInitialValue, 0, 9);
            Assert.Equal(0, ushortValue);
        }

        [Fact]
        public void AgainstNotInRange_InRangeCheckByReference_NotModified()
        {
            // Arrange
            byte byteValue = 10;
            var byteInitialValue = byteValue;

            decimal decimalValue = 10;
            var decimalInitialValue = decimalValue;

            double doubleValue = 10;
            var doubleInitialValue = doubleValue;

            float floatValue = 10;
            var floatInitialValue = floatValue;

            int intValue = 10;
            var intInitialValue = intValue;

            long longValue = 10;
            var longInitialValue = longValue;

            sbyte sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;

            short shortValue = 10;
            var shortInitialValue = shortValue;

            uint uintValue = 10;
            var uintInitialValue = uintValue;

            ulong ulongValue = 10;
            var ulongInitialValue = ulongValue;

            ushort ushortValue = 10;
            var ushortInitialValue = ushortValue;

            // Act
            NumericGuards.Byte.Safe.AgainstNotInRange(ref byteValue, 0, 10, 0);
            NumericGuards.Decimal.Safe.AgainstNotInRange(ref decimalValue, 0, 10, 0);
            NumericGuards.Double.Safe.AgainstNotInRange(ref doubleValue, 0, 10, 0);
            NumericGuards.Float.Safe.AgainstNotInRange(ref floatValue, 0, 10, 0);
            NumericGuards.Int.Safe.AgainstNotInRange(ref intValue, 0, 10, 0);
            NumericGuards.Long.Safe.AgainstNotInRange(ref longValue, 0, 10, 0);
            NumericGuards.Sbyte.Safe.AgainstNotInRange(ref sbyteValue, 0, 10, 0);
            NumericGuards.Short.Safe.AgainstNotInRange(ref shortValue, 0, 10, 0);
            NumericGuards.Uint.Safe.AgainstNotInRange(ref uintValue, 0, 10, 0);
            NumericGuards.Ulong.Safe.AgainstNotInRange(ref ulongValue, 0, 10, 0);
            NumericGuards.Ushort.Safe.AgainstNotInRange(ref ushortValue, 0, 10, 0);

            // Assert
            Assert.InRange(byteInitialValue, 0, 10);
            Assert.Equal(10, byteValue);

            Assert.InRange(decimalInitialValue, 0, 10);
            Assert.Equal(10, decimalValue);

            Assert.InRange(doubleInitialValue, 0, 10);
            Assert.Equal(10, doubleValue);

            Assert.InRange(floatInitialValue, 0, 10);
            Assert.Equal(10, floatValue);

            Assert.InRange(intInitialValue, 0, 10);
            Assert.Equal(10, intValue);

            Assert.InRange(longInitialValue, 0, 10);
            Assert.Equal(10, longValue);

            Assert.InRange(sbyteInitialValue, 0, 10);
            Assert.Equal(10, sbyteValue);

            Assert.InRange(shortInitialValue, 0, 10);
            Assert.Equal(10, shortValue);

            Assert.InRange(uintInitialValue, 0u, 10u);
            Assert.Equal(10u, uintValue);

            Assert.InRange(ulongInitialValue, 0ul, 10ul);
            Assert.Equal(10ul, ulongValue);

            Assert.InRange(ushortInitialValue, 0, 10);
            Assert.Equal(10, ushortValue);
        }

        [Fact]
        public void AgainstNotInRange_NotInRangeCheckByContainer_Modified()
        {
            // Arrange
            byte byteValue = 10;
            var byteInitialValue = byteValue;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal decimalValue = 10;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double doubleValue = 10;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float floatValue = 10;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int intValue = 10;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long longValue = 10;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short shortValue = 10;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            uint uintValue = 10;
            var uintInitialValue = uintValue;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong ulongValue = 10;
            var ulongInitialValue = ulongValue;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort ushortValue = 10;
            var ushortInitialValue = ushortValue;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstNotInRange(byteContainer, 0, 9, 0);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstNotInRange(decimalContainer, 0, 9, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNotInRange(doubleContainer, 0, 9, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNotInRange(floatContainer, 0, 9, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNotInRange(intContainer, 0, 9, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNotInRange(longContainer, 0, 9, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNotInRange(sbyteContainer, 0, 9, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNotInRange(shortContainer, 0, 9, 0);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstNotInRange(uintContainer, 0, 9, 0);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstNotInRange(ulongContainer, 0, 9, 0);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstNotInRange(ushortContainer, 0, 9, 0);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.NotInRange(byteInitialValue, 0, 9);
            Assert.Equal(0, byteValue);

            Assert.NotInRange(decimalInitialValue, 0, 9);
            Assert.Equal(0, decimalValue);

            Assert.NotInRange(doubleInitialValue, 0, 9);
            Assert.Equal(0, doubleValue);

            Assert.NotInRange(floatInitialValue, 0, 9);
            Assert.Equal(0, floatValue);

            Assert.NotInRange(intInitialValue, 0, 9);
            Assert.Equal(0, intValue);

            Assert.NotInRange(longInitialValue, 0, 9);
            Assert.Equal(0, longValue);

            Assert.NotInRange(sbyteInitialValue, 0, 9);
            Assert.Equal(0, sbyteValue);

            Assert.NotInRange(shortInitialValue, 0, 9);
            Assert.Equal(0, shortValue);

            Assert.NotInRange(uintInitialValue, 0u, 9u);
            Assert.Equal(0u, uintValue);

            Assert.NotInRange(ulongInitialValue, 0ul, 9ul);
            Assert.Equal(0ul, ulongValue);

            Assert.NotInRange(ushortInitialValue, 0, 9);
            Assert.Equal(0, ushortValue);
        }

        [Fact]
        public void AgainstNotInRange_InRangeCheckByContainer_NotModified()
        {
            // Arrange
            byte byteValue = 10;
            var byteInitialValue = byteValue;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal decimalValue = 10;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double doubleValue = 10;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float floatValue = 10;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int intValue = 10;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long longValue = 10;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short shortValue = 10;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            uint uintValue = 10;
            var uintInitialValue = uintValue;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong ulongValue = 10;
            var ulongInitialValue = ulongValue;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort ushortValue = 10;
            var ushortInitialValue = ushortValue;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstNotInRange(ref byteValue, 0, 10, 0);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstNotInRange(ref decimalValue, 0, 10, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNotInRange(ref doubleValue, 0, 10, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNotInRange(ref floatValue, 0, 10, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNotInRange(ref intValue, 0, 10, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNotInRange(ref longValue, 0, 10, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNotInRange(ref sbyteValue, 0, 10, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNotInRange(ref shortValue, 0, 10, 0);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstNotInRange(ref uintValue, 0, 10, 0);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstNotInRange(ref ulongValue, 0, 10, 0);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstNotInRange(ref ushortValue, 0, 10, 0);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.InRange(byteInitialValue, 0, 10);
            Assert.Equal(10, byteValue);

            Assert.InRange(decimalInitialValue, 0, 10);
            Assert.Equal(10, decimalValue);

            Assert.InRange(doubleInitialValue, 0, 10);
            Assert.Equal(10, doubleValue);

            Assert.InRange(floatInitialValue, 0, 10);
            Assert.Equal(10, floatValue);

            Assert.InRange(intInitialValue, 0, 10);
            Assert.Equal(10, intValue);

            Assert.InRange(longInitialValue, 0, 10);
            Assert.Equal(10, longValue);

            Assert.InRange(sbyteInitialValue, 0, 10);
            Assert.Equal(10, sbyteValue);

            Assert.InRange(shortInitialValue, 0, 10);
            Assert.Equal(10, shortValue);

            Assert.InRange(uintInitialValue, 0u, 10u);
            Assert.Equal(10u, uintValue);

            Assert.InRange(ulongInitialValue, 0ul, 10ul);
            Assert.Equal(10ul, ulongValue);

            Assert.InRange(ushortInitialValue, 0, 10);
            Assert.Equal(10, ushortValue);
        }

        #endregion

        #region AgainstNullOrZero

        [Fact]
        public void AgainstNullOrZero_ZeroCheckByReference_Modified()
        {
            // Arrange
            byte? byteValue = 0;
            var byteInitialValue = byteValue;

            decimal? decimalValue = 0;
            var decimalInitialValue = decimalValue;

            double? doubleValue = 0;
            var doubleInitialValue = doubleValue;

            float? floatValue = 0;
            var floatInitialValue = floatValue;

            int? intValue = 0;
            var intInitialValue = intValue;

            long? longValue = 0;
            var longInitialValue = longValue;

            sbyte? sbyteValue = 0;
            var sbyteInitialValue = sbyteValue;

            short? shortValue = 0;
            var shortInitialValue = shortValue;

            uint? uintValue = 0;
            var uintInitialValue = uintValue;

            ulong? ulongValue = 0;
            var ulongInitialValue = ulongValue;

            ushort? ushortValue = 0;
            var ushortInitialValue = ushortValue;

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrZero(ref byteValue, 1);
            NumericGuards.Decimal.Safe.AgainstNullOrZero(ref decimalValue, 1);
            NumericGuards.Double.Safe.AgainstNullOrZero(ref doubleValue, 1);
            NumericGuards.Float.Safe.AgainstNullOrZero(ref floatValue, 1);
            NumericGuards.Int.Safe.AgainstNullOrZero(ref intValue, 1);
            NumericGuards.Long.Safe.AgainstNullOrZero(ref longValue, 1);
            NumericGuards.Sbyte.Safe.AgainstNullOrZero(ref sbyteValue, 1);
            NumericGuards.Short.Safe.AgainstNullOrZero(ref shortValue, 1);
            NumericGuards.Uint.Safe.AgainstNullOrZero(ref uintValue, 1);
            NumericGuards.Ulong.Safe.AgainstNullOrZero(ref ulongValue, 1);
            NumericGuards.Ushort.Safe.AgainstNullOrZero(ref ushortValue, 1);

            // Assert
            Assert.Equal((byte)0, byteInitialValue);
            Assert.Equal((byte)1, byteValue);

            Assert.Equal(0, decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Equal(0, doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Equal(0, floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Equal(0, intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Equal(0, longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Equal((sbyte)0, sbyteInitialValue);
            Assert.Equal((sbyte)1, sbyteValue);

            Assert.Equal((short)0, shortInitialValue);
            Assert.Equal((short)1, shortValue);

            Assert.Equal(0u, uintInitialValue);
            Assert.Equal(1u, uintValue);

            Assert.Equal(0ul, ulongInitialValue);
            Assert.Equal(1ul, ulongValue);

            Assert.Equal((ushort)0, ushortInitialValue);
            Assert.Equal((ushort)1, ushortValue);
        }

        [Fact]
        public void AgainstNullOrZero_NotZeroCheckByReference_NotModified()
        {
            // Arrange
            byte? byteValue = 1;
            decimal? decimalValue = 1;
            double? doubleValue = 1;
            float? floatValue = 1;
            int? intValue = 1;
            long? longValue = 1;
            sbyte? sbyteValue = 1;
            short? shortValue = 1;
            uint? uintValue = 1;
            ulong? ulongValue = 1;
            ushort? ushortValue = 1;

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrZero(ref byteValue, 2);
            NumericGuards.Decimal.Safe.AgainstNullOrZero(ref decimalValue, 2);
            NumericGuards.Double.Safe.AgainstNullOrZero(ref doubleValue, 2);
            NumericGuards.Float.Safe.AgainstNullOrZero(ref floatValue, 2);
            NumericGuards.Int.Safe.AgainstNullOrZero(ref intValue, 2);
            NumericGuards.Long.Safe.AgainstNullOrZero(ref longValue, 2);
            NumericGuards.Sbyte.Safe.AgainstNullOrZero(ref sbyteValue, 2);
            NumericGuards.Short.Safe.AgainstNullOrZero(ref shortValue, 2);
            NumericGuards.Uint.Safe.AgainstNullOrZero(ref uintValue, 2);
            NumericGuards.Ulong.Safe.AgainstNullOrZero(ref ulongValue, 2);
            NumericGuards.Ushort.Safe.AgainstNullOrZero(ref ushortValue, 2);

            // Assert
            Assert.Equal((byte)1, byteValue);
            Assert.Equal(1, decimalValue);
            Assert.Equal(1, doubleValue);
            Assert.Equal(1, floatValue);
            Assert.Equal(1, intValue);
            Assert.Equal(1, longValue);
            Assert.Equal((sbyte)1, sbyteValue);
            Assert.Equal((short)1, shortValue);
            Assert.Equal(1u, uintValue);
            Assert.Equal(1ul, ulongValue);
            Assert.Equal((ushort)1, ushortValue);
        }

        [Fact]
        public void AgainstNullOrZero_NullCheckByReference_Modified()
        {
            // Arrange
            byte? byteValue = null;
            decimal? decimalValue = null;
            double? doubleValue = null;
            float? floatValue = null;
            int? intValue = null;
            long? longValue = null;
            sbyte? sbyteValue = null;
            short? shortValue = null;
            uint? uintValue = null;
            ulong? ulongValue = null;
            ushort? ushortValue = null;

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrZero(ref byteValue, 2);
            NumericGuards.Decimal.Safe.AgainstNullOrZero(ref decimalValue, 2);
            NumericGuards.Double.Safe.AgainstNullOrZero(ref doubleValue, 2);
            NumericGuards.Float.Safe.AgainstNullOrZero(ref floatValue, 2);
            NumericGuards.Int.Safe.AgainstNullOrZero(ref intValue, 2);
            NumericGuards.Long.Safe.AgainstNullOrZero(ref longValue, 2);
            NumericGuards.Sbyte.Safe.AgainstNullOrZero(ref sbyteValue, 2);
            NumericGuards.Short.Safe.AgainstNullOrZero(ref shortValue, 2);
            NumericGuards.Uint.Safe.AgainstNullOrZero(ref uintValue, 2);
            NumericGuards.Ulong.Safe.AgainstNullOrZero(ref ulongValue, 2);
            NumericGuards.Ushort.Safe.AgainstNullOrZero(ref ushortValue, 2);

            // Assert
            Assert.Equal((byte)2, byteValue);
            Assert.Equal(2, decimalValue);
            Assert.Equal(2, doubleValue);
            Assert.Equal(2, floatValue);
            Assert.Equal(2, intValue);
            Assert.Equal(2, longValue);
            Assert.Equal((sbyte)2, sbyteValue);
            Assert.Equal((short)2, shortValue);
            Assert.Equal(2u, uintValue);
            Assert.Equal(2ul, ulongValue);
            Assert.Equal((ushort)2, ushortValue);
        }

        [Fact]
        public void AgainstNullOrZero_ZeroCheckByContainer_Modified()
        {
            // Arrange
            byte? byteValue = null;
            var byteInitialValue = byteValue;
            var byteContainer = SafeContainer.Create(byteValue);

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

            uint? uintValue = null;
            var uintInitialValue = uintValue;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong? ulongValue = null;
            var ulongInitialValue = ulongValue;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort? ushortValue = null;
            var ushortInitialValue = ushortValue;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrZero(byteContainer, 1);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstNullOrZero(decimalContainer, 1);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrZero(doubleContainer, 1);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrZero(floatContainer, 1);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrZero(intContainer, 1);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrZero(longContainer, 1);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrZero(sbyteContainer, 1);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrZero(shortContainer, 1);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstNullOrZero(uintContainer, 1);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstNullOrZero(ulongContainer, 1);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstNullOrZero(ushortContainer, 1);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.Null(byteInitialValue);
            Assert.Equal((byte)1, byteValue);

            Assert.Null(decimalInitialValue);
            Assert.Equal(1, decimalValue);

            Assert.Null(doubleInitialValue);
            Assert.Equal(1, doubleValue);

            Assert.Null(floatInitialValue);
            Assert.Equal(1, floatValue);

            Assert.Null(intInitialValue);
            Assert.Equal(1, intValue);

            Assert.Null(longInitialValue);
            Assert.Equal(1, longValue);

            Assert.Null(sbyteInitialValue);
            Assert.Equal((sbyte)1, sbyteValue);

            Assert.Null(shortInitialValue);
            Assert.Equal((short)1, shortValue);

            Assert.Null(uintInitialValue);
            Assert.Equal(1u, uintValue);

            Assert.Null(ulongInitialValue);
            Assert.Equal(1ul, ulongValue);

            Assert.Null(ushortInitialValue);
            Assert.Equal((ushort)1, ushortValue);
        }

        [Fact]
        public void AgainstNullOrZero_NotZeroCheckByContainer_NotModified()
        {
            // Arrange
            byte byteValue = 1;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal decimalValue = 1;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double doubleValue = 1;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float floatValue = 1;
            var floatContainer = SafeContainer.Create(floatValue);

            int intValue = 1;
            var intContainer = SafeContainer.Create(intValue);

            long longValue = 1;
            var longContainer = SafeContainer.Create(longValue);

            sbyte sbyteValue = 1;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short shortValue = 1;
            var shortContainer = SafeContainer.Create(shortValue);

            uint uintValue = 1;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong ulongValue = 1;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort ushortValue = 1;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstZero(byteContainer, 2);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstZero(decimalContainer, 2);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstZero(doubleContainer, 2);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstZero(floatContainer, 2);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstZero(intContainer, 2);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstZero(longContainer, 2);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstZero(sbyteContainer, 2);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstZero(shortContainer, 2);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstZero(uintContainer, 2);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstZero(ulongContainer, 2);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstZero(ushortContainer, 2);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.Equal(1, byteValue);
            Assert.Equal(1, decimalValue);
            Assert.Equal(1, doubleValue);
            Assert.Equal(1, floatValue);
            Assert.Equal(1, intValue);
            Assert.Equal(1, longValue);
            Assert.Equal(1, sbyteValue);
            Assert.Equal(1, shortValue);
            Assert.Equal(1u, uintValue);
            Assert.Equal(1ul, ulongValue);
            Assert.Equal(1, ushortValue);
        }

        [Fact]
        public void AgainstNullOrZero_NullCheckByContainer_Modified()
        {
            // Arrange
            byte? byteValue = null;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal? decimalValue = null;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double? doubleValue = null;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float? floatValue = null;
            var floatContainer = SafeContainer.Create(floatValue);

            int? intValue = null;
            var intContainer = SafeContainer.Create(intValue);

            long? longValue = null;
            var longContainer = SafeContainer.Create(longValue);

            sbyte? sbyteValue = null;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short? shortValue = null;
            var shortContainer = SafeContainer.Create(shortValue);

            uint? uintValue = null;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong? ulongValue = null;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort? ushortValue = null;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrZero(byteContainer, 2);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstNullOrZero(decimalContainer, 2);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrZero(doubleContainer, 2);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrZero(floatContainer, 2);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrZero(intContainer, 2);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrZero(longContainer, 2);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrZero(sbyteContainer, 2);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrZero(shortContainer, 2);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstNullOrZero(uintContainer, 2);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstNullOrZero(ulongContainer, 2);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstNullOrZero(ushortContainer, 2);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.Equal((byte)2, byteValue);
            Assert.Equal(2, decimalValue);
            Assert.Equal(2, doubleValue);
            Assert.Equal(2, floatValue);
            Assert.Equal(2, intValue);
            Assert.Equal(2, longValue);
            Assert.Equal((sbyte)2, sbyteValue);
            Assert.Equal((short)2, shortValue);
            Assert.Equal(2u, uintValue);
            Assert.Equal(2ul, ulongValue);
            Assert.Equal((ushort)2, ushortValue);
        }

        #endregion

        #region AgainstNullOrNotInRange

        [Fact]
        public void AgainstNullOrNotInRange_NotInRangeCheckByReference_Modified()
        {
            // Arrange
            byte? byteValue = 10;
            var byteInitialValue = byteValue;

            decimal? decimalValue = 10;
            var decimalInitialValue = decimalValue;

            double? doubleValue = 10;
            var doubleInitialValue = doubleValue;

            float? floatValue = 10;
            var floatInitialValue = floatValue;

            int? intValue = 10;
            var intInitialValue = intValue;

            long? longValue = 10;
            var longInitialValue = longValue;

            sbyte? sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;

            short? shortValue = 10;
            var shortInitialValue = shortValue;

            uint? uintValue = 10;
            var uintInitialValue = uintValue;

            ulong? ulongValue = 10;
            var ulongInitialValue = ulongValue;

            ushort? ushortValue = 10;
            var ushortInitialValue = ushortValue;

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrNotInRange(ref byteValue, 0, 9, 0);
            NumericGuards.Decimal.Safe.AgainstNullOrNotInRange(ref decimalValue, 0, 9, 0);
            NumericGuards.Double.Safe.AgainstNullOrNotInRange(ref doubleValue, 0, 9, 0);
            NumericGuards.Float.Safe.AgainstNullOrNotInRange(ref floatValue, 0, 9, 0);
            NumericGuards.Int.Safe.AgainstNullOrNotInRange(ref intValue, 0, 9, 0);
            NumericGuards.Long.Safe.AgainstNullOrNotInRange(ref longValue, 0, 9, 0);
            NumericGuards.Sbyte.Safe.AgainstNullOrNotInRange(ref sbyteValue, 0, 9, 0);
            NumericGuards.Short.Safe.AgainstNullOrNotInRange(ref shortValue, 0, 9, 0);
            NumericGuards.Uint.Safe.AgainstNullOrNotInRange(ref uintValue, 0, 9, 0);
            NumericGuards.Ulong.Safe.AgainstNullOrNotInRange(ref ulongValue, 0, 9, 0);
            NumericGuards.Ushort.Safe.AgainstNullOrNotInRange(ref ushortValue, 0, 9, 0);

            // Assert
            Assert.NotInRange((byte)byteInitialValue, 0, 9);
            Assert.Equal((byte)0, byteValue);

            Assert.NotInRange((decimal)decimalInitialValue, 0, 9);
            Assert.Equal(0, decimalValue);

            Assert.NotInRange((double)doubleInitialValue, 0, 9);
            Assert.Equal(0, doubleValue);

            Assert.NotInRange((float)floatInitialValue, 0, 9);
            Assert.Equal(0, floatValue);

            Assert.NotInRange((int)intInitialValue, 0, 9);
            Assert.Equal(0, intValue);

            Assert.NotInRange((long)longInitialValue, 0, 9);
            Assert.Equal(0, longValue);

            Assert.NotInRange((sbyte)sbyteInitialValue, 0, 9);
            Assert.Equal((sbyte)0, sbyteValue);

            Assert.NotInRange((short)shortInitialValue, 0, 9);
            Assert.Equal((short)0, shortValue);

            Assert.NotInRange((uint)uintInitialValue, 0u, 9u);
            Assert.Equal(0u, uintValue);

            Assert.NotInRange((ulong)ulongInitialValue, 0ul, 9ul);
            Assert.Equal(0ul, ulongValue);

            Assert.NotInRange((ushort)ushortInitialValue, 0, 9);
            Assert.Equal((ushort)0, ushortValue);
        }

        [Fact]
        public void AgainstNullOrNotInRange_InRangeCheckByReference_NotModified()
        {
            // Arrange
            byte? byteValue = 10;
            var byteInitialValue = byteValue;

            decimal? decimalValue = 10;
            var decimalInitialValue = decimalValue;

            double? doubleValue = 10;
            var doubleInitialValue = doubleValue;

            float? floatValue = 10;
            var floatInitialValue = floatValue;

            int? intValue = 10;
            var intInitialValue = intValue;

            long? longValue = 10;
            var longInitialValue = longValue;

            sbyte? sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;

            short? shortValue = 10;
            var shortInitialValue = shortValue;

            uint? uintValue = 10;
            var uintInitialValue = uintValue;

            ulong? ulongValue = 10;
            var ulongInitialValue = ulongValue;

            ushort? ushortValue = 10;
            var ushortInitialValue = ushortValue;

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrNotInRange(ref byteValue, 0, 10, 0);
            NumericGuards.Decimal.Safe.AgainstNullOrNotInRange(ref decimalValue, 0, 10, 0);
            NumericGuards.Double.Safe.AgainstNullOrNotInRange(ref doubleValue, 0, 10, 0);
            NumericGuards.Float.Safe.AgainstNullOrNotInRange(ref floatValue, 0, 10, 0);
            NumericGuards.Int.Safe.AgainstNullOrNotInRange(ref intValue, 0, 10, 0);
            NumericGuards.Long.Safe.AgainstNullOrNotInRange(ref longValue, 0, 10, 0);
            NumericGuards.Sbyte.Safe.AgainstNullOrNotInRange(ref sbyteValue, 0, 10, 0);
            NumericGuards.Short.Safe.AgainstNullOrNotInRange(ref shortValue, 0, 10, 0);
            NumericGuards.Uint.Safe.AgainstNullOrNotInRange(ref uintValue, 0, 10, 0);
            NumericGuards.Ulong.Safe.AgainstNullOrNotInRange(ref ulongValue, 0, 10, 0);
            NumericGuards.Ushort.Safe.AgainstNullOrNotInRange(ref ushortValue, 0, 10, 0);

            // Assert
            Assert.InRange((byte)byteInitialValue, 0, 10);
            Assert.Equal((byte)10, byteValue);

            Assert.InRange((decimal)decimalInitialValue, 0, 10);
            Assert.Equal(10, decimalValue);

            Assert.InRange((double)doubleInitialValue, 0, 10);
            Assert.Equal(10, doubleValue);

            Assert.InRange((float)floatInitialValue, 0, 10);
            Assert.Equal(10, floatValue);

            Assert.InRange((int)intInitialValue, 0, 10);
            Assert.Equal(10, intValue);

            Assert.InRange((long)longInitialValue, 0, 10);
            Assert.Equal(10, longValue);

            Assert.InRange((sbyte)sbyteInitialValue, 0, 10);
            Assert.Equal((sbyte)10, sbyteValue);

            Assert.InRange((short)shortInitialValue, 0, 10);
            Assert.Equal((short)10, shortValue);

            Assert.InRange((uint)uintInitialValue, 0u, 10u);
            Assert.Equal(10u, uintValue);

            Assert.InRange((ulong)ulongInitialValue, 0ul, 10ul);
            Assert.Equal(10ul, ulongValue);

            Assert.InRange((ushort)ushortInitialValue, 0, 10);
            Assert.Equal((ushort)10, ushortValue);
        }

        [Fact]
        public void AgainstNullOrNotInRange_NullCheckByReference_Modified()
        {
            // Arrange
            byte? byteValue = null;
            var byteInitialValue = byteValue;

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

            uint? uintValue = null;
            var uintInitialValue = uintValue;

            ulong? ulongValue = null;
            var ulongInitialValue = ulongValue;

            ushort? ushortValue = null;
            var ushortInitialValue = ushortValue;

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrNotInRange(ref byteValue, 0, 10, 0);
            NumericGuards.Decimal.Safe.AgainstNullOrNotInRange(ref decimalValue, 0, 10, 0);
            NumericGuards.Double.Safe.AgainstNullOrNotInRange(ref doubleValue, 0, 10, 0);
            NumericGuards.Float.Safe.AgainstNullOrNotInRange(ref floatValue, 0, 10, 0);
            NumericGuards.Int.Safe.AgainstNullOrNotInRange(ref intValue, 0, 10, 0);
            NumericGuards.Long.Safe.AgainstNullOrNotInRange(ref longValue, 0, 10, 0);
            NumericGuards.Sbyte.Safe.AgainstNullOrNotInRange(ref sbyteValue, 0, 10, 0);
            NumericGuards.Short.Safe.AgainstNullOrNotInRange(ref shortValue, 0, 10, 0);
            NumericGuards.Uint.Safe.AgainstNullOrNotInRange(ref uintValue, 0, 10, 0);
            NumericGuards.Ulong.Safe.AgainstNullOrNotInRange(ref ulongValue, 0, 10, 0);
            NumericGuards.Ushort.Safe.AgainstNullOrNotInRange(ref ushortValue, 0, 10, 0);

            // Assert
            Assert.Null(byteInitialValue);
            Assert.Equal((byte)0, byteValue);

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

            Assert.Null(uintInitialValue);
            Assert.Equal(0u, uintValue);

            Assert.Null(ulongInitialValue);
            Assert.Equal(0ul, ulongValue);

            Assert.Null(ushortInitialValue);
            Assert.Equal((ushort)0, ushortValue);
        }

        [Fact]
        public void AgainstNullOrNotInRange_NotInRangeCheckByContainer_Modified()
        {
            // Arrange
            byte? byteValue = 10;
            var byteInitialValue = byteValue;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal? decimalValue = 10;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double? doubleValue = 10;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float? floatValue = 10;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int? intValue = 10;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long? longValue = 10;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte? sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short? shortValue = 10;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            uint? uintValue = 10;
            var uintInitialValue = uintValue;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong? ulongValue = 10;
            var ulongInitialValue = ulongValue;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort? ushortValue = 10;
            var ushortInitialValue = ushortValue;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrNotInRange(byteContainer, 0, 9, 0);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstNullOrNotInRange(decimalContainer, 0, 9, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrNotInRange(doubleContainer, 0, 9, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrNotInRange(floatContainer, 0, 9, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrNotInRange(intContainer, 0, 9, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrNotInRange(longContainer, 0, 9, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrNotInRange(sbyteContainer, 0, 9, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrNotInRange(shortContainer, 0, 9, 0);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstNullOrNotInRange(uintContainer, 0, 9, 0);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstNullOrNotInRange(ulongContainer, 0, 9, 0);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstNullOrNotInRange(ushortContainer, 0, 9, 0);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.NotInRange((byte)byteInitialValue, 0, 9);
            Assert.Equal((byte)0, byteValue);

            Assert.NotInRange((decimal)decimalInitialValue, 0, 9);
            Assert.Equal(0, decimalValue);

            Assert.NotInRange((double)doubleInitialValue, 0, 9);
            Assert.Equal(0, doubleValue);

            Assert.NotInRange((float)floatInitialValue, 0, 9);
            Assert.Equal(0, floatValue);

            Assert.NotInRange((int)intInitialValue, 0, 9);
            Assert.Equal(0, intValue);

            Assert.NotInRange((long)longInitialValue, 0, 9);
            Assert.Equal(0, longValue);

            Assert.NotInRange((sbyte)sbyteInitialValue, 0, 9);
            Assert.Equal((sbyte)0, sbyteValue);

            Assert.NotInRange((short)shortInitialValue, 0, 9);
            Assert.Equal((short)0, shortValue);

            Assert.NotInRange((uint)uintInitialValue, 0u, 9u);
            Assert.Equal(0u, uintValue);

            Assert.NotInRange((ulong)ulongInitialValue, 0ul, 9ul);
            Assert.Equal(0ul, ulongValue);

            Assert.NotInRange((ushort)ushortInitialValue, 0, 9);
            Assert.Equal((ushort)0, ushortValue);
        }

        [Fact]
        public void AgainstNullOrNotInRange_InRangeCheckByContainer_NotModified()
        {
            // Arrange
            byte? byteValue = 10;
            var byteInitialValue = byteValue;
            var byteContainer = SafeContainer.Create(byteValue);

            decimal? decimalValue = 10;
            var decimalInitialValue = decimalValue;
            var decimalContainer = SafeContainer.Create(decimalValue);

            double? doubleValue = 10;
            var doubleInitialValue = doubleValue;
            var doubleContainer = SafeContainer.Create(doubleValue);

            float? floatValue = 10;
            var floatInitialValue = floatValue;
            var floatContainer = SafeContainer.Create(floatValue);

            int? intValue = 10;
            var intInitialValue = intValue;
            var intContainer = SafeContainer.Create(intValue);

            long? longValue = 10;
            var longInitialValue = longValue;
            var longContainer = SafeContainer.Create(longValue);

            sbyte? sbyteValue = 10;
            var sbyteInitialValue = sbyteValue;
            var sbyteContainer = SafeContainer.Create(sbyteValue);

            short? shortValue = 10;
            var shortInitialValue = shortValue;
            var shortContainer = SafeContainer.Create(shortValue);

            uint? uintValue = 10;
            var uintInitialValue = uintValue;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong? ulongValue = 10;
            var ulongInitialValue = ulongValue;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort? ushortValue = 10;
            var ushortInitialValue = ushortValue;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrNotInRange(byteContainer, 0, 10, 0);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstNullOrNotInRange(decimalContainer, 0, 10, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrNotInRange(doubleContainer, 0, 10, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrNotInRange(floatContainer, 0, 10, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrNotInRange(intContainer, 0, 10, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrNotInRange(longContainer, 0, 10, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrNotInRange(sbyteContainer, 0, 10, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrNotInRange(shortContainer, 0, 10, 0);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstNullOrNotInRange(uintContainer, 0, 10, 0);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstNullOrNotInRange(ulongContainer, 0, 10, 0);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstNullOrNotInRange(ushortContainer, 0, 10, 0);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.InRange((byte)byteInitialValue, 0, 10);
            Assert.Equal((byte)10, byteValue);

            Assert.InRange((decimal)decimalInitialValue, 0, 10);
            Assert.Equal(10, decimalValue);

            Assert.InRange((double)doubleInitialValue, 0, 10);
            Assert.Equal(10, doubleValue);

            Assert.InRange((float)floatInitialValue, 0, 10);
            Assert.Equal(10, floatValue);

            Assert.InRange((int)intInitialValue, 0, 10);
            Assert.Equal(10, intValue);

            Assert.InRange((long)longInitialValue, 0, 10);
            Assert.Equal(10, longValue);

            Assert.InRange((sbyte)sbyteInitialValue, 0, 10);
            Assert.Equal((sbyte)10, sbyteValue);

            Assert.InRange((short)shortInitialValue, 0, 10);
            Assert.Equal((short)10, shortValue);

            Assert.InRange((uint)uintInitialValue, 0u, 10u);
            Assert.Equal(10u, uintValue);

            Assert.InRange((ulong)ulongInitialValue, 0ul, 10ul);
            Assert.Equal(10ul, ulongValue);

            Assert.InRange((ushort)ushortInitialValue, 0, 10);
            Assert.Equal((ushort)10, ushortValue);
        }

        [Fact]
        public void AgainstNullOrNotInRange_NullCheckByContainer_Modified()
        {
            // Arrange
            byte? byteValue = null;
            var byteInitialValue = byteValue;
            var byteContainer = SafeContainer.Create(byteValue);

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

            uint? uintValue = null;
            var uintInitialValue = uintValue;
            var uintContainer = SafeContainer.Create(uintValue);

            ulong? ulongValue = null;
            var ulongInitialValue = ulongValue;
            var ulongContainer = SafeContainer.Create(ulongValue);

            ushort? ushortValue = null;
            var ushortInitialValue = ushortValue;
            var ushortContainer = SafeContainer.Create(ushortValue);

            // Act
            NumericGuards.Byte.Safe.AgainstNullOrNotInRange(byteContainer, 0, 10, 0);
            byteValue = byteContainer.Value;

            NumericGuards.Decimal.Safe.AgainstNullOrNotInRange(decimalContainer, 0, 10, 0);
            decimalValue = decimalContainer.Value;

            NumericGuards.Double.Safe.AgainstNullOrNotInRange(doubleContainer, 0, 10, 0);
            doubleValue = doubleContainer.Value;

            NumericGuards.Float.Safe.AgainstNullOrNotInRange(floatContainer, 0, 10, 0);
            floatValue = floatContainer.Value;

            NumericGuards.Int.Safe.AgainstNullOrNotInRange(intContainer, 0, 10, 0);
            intValue = intContainer.Value;

            NumericGuards.Long.Safe.AgainstNullOrNotInRange(longContainer, 0, 10, 0);
            longValue = longContainer.Value;

            NumericGuards.Sbyte.Safe.AgainstNullOrNotInRange(sbyteContainer, 0, 10, 0);
            sbyteValue = sbyteContainer.Value;

            NumericGuards.Short.Safe.AgainstNullOrNotInRange(shortContainer, 0, 10, 0);
            shortValue = shortContainer.Value;

            NumericGuards.Uint.Safe.AgainstNullOrNotInRange(uintContainer, 0, 10, 0);
            uintValue = uintContainer.Value;

            NumericGuards.Ulong.Safe.AgainstNullOrNotInRange(ulongContainer, 0, 10, 0);
            ulongValue = ulongContainer.Value;

            NumericGuards.Ushort.Safe.AgainstNullOrNotInRange(ushortContainer, 0, 10, 0);
            ushortValue = ushortContainer.Value;

            // Assert
            Assert.Null(byteInitialValue);
            Assert.Equal((byte)0, byteValue);

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

            Assert.Null(uintInitialValue);
            Assert.Equal(0u, uintValue);

            Assert.Null(ulongInitialValue);
            Assert.Equal(0ul, ulongValue);

            Assert.Null(ushortInitialValue);
            Assert.Equal((ushort)0, ushortValue);
        }

        #endregion
    }
}
