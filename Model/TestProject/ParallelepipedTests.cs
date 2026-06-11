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
        TestName = "Invalid Base Length Not A Number",
        Description =
            "Проверяет, что нельзя создать параллелепипед с NaN в "
            + "BaseLength")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Base Length Positive Infinity",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "положительной бесконечностью в BaseLength")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Base Length Negative Infinity",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательной бесконечностью в BaseLength")]
    [TestCase(
        0.0,
        TestName = "Invalid Base Length Zero",
        Description =
            "Проверяет, что нельзя создать параллелепипед с нулевым "
            + "BaseLength")]
    [TestCase(
        -1.0,
        TestName = "Invalid Base Length Minus One",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательным BaseLength")]
    [TestCase(
        -10.5,
        TestName = "Invalid Base Length Minus 10_5",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательным BaseLength")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Base Length Minus 9999_5",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательным BaseLength")]
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
    TestName = "Invalid Base Width Not A Number",
    Description =
        "Проверяет, что нельзя создать параллелепипед с NaN в BaseWidth")]
    [TestCase(
    double.PositiveInfinity,
    TestName = "Invalid Base Width Positive Infinity",
    Description =
        "Проверяет, что нельзя создать параллелепипед с положительной "
        + "бесконечностью в BaseWidth")]
    [TestCase(
    double.NegativeInfinity,
    TestName = "Invalid Base Width Negative Infinity",
    Description =
        "Проверяет, что нельзя создать параллелепипед с отрицательной "
        + "бесконечностью в BaseWidth")]
    [TestCase(
    0.0,
    TestName = "Invalid Base Width Zero",
    Description =
        "Проверяет, что нельзя создать параллелепипед с нулевым "
        + "BaseWidth")]
    [TestCase(
    -1.0,
    TestName = "Invalid Base Width Minus One",
    Description =
        "Проверяет, что нельзя создать параллелепипед с отрицательным "
        + "BaseWidth")]
    [TestCase(
    -10.5,
    TestName = "Invalid Base Width Minus 10_5",
    Description =
        "Проверяет, что нельзя создать параллелепипед с отрицательным "
        + "BaseWidth")]
    [TestCase(
    -9999.5,
    TestName = "Invalid Base Width Minus 9999_5",
    Description =
        "Проверяет, что нельзя создать параллелепипед с отрицательным "
        + "BaseWidth")]
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
        TestName = "Invalid Height Not A Number",
        Description =
            "Проверяет, что нельзя создать параллелепипед с NaN в "
            + "BaseHeight")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Height Positive Infinity",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "положительной бесконечностью в BaseHeight")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Height Negative Infinity",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательной бесконечностью в BaseHeight")]
    [TestCase(
        0.0,
        TestName = "Invalid Height Zero",
        Description =
            "Проверяет, что нельзя создать параллелепипед с нулевым "
            + "BaseHeight")]
    [TestCase(
        -1.0,
        TestName = "Invalid Height Minus One",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательным BaseHeight")]
    [TestCase(
        -10.5,
        TestName = "Invalid Height Minus 10_5",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательным BaseHeight")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Height Minus 9999_5",
        Description =
            "Проверяет, что нельзя создать параллелепипед с "
            + "отрицательным BaseHeight")]
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
        TestName = "Valid Base Length 15_5",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным BaseLength 15.5")]
    [TestCase(
        500.0,
        TestName = "Valid Base Length 500",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным BaseLength 500.0")]
    [TestCase(
        1000.5,
        TestName = "Valid Base Length 1000_5",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным BaseLength 1000.5")]
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
        TestName = "Valid Base Width 15_5",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным BaseWidth 15.5")]
    [TestCase(
        500.0,
        TestName = "Valid Base Width 500",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным BaseWidth 500.0")]
    [TestCase(
        1000.5,
        TestName = "Valid Base Width 1000_5",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным BaseWidth 1000.5")]
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
        TestName = "Valid Height 15_5",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным Height 15.5")]
    [TestCase(
        500.0,
        TestName = "Valid Height 500",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным Height 500.0")]
    [TestCase(
        1000.5,
        TestName = "Valid Height 1000_5",
        Description =
            "Проверяет, что можно создать параллелепипед с "
            + "положительным Height 1000.5")]
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
        TestName = "Volume 3_5 By 4 By 10 Returns 140",
        Description = "Проверяет, что объем параллелепипеда равен 140.0")]
    [TestCase(
        2.0,
        1.5,
        30.0,
        TestName = "Volume 2 By 1_5 By 10 Returns 30",
        Description = "Проверяет, что объем параллелепипеда равен 30.0")]
    [TestCase(
        3.0,
        3.0,
        90.0,
        TestName = "Volume 3 By 3 By 10 Returns 90",
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
