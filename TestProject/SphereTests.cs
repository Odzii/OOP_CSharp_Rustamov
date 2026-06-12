namespace ModelSphereTests;

/// <summary>
/// Содержит модульные тесты для класса <see cref="Sphere"/>.
/// </summary>
public class SphereTests : SingleRadiusFigureTestsBase<Sphere>
{
    /// <summary>
    /// Получает ожидаемый тип фигуры.
    /// </summary>
    protected override string ExpectedFigureType => "Сфера";

    /// <summary>
    /// Создает сферу с указанным радиусом.
    /// </summary>
    /// <param name="radius">Радиус сферы.</param>
    /// <returns>Экземпляр класса <see cref="Sphere"/>.</returns>
    protected override Sphere CreateFigure(double radius)
    {
        return new Sphere(radius);
    }

    /// <summary>
    /// Получает радиус сферы.
    /// </summary>
    /// <param name="sphere">Тестируемая сфера.</param>
    /// <returns>Радиус сферы.</returns>
    protected override double GetRadius(Sphere sphere)
    {
        return sphere.Radius;
    }

    /// <summary>
    /// Получает тип фигуры.
    /// </summary>
    /// <param name="sphere">Тестируемая сфера.</param>
    /// <returns>Тип фигуры.</returns>
    protected override string GetFigureType(Sphere sphere)
    {
        return sphere.FigureType;
    }

    /// <summary>
    /// Получает описание сферы.
    /// </summary>
    /// <param name="sphere">Тестируемая сфера.</param>
    /// <returns>Описание сферы.</returns>
    protected override string GetDescription(Sphere sphere)
    {
        return sphere.GetDescription();
    }

    /// <summary>
    /// Создает ожидаемое описание сферы.
    /// </summary>
    /// <param name="sphere">Тестируемая сфера.</param>
    /// <returns>Ожидаемое описание сферы.</returns>
    protected override string CreateExpectedDescription(Sphere sphere)
    {
        return $"Тип фигуры: {sphere.FigureType} "
            + $"| Радиус: {sphere.Radius} "
            + $"| Объём: {sphere.Volume:G}";
    }

    /// <summary>
    /// Проверяет, что свойство Volume возвращает корректный объем сферы.
    /// </summary>
    /// <param name="radius">Значение радиуса сферы.</param>
    /// <param name="expectedVolume">Ожидаемый объем сферы.</param>
    [Category("Volume")]
    [TestCase(
        1.0,
        4.1887902047863905,
        TestName = "Volume Radius 1 Returns Correct Volume",
        Description = "Проверяет, что объем сферы с радиусом 1.0 вычисляется "
            + "правильно")]
    [TestCase(
        2.0,
        33.510321638291124,
        TestName = "Volume Radius 2 Returns Correct Volume",
        Description = "Проверяет, что объем сферы с радиусом 2.0 вычисляется "
            + "правильно")]
    [TestCase(
        5.0,
        523.5987755982989,
        TestName = "Volume Radius 5 Returns Correct Volume",
        Description = "Проверяет, что объем сферы с радиусом 5.0 вычисляется "
            + "правильно")]
    public void VolumeValidRadiusReturnsCorrectVolume(
        double radius,
        double expectedVolume)
    {
        Sphere sphere = CreateFigure(radius);

        double actualVolume = sphere.Volume;

        Assert.That(
            actualVolume,
            Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
    }
}
