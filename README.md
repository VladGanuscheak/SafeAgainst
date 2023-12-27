# SafeAgainst

Provides functionality for creation of both synchronous and asynchronous generic guard clauses with custom preconditions and already contains implementation of basic ones for Collections, Enums, Strings, Objects and Numeric types.

### Usage

1. Eliminate Leading or trailing white spaces

- passing value by reference:

``` c#
    // Arrange
    var expectedValue = "Without leading or trailing whitespaces";
    var value = $"   {expectedValue}   ";

    // Act
    StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(ref value);

    // Assert
    Assert.Equal(expectedValue, value);
```
- or using a `SafeContainer`:

``` c#
    // Arrange
    var expectedValue = "Without leading or trailing whitespaces";
    var value = $"   {expectedValue}   ";
    var container = SafeContainer.Create(value);

    // Act
    StringGuards.Safe.AgainstLeadingOrTrailingWhiteSpaces(container);
    value = container.Value;

    // Assert
    Assert.Equal(expectedValue, value);
```

2. Assigning a predefined value, if enum contains an invalid one

- passing value by reference:

```c#
internal enum PowerOfTwo
{
    One = 1,
    Two = 2,
    Four = 4,
    Eight = 8,
    Sixteen = 16
};
```

```c#
    // Arrange
    PowerOfTwo powerOfTwo = default;
    var initialValue = powerOfTwo;

    // Act
    EnumGuards.Safe<PowerOfTwo>.AgainstNotInRange(ref powerOfTwo, PowerOfTwo.One);

    // Assert
    Assert.True(initialValue == 0);
    Assert.Equal(powerOfTwo, PowerOfTwo.One);
```

- or using a `SafeContainer`:

```c#
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
```

3. Eliminating NULL elements from collection:

- passing value by reference:

```c#
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
```

- or using a `SafeContainer`:

```c#
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
```

See way much more examples in the unit tests from the corresponding source repository.

### Global Picture

![General picture](https://raw.githubusercontent.com/VladGanuscheak/SafeAgainst/main/SafeAgainst_100.svg)