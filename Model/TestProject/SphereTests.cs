namespace ModelSphereTests;

public class SphereTests
{
    /// <summary>
    /// Допустимая погрешность для сравнения числовых значений типа double.
    /// </summary>
    private const double _tolerance = 1e-6;

    //Arrange
    [Category("Radius")]
    [TestCase(
        double.NaN,
        TestName = "Invalid Radius Not A Number",
        Description =
            "Проверяет, что создание сферы с NaN радиусом вызывает "
            + "ArgumentException")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Radius Positive Infinity",
        Description =
            "Проверяет, что создание сферы с бесконечным радиусом "
            + "вызывает ArgumentException")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Radius Negative Infinity",
        Description =
            "Проверяет, что создание сферы с отрицательным бесконечным "
            + "радиусом вызывает ArgumentException")]
    [TestCase(
        0.0,
        TestName = "Invalid Radius Zero",
        Description =
            "Проверяет, что создание сферы с нулевым радиусом вызывает "
            + "ArgumentException")]
    [TestCase(
        -1.0,
        TestName = "Invalid Radius Minus One",
        Description =
            "Проверяет, что создание сферы с отрицательным радиусом "
            + "вызывает ArgumentException")]
    [TestCase(
        -1.0,
        TestName = "Invalid Radius Minus One Again",
        Description =
            "Проверяет, что создание сферы с отрицательным радиусом "
            + "вызывает ArgumentException")]
    [TestCase(
        -10.5,
        TestName = "Invalid Radius Minus 10_5",
        Description =
            "Проверяет, что создание сферы с большим отрицательным "
            + "радиусом вызывает ArgumentException")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Radius Minus 9999_5",
        Description =
            "Проверяет, что создание сферы с небольшим отрицательным "
            + "радиусом вызывает ArgumentException")]
    public void ConstructorInvalidRadiusThrowsArgumentException(double radius)
    {
        // Act
        TestDelegate act = () => new Sphere(radius);
        // Assert
        Assert.That(act,
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Category("Radius")]
    [TestCase(1.0,
        TestName = "Valid Radius 1",
        Description =
            "Проверяет, что можно создать сферу с положительным радиусом")]
    [TestCase(5.0,
        TestName = "Valid Radius 5",
        Description =
            "Проверяет, что можно создать сферу с положительным радиусом")]
    [TestCase(15.5,
        TestName = "Valid Radius 15_5",
        Description =
            "Проверяет, что можно создать сферу с положительным радиусом")]
    public void ConstructorValidRadiusReturnsCorrectInstance(double radius)
    {
        // Act
        Sphere sphere = new Sphere(radius);

        // Assert
        Assert.That(sphere.Radius, Is.EqualTo(radius));
    }

    [Category("Volume")]
    [TestCase(1.0, 4.1887902047863905,
        TestName = "Volume Radius 1 Returns Correct Volume",
        Description =
            "Проверяет, что объем сферы с радиусом 1.0 вычисляется "
            + "правильно")]
    [TestCase(2.0, 33.510321638291124,
        TestName = "Volume Radius 2 Returns Correct Volume",
        Description =
            "Проверяет, что объем сферы с радиусом 2.0 вычисляется "
            + "правильно")]
    [TestCase(5.0, 523.5987755982989,
        TestName = "Volume Radius 5 Returns Correct Volume",
        Description =
            "Проверяет, что объем сферы с радиусом 5.0 вычисляется "
            + "правильно")]
    public void VolumeValidRadiusReturnsCorrectVolume(
        double radius, 
        double expectedVolume)
    {
        // Arrange
        Sphere sphere = new Sphere(radius);
        // Act
        double volume = sphere.Volume;
        // Assert
        Assert.That(volume, Is.EqualTo(expectedVolume).Within(_tolerance));
    }

    [Category("FigureType")]
    public void FigureTypeReturnsCorrectType()
    {
        // Arrange
        Sphere sphere = new Sphere(1.0);
        // Act
        string figureType = sphere.FigureType;
        // Assert
        Assert.That(figureType, Is.EqualTo("Sphere"));
    }

    [Category("GetDescription")]
    [Test]
    public void GetDescriptionReturnsCorrectFormat()
    {
        // Arrange
        Sphere sphere = new Sphere(1.0);
        string expectedDescription = $"Тип фигуры: {sphere.FigureType} " +
                $"| Радиус: {sphere.Radius} " +
                $"| Объём: {sphere.Volume:G}";
        // Act
        string description = sphere.GetDescription();
        // Assert
        Assert.That(description, Is.EqualTo(expectedDescription));
    }
}
