namespace ModelTestsCommon;

/// <summary>
/// Содержит общие проверки для тестов фигур.
/// </summary>
/// <typeparam name="T">Тип тестируемой фигуры.</typeparam>
public abstract class FigureTestsBase<T>
{
    /// <summary>
    /// Получает ожидаемый тип фигуры.
    /// </summary>
    protected abstract string ExpectedFigureType { get; }

    /// <summary>
    /// Создает фигуру со значениями по умолчанию.
    /// </summary>
    /// <returns>Экземпляр тестируемой фигуры.</returns>
    protected abstract T CreateDefaultFigure();

    /// <summary>
    /// Получает тип фигуры.
    /// </summary>
    /// <param name="figure">Тестируемая фигура.</param>
    /// <returns>Тип фигуры.</returns>
    protected abstract string GetFigureType(T figure);

    /// <summary>
    /// Получает описание фигуры.
    /// </summary>
    /// <param name="figure">Тестируемая фигура.</param>
    /// <returns>Описание фигуры.</returns>
    protected abstract string GetDescription(T figure);

    /// <summary>
    /// Создает ожидаемое описание фигуры.
    /// </summary>
    /// <param name="figure">Тестируемая фигура.</param>
    /// <returns>Ожидаемое описание фигуры.</returns>
    protected abstract string CreateExpectedDescription(T figure);

    /// <summary>
    /// Проверяет, что действие выбрасывает исключение
    /// <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <param name="action">Проверяемое действие.</param>
    protected static void AssertOutOfRange(Action action)
    {
        Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    /// <summary>
    /// Проверяет, что свойство FigureType возвращает корректный тип фигуры.
    /// </summary>
    [Category("FigureType")]
    [Test]
    public void FigureTypeReturnsCorrectType()
    {
        T figure = CreateDefaultFigure();

        string actualFigureType = GetFigureType(figure);

        Assert.That(actualFigureType, Is.EqualTo(ExpectedFigureType));
    }

    /// <summary>
    /// Проверяет, что метод GetDescription() возвращает описание фигуры
    /// в корректном формате.
    /// </summary>
    [Category("GetDescription")]
    [Test]
    public void GetDescriptionReturnsCorrectFormat()
    {
        T figure = CreateDefaultFigure();

        string expectedDescription = CreateExpectedDescription(figure);
        string actualDescription = GetDescription(figure);

        Assert.That(actualDescription, Is.EqualTo(expectedDescription));
    }
}