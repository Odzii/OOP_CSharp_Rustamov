using Model;

namespace View.Helper
{
    /// <summary>
    /// Предоставляет методы расширения для типа <see cref="FigureType"/>.
    /// </summary>
    public static class FigureTypeExtensions
    {
        /// <summary>
        /// Возвращает отображаемое название типа фигуры.
        /// </summary>
        /// <param name="type">Тип объёмной фигуры.</param>
        /// <returns>
        /// Название типа фигуры, предназначенное для отображения пользователю.
        /// </returns>
        public static string ToDisplay(this FigureType type) => type switch
        {
            FigureType.Sphere => "Сфера",
            FigureType.Pyramid => "Пирамида",
            FigureType.Parallelepiped => "Параллелепипед",
            _ => type.ToString()
        };
    }
}