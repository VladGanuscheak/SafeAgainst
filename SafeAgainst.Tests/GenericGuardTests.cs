using System;
using System.Threading.Tasks;
using Xunit;

namespace SafeAgainst.Tests
{
    public class GenericGuardTests
    {
        internal class Test<T> where T : struct, IComparable<T>, IComparable, IConvertible, IEquatable<T>, IFormattable
        {
            public T Value { get; set; }

            public Test(T value)
            {
                Value = value;
            }
        }

        [Fact]
        public void Against_PredicateWithDefaultByReference_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;

            // Act
            Safe<int>.Against(ref value, func, value + 1);

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public void Against_PredicateWithDefaultByContainer_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;
            var container = SafeContainer.Create(value);

            // Act
            Safe<int>.Against(container, func, value + 1);
            value = container.Value;

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public void Against_PredicateWithReplaceWithParamByReference_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;

            // Act
            Safe<int>.Against(ref value, func, x => x + 1);

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public void Against_PredicateWithReplaceWithParamByContainer_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;
            var container = SafeContainer.Create(value);

            // Act
            Safe<int>.Against(container, func, x => x + 1);
            value = container.Value;

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public void Against_PredicateWithReplaceWithoutParamByReference_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;

            // Act
            Safe<int>.Against(ref value, func, _ => value + 1);

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public void Against_PredicateWithReplaceWithoutParamByContainer_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;
            var container = SafeContainer.Create(value);

            // Act
            Safe<int>.Against(container, func, _ => value + 1);
            value = container.Value;

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public async Task Against_PredicateWithAsyncReplaceWithParamByContainer_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;
            Task<int> replace(int x) => Task.FromResult(x + 1);
            var container = SafeContainer.Create(value);

            // Act
            await Safe<int>.AsyncAgainst(container, func, replace);
            value = container.Value;

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public async Task Against_PredicateWithAsyncReplaceWithoutParamByContainer_Modified()
        {
            // Arrange
            var value = 1;
            bool func(int x) => x % 2 != 0;
            Task<int> replace() => Task.FromResult(value + 1);
            var container = SafeContainer.Create(value);

            // Act
            await Safe<int>.AsyncAgainst(container, func, replace);
            value = container.Value;

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public async Task Against_AsyncPredicateWithAsyncReplaceWithParamByContainer_Modified()
        {
            // Arrange
            var value = 1;
            Task<bool> func(int x) => Task.FromResult(x % 2 != 0);
            Task<int> replace(int x) => Task.FromResult(x + 1);
            var container = SafeContainer.Create(value);

            // Act
            await Safe<int>.AsyncAgainst(container, func, replace);
            value = container.Value;

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public async Task Against_AsyncPredicateWithAsyncReplaceWithoutParamByContainer_Modified()
        {
            // Arrange
            var value = 1;
            Task<bool> func(int x) => Task.FromResult(x % 2 != 0);
            Task<int> replace() => Task.FromResult(value + 1);
            var container = SafeContainer.Create(value);

            // Act
            await Safe<int>.AsyncAgainst(container, func, replace);
            value = container.Value;

            // Assert
            Assert.Equal(2, value);
        }
    }
}
