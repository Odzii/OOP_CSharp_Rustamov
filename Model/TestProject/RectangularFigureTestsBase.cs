namespace ModelTestsCommon;

/// <summary>
/// Содержит общие проверки для фигур с основанием и высотой.
/// </summary>
/// <typeparam name="T">Тип тестируемой фигуры.</typeparam>
public abstract class RectangularBaseFigureTestsBase<T> : FigureTestsBase<T>
{
    /// <summary>
    /// Длина основания, используемая по умолчанию.
    /// </summary>
    private const double _defaultBaseLength = 10.0;

    /// <summary>
    /// Ширина основания, используемая по умолчанию.
    /// </summary>
    private const double _defaultBaseWidth = 15.0;

    /// <summary>
    /// Высота, используемая по умолчанию.
    /// </summary>
    private const double _defaultHeight = 20.0;

    /// <summary>
    /// Создает фигуру с указанными размерами.
    /// </summary>
    /// <param name="baseLength">Длина основания.</param>
    /// <param name="baseWidth">Ширина основания.</param>
    /// <param name="height">Высота.</param>
    /// <returns>Экземпляр тестируемой фигуры.</returns>
    protected abstract T CreateFigure(
        double baseLength,
        double baseWidth,
        double height);

    /// <summary>
    /// Получает длину основания фигуры.
    /// </summary>
    /// <param name="figure">Тестируемая фигура.</param>
    /// <returns>Длина основания фигуры.</returns>
    protected abstract double GetBaseLength(T figure);

    /// <summary>
    /// Получает ширину основания фигуры.
    /// </summary>
    /// <param name="figure">Тестируемая фигура.</param>
    /// <returns>Ширина основания фигуры.</returns>
    protected abstract double GetBaseWidth(T figure);

    /// <summary>
    /// Получает высоту фигуры.
    /// </summary>
    /// <param name="figure">Тестируемая фигура.</param>
    /// <returns>Высота фигуры.</returns>
    protected abstract double GetHeight(T figure);

    /// <summary>
    /// Создает фигуру со значениями по умолчанию.
    /// </summary>
    /// <returns>Экземпляр тестируемой фигуры.</returns>
    protected override T CreateDefaultFigure()
    {
        return CreateFigure(
            _defaultBaseLength,
            _defaultBaseWidth,
            _defaultHeight);
    }

    /// <summary>
    /// Проверяет, что конструктор выбрасывает исключение
    /// <see cref="ArgumentOutOfRangeException"/> при некорректной длине
    /// основания.
    /// </summary>
    /// <param name="baseLength">Некорректная длина основания.</param>
    [Category("BaseLength")]
    [TestCase(
        double.NaN,
        TestName = "Invalid Base Length Not A Number",
        Description = "Проверяет, что нельзя создать фигуру с NaN в BaseLength")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Base Length Positive Infinity",
        Description = "Проверяет, что нельзя создать фигуру с положительной "
            + "бесконечностью в BaseLength")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Base Length Negative Infinity",
        Description = "Проверяет, что нельзя создать фигуру с отрицательной "
            + "бесконечностью в BaseLength")]
    [TestCase(
        0.0,
        TestName = "Invalid Base Length Zero",
        Description = "Проверяет, что нельзя создать фигуру " +
            "с нулевым BaseLength")]
    [TestCase(
        -1.0,
        TestName = "Invalid Base Length Minus One",
        Description = "Проверяет, что нельзя создать фигуру с отрицательным "
            + "BaseLength")]
    [TestCase(
        -10.5,
        TestName = "Invalid Base Length Minus 10_5",
        Description = "Проверяет, что нельзя создать фигуру с отрицательным "
            + "BaseLength")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Base Length Minus 9999_5",
        Description = "Проверяет, что нельзя создать фигуру с отрицательным "
            + "BaseLength")]
    public void ConstructorInvalidBaseLength(double baseLength)
    {
        Action action = () => CreateFigure(
            baseLength,
            _defaultBaseWidth,
            _defaultHeight);

        AssertOutOfRange(action);
    }

    /// <summary>
    /// Проверяет, что конструктор выбрасывает исключение
    /// <see cref="ArgumentOutOfRangeException"/> при некорректной ширине
    /// основания.
    /// </summary>
    /// <param name="baseWidth">Некорректная ширина основания.</param>
    [Category("BaseWidth")]
    [TestCase(
        double.NaN,
        TestName = "Invalid Base Width Not A Number",
        Description = "Проверяет, что нельзя создать фигуру " +
            "с NaN в BaseWidth")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Base Width Positive Infinity",
        Description = "Проверяет, что нельзя создать фигуру с положительной "
            + "бесконечностью в BaseWidth")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Base Width Negative Infinity",
        Description = "Проверяет, что нельзя создать фигуру с отрицательной "
            + "бесконечностью в BaseWidth")]
    [TestCase(
        0.0,
        TestName = "Invalid Base Width Zero",
        Description = "Проверяет, что нельзя создать фигуру " +
            "с нулевым BaseWidth")]
    [TestCase(
        -1.0,
        TestName = "Invalid Base Width Minus One",
        Description = "Проверяет, что нельзя создать фигуру с отрицательным "
            + "BaseWidth")]
    [TestCase(
        -10.5,
        TestName = "Invalid Base Width Minus 10_5",
        Description = "Проверяет, что нельзя создать фигуру с отрицательным "
            + "BaseWidth")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Base Width Minus 9999_5",
        Description = "Проверяет, что нельзя создать фигуру с отрицательным "
            + "BaseWidth")]
    public void ConstructorInvalidBaseWidth(double baseWidth)
    {
        Action action = () => CreateFigure(
            _defaultBaseLength,
            baseWidth,
            _defaultHeight);

        AssertOutOfRange(action);
    }

    /// <summary>
    /// Проверяет, что конструктор выбрасывает исключение
    /// <see cref="ArgumentOutOfRangeException"/> при некорректной высоте.
    /// </summary>
    /// <param name="height">Некорректная высота.</param>
    [Category("Height")]
    [TestCase(
        double.NaN,
        TestName = "Invalid Height Not A Number",
        Description = "Проверяет, что нельзя создать фигуру с NaN в Height")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Height Positive Infinity",
        Description = "Проверяет, что нельзя создать фигуру с положительной "
            + "бесконечностью в Height")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Height Negative Infinity",
        Description = "Проверяет, что нельзя создать фигуру с отрицательной "
            + "бесконечностью в Height")]
    [TestCase(
        0.0,
        TestName = "Invalid Height Zero",
        Description = "Проверяет, что нельзя создать фигуру с нулевым Height")]
    [TestCase(
        -1.0,
        TestName = "Invalid Height Minus One",
        Description = "Проверяет, что нельзя создать фигуру " +
            "с отрицательным Height")]
    [TestCase(
        -10.5,
        TestName = "Invalid Height Minus 10_5",
        Description = "Проверяет, что нельзя создать фигуру " +
            "с отрицательным Height")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Height Minus 9999_5",
        Description = "Проверяет, что нельзя создать фигуру " +
            "с отрицательным Height")]
    public void ConstructorInvalidHeight(double height)
    {
        Action action = () => CreateFigure(
            _defaultBaseLength,
            _defaultBaseWidth,
            height);

        AssertOutOfRange(action);
    }

    /// <summary>
    /// Проверяет, что конструктор записывает корректную длину основания.
    /// </summary>
    /// <param name="baseLength">Корректная длина основания.</param>
    [Category("BaseLength")]
    [TestCase(
        15.5,
        TestName = "Valid Base Length 15_5",
        Description = "Проверяет, что конструктор записывает BaseLength")]
    [TestCase(
        500.0,
        TestName = "Valid Base Length 500",
        Description = "Проверяет, что конструктор записывает BaseLength")]
    [TestCase(
        1000.5,
        TestName = "Valid Base Length 1000_5",
        Description = "Проверяет, что конструктор записывает BaseLength")]
    public void ConstructorValidBaseLength(double baseLength)
    {
        T figure = CreateFigure(
            baseLength,
            _defaultBaseWidth,
            _defaultHeight);

        Assert.That(GetBaseLength(figure), Is.EqualTo(baseLength));
    }

    /// <summary>
    /// Проверяет, что конструктор записывает корректную ширину основания.
    /// </summary>
    /// <param name="baseWidth">Корректная ширина основания.</param>
    [Category("BaseWidth")]
    [TestCase(
        15.5,
        TestName = "Valid Base Width 15_5",
        Description = "Проверяет, что конструктор записывает BaseWidth")]
    [TestCase(
        500.0,
        TestName = "Valid Base Width 500",
        Description = "Проверяет, что конструктор записывает BaseWidth")]
    [TestCase(
        1000.5,
        TestName = "Valid Base Width 1000_5",
        Description = "Проверяет, что конструктор записывает BaseWidth")]
    public void ConstructorValidBaseWidth(double baseWidth)
    {
        T figure = CreateFigure(
            _defaultBaseLength,
            baseWidth,
            _defaultHeight);

        Assert.That(GetBaseWidth(figure), Is.EqualTo(baseWidth));
    }

    /// <summary>
    /// Проверяет, что конструктор записывает корректную высоту.
    /// </summary>
    /// <param name="height">Корректная высота.</param>
    [Category("Height")]
    [TestCase(
        15.5,
        TestName = "Valid Height 15_5",
        Description = "Проверяет, что конструктор записывает Height")]
    [TestCase(
        500.0,
        TestName = "Valid Height 500",
        Description = "Проверяет, что конструктор записывает Height")]
    [TestCase(
        1000.5,
        TestName = "Valid Height 1000_5",
        Description = "Проверяет, что конструктор записывает Height")]
    public void ConstructorValidHeight(double height)
    {
        T figure = CreateFigure(
            _defaultBaseLength,
            _defaultBaseWidth,
            height);

        Assert.That(GetHeight(figure), Is.EqualTo(height));
    }
}
