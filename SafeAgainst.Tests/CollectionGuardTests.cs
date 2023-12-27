using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SafeAgainst.Tests
{
    public class CollectionGuardTests
    {
        private readonly IEnumerable<int> DefaultEnumeration = Enumerable.Empty<int>()
            .Append(5)
            .Append(3)
            .ToList();

        public class UnitializedCollections<T>
        {
            public IList<T> NullList = null;
            public ICollection<T> NullCollection = null;
            public ISet<T> NullSet = null;
            public T[] NullArray = null;

            public void Initialize(IEnumerable<T> enumeration)
            {
                NullList = enumeration.ToList();
                NullCollection = enumeration.ToList();
                NullSet = new HashSet<T>(enumeration);
                NullArray = enumeration.ToArray();
            }
        }

        #region AgainstNull
        [Fact]
        public void AgainstNull_NullCheckedByReference_Modified()
        {
            // Arrange
            IEnumerable<int> nullEnumerableCollection = null;
            var uninitializedCollections = new UnitializedCollections<int>();

            // Act
            CollectionGuards.Safe<int>.AgainstNull(ref nullEnumerableCollection, DefaultEnumeration);
            uninitializedCollections.Initialize(nullEnumerableCollection);

            // Assert
            Assert.NotNull(nullEnumerableCollection);
            Assert.Equal(DefaultEnumeration, nullEnumerableCollection);

            Assert.NotNull(uninitializedCollections.NullList);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullList.AsEnumerable());

            Assert.NotNull(uninitializedCollections.NullCollection);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullCollection.AsEnumerable());

            Assert.NotNull(uninitializedCollections.NullSet);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullSet.AsEnumerable());

            Assert.NotNull(uninitializedCollections.NullArray);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullArray.AsEnumerable());
        }

        [Fact]
        public void AgainstNull_NotNullCheckedByReference_NotModified()
        {
            // Arrange
            var emptyEnumerableCollection = Enumerable.Empty<string>();

            // Act
            CollectionGuards.Safe<string>.AgainstNull(ref emptyEnumerableCollection, new string[] { "first", "second", "third" });

            // Assert
            Assert.NotNull(emptyEnumerableCollection);
            Assert.Equal(Enumerable.Empty<string>(), emptyEnumerableCollection);
        }

        [Fact]
        public void AgainstNull_NullCheckedByContainer_Modified()
        {
            // Arrange
            IEnumerable<int> nullEnumerableCollection = null;
            var uninitializedCollections = new UnitializedCollections<int>();
            var container = SafeContainer.Create(nullEnumerableCollection);

            // Act
            CollectionGuards.Safe<int>.AgainstNull(container, DefaultEnumeration);
            nullEnumerableCollection = container.Value;
            uninitializedCollections.Initialize(nullEnumerableCollection);

            // Assert
            Assert.NotNull(nullEnumerableCollection);
            Assert.Equal(DefaultEnumeration, nullEnumerableCollection);

            Assert.NotNull(uninitializedCollections.NullList);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullList.AsEnumerable());

            Assert.NotNull(uninitializedCollections.NullCollection);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullCollection.AsEnumerable());

            Assert.NotNull(uninitializedCollections.NullSet);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullSet.AsEnumerable());

            Assert.NotNull(uninitializedCollections.NullArray);
            Assert.Equal(DefaultEnumeration, uninitializedCollections.NullArray.AsEnumerable());
        }

        [Fact]
        public void AgainstNull_NotNullCheckedByContainer_NotModified()
        {
            // Arrange
            var emptyEnumerableCollection = Enumerable.Empty<string>();
            var container = SafeContainer.Create(emptyEnumerableCollection);

            // Act
            CollectionGuards.Safe<string>.AgainstNull(container, new string[] { "first", "second", "third" });
            emptyEnumerableCollection = container.Value;

            // Assert
            Assert.NotNull(emptyEnumerableCollection);
            Assert.Equal(Enumerable.Empty<string>(), emptyEnumerableCollection);
        }
        #endregion

        #region AgainstEmpty
        [Fact]
        public void AgainstEmpty_EmptyCheckedByReference_Modified()
        {
            // Arrange
            var emptyCollection = Enumerable.Empty<float>();
            IEnumerable<float> defaultValue = new float[] { 1f, 34f, 52f };

            // Act
            CollectionGuards.Safe<float>.AgainstEmpty(ref emptyCollection, defaultValue);

            // Assert
            Assert.Equal(defaultValue, emptyCollection);
        }

        [Fact]
        public void AgainstEmpty_NotEmptyCheckedByReference_NotModified()
        {
            // Arrange
            var nonEmptyCollection = Enumerable.Empty<float>()
                .Append(1)
                .Append(2);
            IEnumerable<float> defaultValue = new float[] { 1f, 34f, 52f };

            // Act
            CollectionGuards.Safe<float>.AgainstEmpty(ref nonEmptyCollection, defaultValue);

            // Assert
            Assert.NotEmpty(defaultValue);
            Assert.NotEqual(defaultValue, nonEmptyCollection);
        }

        [Fact]
        public void AgainstEmpty_EmptyCheckedByContainer_Modified()
        {
            // Arrange
            var emptyCollection = Enumerable.Empty<float>();
            IEnumerable<float> defaultValue = new float[] { 1f, 34f, 52f };
            var container = SafeContainer.Create(emptyCollection);

            // Act
            CollectionGuards.Safe<float>.AgainstEmpty(container, defaultValue);
            emptyCollection = container.Value;

            // Assert
            Assert.Equal(defaultValue, emptyCollection);
        }

        [Fact]
        public void AgainstEmpty_NotEmptyCheckedByContainer_NotModified()
        {
            // Arrange
            var nonEmptyCollection = Enumerable.Empty<float>()
                .Append(1)
                .Append(2);
            IEnumerable<float> defaultValue = new float[] { 1f, 34f, 52f };
            var container = SafeContainer.Create(nonEmptyCollection);

            // Act
            CollectionGuards.Safe<float>.AgainstEmpty(container, defaultValue);
            nonEmptyCollection = container.Value;

            // Assert
            Assert.NotEmpty(defaultValue);
            Assert.NotEqual(defaultValue, nonEmptyCollection);
        }
        #endregion

        #region AgainstNullOrEmpty
        [Fact]
        public void AgainstNullOrEmpty_NullCheckedByReference_Modified()
        {
            // Arrange
            IEnumerable<int> enumeration = null;

            // Act
            CollectionGuards.Safe<int>.AgainstNullOrEmpty(ref enumeration, DefaultEnumeration);

            // Assert
            Assert.NotNull(enumeration);
            Assert.Equal(DefaultEnumeration, enumeration);
        }

        [Fact]
        public void AgainstNullOrEmpty_EmptyCheckedByReference_Modified()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Empty<int>();

            // Act
            CollectionGuards.Safe<int>.AgainstNullOrEmpty(ref enumeration, DefaultEnumeration);

            // Assert
            Assert.NotEmpty(enumeration);
            Assert.Equal(DefaultEnumeration, enumeration);
        }

        [Fact]
        public void AgainstNullOrEmpty_ValidCheckedByReference_NotModified()
        {
            // Arrange
            var enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(2)
                .Append(3);

            // Act
            CollectionGuards.Safe<int>.AgainstNullOrEmpty(ref enumeration, DefaultEnumeration);

            // Assert
            Assert.NotNull(enumeration);
            Assert.NotEmpty(enumeration);
            Assert.NotEqual(DefaultEnumeration, enumeration);
        }

        [Fact]
        public void AgainstNullOrEmpty_NullCheckedByContainer_Modified()
        {
            // Arrange
            IEnumerable<int> enumeration = null;
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int>.AgainstNullOrEmpty(container, DefaultEnumeration);
            enumeration = container.Value;

            // Assert
            Assert.NotNull(enumeration);
            Assert.Equal(DefaultEnumeration, enumeration);
        }

        [Fact]
        public void AgainstNullOrEmpty_EmptyCheckedByContainer_Modified()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Empty<int>();
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int>.AgainstNullOrEmpty(container, DefaultEnumeration);
            enumeration = container.Value;

            // Assert
            Assert.NotEmpty(enumeration);
            Assert.Equal(DefaultEnumeration, enumeration);
        }

        [Fact]
        public void AgainstNullOrEmpty_ValidCheckedByContainer_NotModified()
        {
            // Arrange
            var enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(2)
                .Append(3);
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int>.AgainstNullOrEmpty(container, DefaultEnumeration);
            enumeration = container.Value;

            // Assert
            Assert.NotNull(enumeration);
            Assert.NotEmpty(enumeration);
            Assert.NotEqual(DefaultEnumeration, enumeration);
        }
        #endregion

        #region AgainstNullElements
        [Fact]
        public void AgainstNullElements_ContainsNullElementsCheckByReference_NoNullElements()
        {
            // Arrange
            IEnumerable<int?> enumeration = Enumerable.Empty<int?>()
                .Append(2)
                .Append(10)
                .Append(null)
                .Append(1);

            // Act
            CollectionGuards.Safe<int?>.AgainstNullElements(ref enumeration);

            // Assert
            Assert.DoesNotContain(enumeration, x => x == null);
            Assert.Contains(enumeration, x => x != null);
            Assert.True(enumeration.ToList().Count == 3);
        }

        [Fact]
        public void AgainstNullElements_DontContainNullElementsCheckByReference_NoNullElements()
        {
            // Arrange
            IEnumerable<int?> enumeration = Enumerable.Empty<int?>()
                .Append(2)
                .Append(10)
                .Append(1);

            // Act
            CollectionGuards.Safe<int?>.AgainstNullElements(ref enumeration);

            // Assert
            Assert.DoesNotContain(enumeration, x => x == null);
            Assert.Contains(enumeration, x => x != null);
            Assert.True(enumeration.ToList().Count == 3);
        }

        [Fact]
        public void AgainstNullElements_ContainsNullElementsCheckByContainer_NoNullElements()
        {
            // Arrange
            IEnumerable<int?> enumeration = Enumerable.Empty<int?>()
                .Append(2)
                .Append(10)
                .Append(null)
                .Append(1);
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int?>.AgainstNullElements(container);
            enumeration = container.Value;

            // Assert
            Assert.DoesNotContain(enumeration, x => x == null);
            Assert.Contains(enumeration, x => x != null);
            Assert.True(enumeration.ToList().Count == 3);
        }

        [Fact]
        public void AgainstNullElements_DontContainNullElementsCheckByContainer_NoNullElements()
        {
            // Arrange
            IEnumerable<int?> enumeration = Enumerable.Empty<int?>()
                .Append(2)
                .Append(10)
                .Append(1);
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int?>.AgainstNullElements(container);
            enumeration = container.Value;

            // Assert
            Assert.DoesNotContain(enumeration, x => x == null);
            Assert.Contains(enumeration, x => x != null);
            Assert.True(enumeration.ToList().Count == 3);
        }
        #endregion

        #region AgainstDefaultElements

        [Fact]
        public void AgainstDefaultElements_ContainsEmptyElementsCheckByReference_NoEmptyElements()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Empty<int>()
                .Append(0)
                .Append(1)
                .Append(2);

            // Act
            CollectionGuards.Safe<int>.AgainstDefaultElements(ref enumeration);

            // Assert
            Assert.DoesNotContain(enumeration, x => x == 0);
            Assert.True(enumeration.ToList().Count == 2);
        }

        [Fact]
        public void AgainstDefaultElements_DontContainEmptyElementsCheckByReference_NoEmptyElements()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(2);

            // Act
            CollectionGuards.Safe<int>.AgainstDefaultElements(ref enumeration);

            // Assert
            Assert.DoesNotContain(enumeration, x => x == 0);
            Assert.True(enumeration.ToList().Count == 2);
        }

        [Fact]
        public void AgainstDefaultElements_ContainsEmptyElementsCheckByContainer_NoEmptyElements()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Empty<int>()
                .Append(0)
                .Append(1)
                .Append(2);
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int>.AgainstDefaultElements(container);
            enumeration = container.Value;

            // Assert
            Assert.DoesNotContain(enumeration, x => x == 0);
            Assert.True(enumeration.ToList().Count == 2);
        }

        [Fact]
        public void AgainstDefaultElements_DontContainEmptyElementsCheckByContainer_NoEmptyElements()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(2);
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int>.AgainstDefaultElements(container);
            enumeration = container.Value;

            // Assert
            Assert.DoesNotContain(enumeration, x => x == 0);
            Assert.True(enumeration.ToList().Count == 2);
        }

        #endregion

        #region AgainstValuesNotInSet 

        [Fact]
        public void AgainstValuesNotInSet_ValuesNotInSetCheckByReference_Modified()
        {
            // Arrange
            var enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(5)
                .Append(12);
            IEnumerable<int> allowedValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            CollectionGuards.Safe<int>.AgainstValuesNotInSet(ref enumeration, allowedValues);

            // Assert
            Assert.True(enumeration.All(x => allowedValues.Contains(x)));
        }

        [Fact]
        public void AgainstValuesNotInSet_ValuesInSetCheckByReference_NotModified()
        {
            // Arrange
            var enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(5);
            IEnumerable<int> allowedValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            CollectionGuards.Safe<int>.AgainstValuesNotInSet(ref enumeration, allowedValues);

            // Assert
            Assert.True(enumeration.All(x => allowedValues.Contains(x)));
        }

        [Fact]
        public void AgainstValuesNotInSet_ValuesNotInSetCheckByContainer_Modified()
        {
            // Arrange
            var enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(5)
                .Append(12);
            IEnumerable<int> allowedValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int>.AgainstValuesNotInSet(container, allowedValues);
            enumeration = container.Value;

            // Assert
            Assert.True(enumeration.All(x => allowedValues.Contains(x)));
        }

        [Fact]
        public void AgainstValuesNotInSet_ValuesInSetCheckByContainer_NotModified()
        {
            // Arrange
            var enumeration = Enumerable.Empty<int>()
                .Append(1)
                .Append(5);
            IEnumerable<int> allowedValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var container = SafeContainer.Create(enumeration);

            // Act
            CollectionGuards.Safe<int>.AgainstValuesNotInSet(container, allowedValues);
            enumeration = container.Value;

            // Assert
            Assert.True(enumeration.All(x => allowedValues.Contains(x)));
        }

        #endregion
    }
}
