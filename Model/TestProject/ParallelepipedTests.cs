namespace ModelParallelepipedTests;

public class ParallelepipedTests
{
    /// <summary>
    /// Допустимая погрешность для сравнения числовых значений типа double.
    /// </summary>
    private const double _tolerance = 1e-6;

    [Category("BaseLength")]
    [TestCase(
        double.NaN,
        TestName = "Constructor InvalidBaseLengthNaN ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с NaN в BaseLength")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Constructor InvalidBaseLengthPositiveInfinity ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с положительной бесконечностью в BaseLength")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Constructor InvalidBaseLengthNegativeInfinity ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательной бесконечностью в BaseLength")]
    [TestCase(
        0.0,
        TestName = "Constructor InvalidBaseLengthZero ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с нулевым BaseLength")]
    [TestCase(
        -1.0,
        TestName = "Constructor InvalidBaseLengthMinus 1 ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseLength")]
    [TestCase(
        -10.5,
        TestName = "Constructor InvalidBaseLengthMinus 10_5 ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseLength")]
    [TestCase(
        -9999.5,
        TestName = "Constructor InvalidBaseLengthMinus 9999_5 ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseLength")]
    public void ConstructorInvalidBaseLengthThrowsArgumentOutOfRangeException(
        double baseLength)
    {
        // Arrange
        double baseWidth = 10.0;
        double height = 15.0;

        // Act
        TestDelegate act = () => new Parallelepiped(baseLength, baseWidth, height);

        // Assert
        Assert.That(
            act,
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Category("BaseWidth")]
    [TestCase(
    double.NaN,
    TestName = "Constructor InvalidBaseWidthNaN ThrowsArgumentOutOfRangeException",
    Description = "Проверяет, что нельзя создать параллелепипед с NaN в BaseWidth")]
    [TestCase(
    double.PositiveInfinity,
    TestName = "Constructor InvalidBaseWidthPositiveInfinity ThrowsArgumentOutOfRangeException",
    Description = "Проверяет, что нельзя создать параллелепипед с положительной бесконечностью в BaseWidth")]
    [TestCase(
    double.NegativeInfinity,
    TestName = "Constructor InvalidBaseWidthNegativeInfinity ThrowsArgumentOutOfRangeException",
    Description = "Проверяет, что нельзя создать параллелепипед с отрицательной бесконечностью в BaseWidth")]
    [TestCase(
    0.0,
    TestName = "Constructor InvalidBaseWidthZero ThrowsArgumentOutOfRangeException",
    Description = "Проверяет, что нельзя создать параллелепипед с нулевым BaseWidth")]
    [TestCase(
    -1.0,
    TestName = "Constructor InvalidBaseWidthMinus 1 ThrowsArgumentOutOfRangeException",
    Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseWidth")]
    [TestCase(
    -10.5,
    TestName = "Constructor InvalidBaseWidthMinus 10_5 ThrowsArgumentOutOfRangeException",
    Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseWidth")]
    [TestCase(
    -9999.5,
    TestName = "Constructor InvalidBaseWidthMinus 9999_5 ThrowsArgumentOutOfRangeException",
    Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseWidth")]
    public void ConstructorInvalidBaseWidthThrowsArgumentOutOfRangeException(
    double baseWidth)
    {
        // Arrange
        double baseLength = 10.0;
        double height = 15.0;

        // Act
        TestDelegate act = () => new Parallelepiped(baseLength, baseWidth, height);

        // Assert
        Assert.That(
            act,
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Category("Height")]
    [TestCase(
        double.NaN,
        TestName = "Constructor InvalidBaseHeightNaN ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с NaN в BaseHeight")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Constructor InvalidBaseHeightPositiveInfinity ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с положительной бесконечностью в BaseHeight")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Constructor InvalidBaseHeightNegativeInfinity ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательной бесконечностью в BaseHeight")]
    [TestCase(
        0.0,
        TestName = "Constructor InvalidBaseHeightZero ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с нулевым BaseHeight")]
    [TestCase(
        -1.0,
        TestName = "Constructor InvalidBaseHeightMinus 1 ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseHeight")]
    [TestCase(
        -10.5,
        TestName = "Constructor InvalidBaseHeightMinus 10_5 ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseHeight")]
    [TestCase(
        -9999.5,
        TestName = "Constructor InvalidBaseHeightMinus 9999_5 ThrowsArgumentOutOfRangeException",
        Description = "Проверяет, что нельзя создать параллелепипед с отрицательным BaseHeight")]
    public void ConstructorInvalidBaseHeightThrowsArgumentOutOfRangeException(
        double Height)
    {
        // Arrange
        double baseLength = 10.0;
        double baseWidth = 15.0;

        // Act
        TestDelegate act = () => new Parallelepiped(baseLength, baseWidth, Height);

        // Assert
        Assert.That(
            act,
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Category("BaseLength")]
    [TestCase(
        15.5,
        TestName = "Constructor ValidBaseLength 15_5 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным BaseLength 15.5")]
    [TestCase(
        500.0,
        TestName = "Constructor ValidBaseLength 500_0 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным BaseLength 500.0")]
    [TestCase(
        1000.5,
        TestName = "Constructor ValidBaseLength 1000_5 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным BaseLength 1000.5")]
    public void ConstructorValidBaseLengthDoesNotThrow(
        double baseLength)
    {
        // Arrange
        double baseWidth = 10.0;
        double height = 15.0;
        // Act
        Parallelepiped parallelepiped = new Parallelepiped(baseLength, baseWidth, height);
        // Assert
        Assert.That(
            parallelepiped, Is.EqualTo(parallelepiped));
    }

    [Category("BaseWidth")]
    [TestCase(
        15.5,
        TestName = "Constructor ValidBaseWidth 15_5 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным BaseWidth 15.5")]
    [TestCase(
        500.0,
        TestName = "Constructor ValidBaseWidth 500_0 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным BaseWidth 500.0")]
    [TestCase(
        1000.5,
        TestName = "Constructor ValidBaseWidth 1000_5 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным BaseWidth 1000.5")]
    public void ConstructorValidBaseWidthDoesNotThrow(
        double baseWidth)
    {
        // Arrange
        double baseLength = 10.0;
        double height = 15.0;
        // Act
        Parallelepiped parallelepiped = new Parallelepiped(baseLength, baseWidth, height);
        // Assert
        Assert.That(
            parallelepiped,
            Is.EqualTo(parallelepiped));
    }

    [Category("Height")]
    [TestCase(
        15.5,
        TestName = "Constructor ValidHeight 15_5 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным Height 15.5")]
    [TestCase(
        500.0,
        TestName = "Constructor ValidHeight 500_0 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным Height 500.0")]
    [TestCase(
        1000.5,
        TestName = "Constructor ValidHeight 1000_5 DoesNotThrow",
        Description = "Проверяет, что можно создать параллелепипед с положительным Height 1000.5")]
    public void ConstructorValidHeightDoesNotThrow(
        double height)
    {
        // Arrange
        double baseLength = 10.0;
        double baseWidth = 15.0;
        // Act
        Parallelepiped parallelepiped = new Parallelepiped(baseLength, baseWidth, height);
        // Assert
        Assert.That(
            parallelepiped,
            Is.EqualTo(parallelepiped));
    }

    [Category("Volume")]
    [TestCase(
        3.5,
        4.0,
        140,
        TestName = "Volume ValidDimensions 3_5 4_0 ReturnsCorrectVolume  140_0",
        Description = "Проверяет, что объем параллелепипеда равен 140.0")]
    [TestCase(
        2.0,
        1.5,
        30.0,
        TestName = "Volume ValidDimensions 2_0 1_5 ReturnsCorrectVolume 30_0",
        Description = "Проверяет, что объем параллелепипеда равен 30.0")]
    [TestCase(
        3.0,
        3.0,
        90.0,
        TestName = "Volume ValidDimensions 3_0 3_0 ReturnsCorrectVolume  3_0",
        Description = "Проверяет, что объем параллелепипеда равен 90.0")]
    public void VolumeValidDimensionsReturnsCorrectVolume(
        double baseLength,
        double baseWidth,
        double expectedBaseArea)
    {
        // Arrange
        double height = 10.0;
        Parallelepiped parallelepiped = new Parallelepiped(baseLength, baseWidth, height);
        // Act
        double volume = parallelepiped.Volume;
        // Assert
        Assert.That(
            volume,
            Is.EqualTo(expectedBaseArea).Within(_tolerance));
    }

    [Category("FigureType")]
    public void FigureTypeReturnsCorrectValue()
    {
        // Arrange
        double baseLength = 10.0;
        double baseWidth = 15.0;
        double height = 20.0;
        Parallelepiped parallelepiped = new Parallelepiped(baseLength, baseWidth, height);
        // Act
        string figureType = parallelepiped.FigureType;
        // Assert
        Assert.That(
            figureType,
            Is.EqualTo("Параллелепипед"));
    }

    [Category("GetDescription")]
    [Test]
    public void GetDescriptionReturnsCorrectFormat()
    {
        // Arrange
        double baseLength = 10.0;
        double baseWidth = 15.0;
        double height = 20.0;
        Parallelepiped parallelepiped = new Parallelepiped(baseLength, baseWidth, height);
        string expectedDescription = $"Тип фигуры: Параллелепипед " +
            $"| Длина: {baseLength} " +
            $"| Ширина: {baseWidth} " +
            $"| Высота: {height} " +
            $"| Объем: {parallelepiped.Volume:G}";
        // Act
        string description = parallelepiped.GetDescription();
        // Assert
        Assert.That(
            description,
            Is.EqualTo(expectedDescription));
    }
}
