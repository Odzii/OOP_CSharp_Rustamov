namespace ModelParallelepipedTests;

/// <summary>
/// Содержит модульные тесты для класса <see cref="Parallelepiped"/>.
/// </summary>
public class ParallelepipedTests : RectangularBaseFigureTestsBase<Parallelepiped>
{
    /// <summary>
    /// Получает ожидаемый тип фигуры.
    /// </summary>
    protected override string ExpectedFigureType => "Параллелепипед";

    /// <summary>
    /// Создает параллелепипед с указанными размерами.
    /// </summary>
    /// <param name="baseLength">Длина основания.</param>
    /// <param name="baseWidth">Ширина основания.</param>
    /// <param name="height">Высота.</param>
    /// <returns>Экземпляр класса <see cref="Parallelepiped"/>.</returns>
    protected override Parallelepiped CreateFigure(
        double baseLength,
        double baseWidth,
        double height)
    {
        return new Parallelepiped(baseLength, baseWidth, height);
    }

    /// <summary>
    /// Получает длину основания параллелепипеда.
    /// </summary>
    /// <param name="parallelepiped">Тестируемый параллелепипед.</param>
    /// <returns>Длина основания параллелепипеда.</returns>
    protected override double GetBaseLength(Parallelepiped parallelepiped)
    {
        return parallelepiped.Length;
    }

    /// <summary>
    /// Получает ширину основания параллелепипеда.
    /// </summary>
    /// <param name="parallelepiped">Тестируемый параллелепипед.</param>
    /// <returns>Ширина основания параллелепипеда.</returns>
    protected override double GetBaseWidth(Parallelepiped parallelepiped)
    {
        return parallelepiped.Width;
    }

    /// <summary>
    /// Получает высоту параллелепипеда.
    /// </summary>
    /// <param name="parallelepiped">Тестируемый параллелепипед.</param>
    /// <returns>Высота параллелепипеда.</returns>
    protected override double GetHeight(Parallelepiped parallelepiped)
    {
        return parallelepiped.Height;
    }

    /// <summary>
    /// Получает тип фигуры.
    /// </summary>
    /// <param name="parallelepiped">Тестируемый параллелепипед.</param>
    /// <returns>Тип фигуры.</returns>
    protected override string GetFigureType(Parallelepiped parallelepiped)
    {
        return parallelepiped.FigureType;
    }

    /// <summary>
    /// Получает описание параллелепипеда.
    /// </summary>
    /// <param name="parallelepiped">Тестируемый параллелепипед.</param>
    /// <returns>Описание параллелепипеда.</returns>
    protected override string GetDescription(Parallelepiped parallelepiped)
    {
        return parallelepiped.GetDescription();
    }

    /// <summary>
    /// Создает ожидаемое описание параллелепипеда.
    /// </summary>
    /// <param name="parallelepiped">Тестируемый параллелепипед.</param>
    /// <returns>Ожидаемое описание параллелепипеда.</returns>
    protected override string CreateExpectedDescription(
        Parallelepiped parallelepiped)
    {
        return $"Тип фигуры: {parallelepiped.FigureType} "
            + $"| Длина: {parallelepiped.Length} "
            + $"| Ширина: {parallelepiped.Width} "
            + $"| Высота: {parallelepiped.Height} "
            + $"| Объем: {parallelepiped.Volume:G}";
    }

    /// <summary>
    /// Проверяет, что свойство Volume возвращает корректный объем
    /// параллелепипеда.
    /// </summary>
    /// <param name="baseLength">Длина основания.</param>
    /// <param name="baseWidth">Ширина основания.</param>
    /// <param name="expectedVolume">Ожидаемый объем.</param>
    [Category("Volume")]
    [TestCase(
        3.5,
        4.0,
        140.0,
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
    public void VolumeValidDimensions(
        double baseLength,
        double baseWidth,
        double expectedVolume)
    {
        Parallelepiped parallelepiped = CreateFigure(
            baseLength,
            baseWidth,
            10.0);

        double actualVolume = parallelepiped.Volume;

        Assert.That(
            actualVolume,
            Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
    }
}
