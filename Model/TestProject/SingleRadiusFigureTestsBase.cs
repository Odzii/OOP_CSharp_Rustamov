namespace ModelTestsCommon;

/// <summary>
/// Содержит общие проверки для фигур с радиусом.
/// </summary>
/// <typeparam name="T">Тип тестируемой фигуры.</typeparam>
public abstract class SingleRadiusFigureTestsBase<T>
    : FigureTestsBase<T>
{
    /// <summary>
    /// Радиус, используемый по умолчанию.
    /// </summary>
    private const double _defaultRadius = 1.0;

    /// <summary>
    /// Создает фигуру с указанным радиусом.
    /// </summary>
    /// <param name="radius">Радиус фигуры.</param>
    /// <returns>Экземпляр тестируемой фигуры.</returns>
    protected abstract T CreateFigure(double radius);

    /// <summary>
    /// Получает радиус фигуры.
    /// </summary>
    /// <param name="figure">Тестируемая фигура.</param>
    /// <returns>Радиус фигуры.</returns>
    protected abstract double GetRadius(T figure);

    /// <summary>
    /// Создает фигуру со значениями по умолчанию.
    /// </summary>
    /// <returns>Экземпляр тестируемой фигуры.</returns>
    protected override T CreateDefaultFigure()
    {
        return CreateFigure(_defaultRadius);
    }

    /// <summary>
    /// Проверяет, что конструктор выбрасывает исключение
    /// <see cref="ArgumentOutOfRangeException"/> при некорректном радиусе.
    /// </summary>
    /// <param name="radius">Некорректное значение радиуса.</param>
    [Category("Radius")]
    [TestCase(
        double.NaN,
        TestName = "Invalid Radius Not A Number",
        Description = "Проверяет, что создание фигуры с NaN радиусом вызывает "
            + "ArgumentOutOfRangeException")]
    [TestCase(
        double.PositiveInfinity,
        TestName = "Invalid Radius Positive Infinity",
        Description = "Проверяет, что создание фигуры с бесконечным радиусом "
            + "вызывает ArgumentOutOfRangeException")]
    [TestCase(
        double.NegativeInfinity,
        TestName = "Invalid Radius Negative Infinity",
        Description = "Проверяет, что создание фигуры с отрицательным бесконечным "
            + "радиусом вызывает ArgumentOutOfRangeException")]
    [TestCase(
        0.0,
        TestName = "Invalid Radius Zero",
        Description = "Проверяет, что создание фигуры с нулевым радиусом вызывает "
            + "ArgumentOutOfRangeException")]
    [TestCase(
        -1.0,
        TestName = "Invalid Radius Minus One",
        Description = "Проверяет, что создание фигуры с отрицательным радиусом "
            + "вызывает ArgumentOutOfRangeException")]
    [TestCase(
        -10.5,
        TestName = "Invalid Radius Minus 10_5",
        Description = "Проверяет, что создание фигуры с отрицательным радиусом "
            + "вызывает ArgumentOutOfRangeException")]
    [TestCase(
        -9999.5,
        TestName = "Invalid Radius Minus 9999_5",
        Description = "Проверяет, что создание фигуры с отрицательным радиусом "
            + "вызывает ArgumentOutOfRangeException")]
    public void ConstructorInvalidRadius(double radius)
    {
        Action action = () => CreateFigure(radius);

        AssertOutOfRange(action);
    }

    /// <summary>
    /// Проверяет, что конструктор корректно создает фигуру с
    /// положительным радиусом.
    /// </summary>
    /// <param name="radius">Корректное значение радиуса.</param>
    [Category("Radius")]
    [TestCase(
        1.0,
        TestName = "Valid Radius 1",
        Description = "Проверяет, " +
            "что можно создать фигуру с положительным радиусом")]
    [TestCase(
        5.0,
        TestName = "Valid Radius 5",
        Description = "Проверяет, " +
            "что можно создать фигуру с положительным радиусом")]
    [TestCase(
        15.5,
        TestName = "Valid Radius 15_5",
        Description = "Проверяет, " +
            "что можно создать фигуру с положительным радиусом")]
    public void ConstructorValidRadius(double radius)
    {
        T figure = CreateFigure(radius);

        Assert.That(GetRadius(figure), Is.EqualTo(radius));
    }
}
