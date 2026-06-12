namespace ModelSphereTests;

/// <summary>
/// Содержит модульные тесты для класса <see cref="Sphere"/>.
/// </summary>
public class SphereTests
{
    /// <summary>
    /// Проверяет, что конструктор класса <see cref="Sphere"/> выбрасывает
    /// исключение <see cref="ArgumentOutOfRangeException"/> при некорректном
    /// радиусе.
    /// </summary>
    /// <param name="radius">Некорректное значение радиуса.</param>
    [Category("Radius")]
    [TestCase(
        double.NaN,
        TestName = "Invalid Radius Not A Number",
        Description = "Проверяет, что создание сферы с NaN радиусом вызывает "
            + "ArgumentException")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Radius Positive Infinity",
        Description = "Проверяет, что создание сферы с бесконечным радиусом "
            + "вызывает ArgumentException")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Radius Negative Infinity",
        Description = "Проверяет, что создание сферы " +
            "с отрицательным бесконечным радиусом вызывает ArgumentException")]
    [TestCase(
        0.0,
        TestName = "Invalid Radius Zero",
        Description = "Проверяет, что создание сферы с нулевым радиусом " +
            "вызывает ArgumentException")]
    [TestCase(
        -1.0,
        TestName = "Invalid Radius Minus One",
        Description = "Проверяет, что создание сферы с отрицательным радиусом "
            + "вызывает ArgumentException")]
    [TestCase(
        -1.0,
        TestName = "Invalid Radius Minus One Again",
        Description = "Проверяет, что создание сферы с отрицательным радиусом "
            + "вызывает ArgumentException")]
    [TestCase(
        -10.5,
        TestName = "Invalid Radius Minus 10_5",
        Description = "Проверяет, что создание сферы с большим отрицательным "
            + "радиусом вызывает ArgumentException")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Radius Minus 9999_5",
        Description = "Проверяет, что создание сферы с небольшим отрицательным "
            + "радиусом вызывает ArgumentException")]
    public void ConstructorInvalidRadius(double radius)
    {
        Action action = () => new Sphere(radius);

        Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    /// <summary>
    /// Проверяет, что конструктор класса <see cref="Sphere"/> корректно
    /// создает сферу с положительным радиусом.
    /// </summary>
    /// <param name="radius">Корректное значение радиуса.</param>
    [Category("Radius")]
    [TestCase(1.0,
        TestName = "Valid Radius 1",
        Description = "Проверяет, " +
            "что можно создать сферу с положительным радиусом")]
    [TestCase(5.0,
        TestName = "Valid Radius 5",
        Description = "Проверяет, " +
            "что можно создать сферу с положительным радиусом")]
    [TestCase(15.5,
        TestName = "Valid Radius 15_5",
        Description = "Проверяет, " +
            "что можно создать сферу с положительным радиусом")]
    public void ConstructorValidRadius(double radius)
    {
        Sphere sphere = new Sphere(radius);

        Assert.That(sphere.Radius, Is.EqualTo(radius));
    }

    /// <summary>
    /// Проверяет, что свойство Volume возвращает корректный объем сферы.
    /// </summary>
    /// <param name="radius">Значение радиуса сферы.</param>
    /// <param name="expectedVolume">Ожидаемое значение объема сферы.</param>
    [Category("Volume")]
    [TestCase(1.0, 4.1887902047863905,
        TestName = "Volume Radius 1 Returns Correct Volume",
        Description = "Проверяет, что объем сферы с радиусом 1.0 вычисляется "
            + "правильно")]
    [TestCase(2.0, 33.510321638291124,
        TestName = "Volume Radius 2 Returns Correct Volume",
        Description = "Проверяет, что объем сферы с радиусом 2.0 вычисляется "
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
        Sphere sphere = new Sphere(radius);

        double volume = sphere.Volume;

        Assert.That(volume, Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
    }

    /// <summary>
    /// Проверяет, что свойство FigureType возвращает корректный тип фигуры.
    /// </summary>
    [Category("FigureType")]
    public void FigureTypeReturnsCorrectType()
    {
        Sphere sphere = new Sphere(1.0);

        string figureType = sphere.FigureType;

        Assert.That(figureType, Is.EqualTo("Sphere"));
    }

    /// <summary>
    /// Проверяет, что метод GetDescription() возвращает описание сферы
    /// в корректном формате.
    /// </summary>
    [Category("GetDescription")]
    [Test]
    public void GetDescriptionReturnsCorrectFormat()
    {

        Sphere sphere = new Sphere(1.0);

        string expectedDescription = $"Тип фигуры: {sphere.FigureType} " +
                $"| Радиус: {sphere.Radius} " +
                $"| Объём: {sphere.Volume:G}";

        string description = sphere.GetDescription();

        Assert.That(description, Is.EqualTo(expectedDescription));
    }
}