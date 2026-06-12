namespace View.Serialization
{
    /// <summary>
    /// Представляет сериализуемую модель одной фигуры для сохранения в файл.
    /// </summary>
    /// <remarks>
    /// Класс используется как промежуточный контейнер данных между
    /// бизнес-моделью и файловым представлением.
    /// </remarks>
    public class FigureData
    {
        /// <summary>
        /// Представляет сериализуемую модель одной фигуры для сохранения в файл.
        /// </summary>
        /// <remarks>
        /// Класс используется как промежуточный контейнер данных между
        /// бизнес-моделью и файловым представлением.
        /// </remarks>
        public FigureType FigureKind { get; set; } = default!;

        /// <summary>
        /// Получает или задаёт вид фигуры.
        /// </summary>
        /// <value>
        /// Строковое значение, определяющее тип фигуры,
        /// например: <c>Сфера</c>, <c>Пирамида</c> или <c>Параллелепипед</c>.
        /// </value>
        public double? Radius { get; set; }

        /// <summary>
        /// Получает или задаёт радиус сферы.
        /// </summary>
        /// <value>
        /// Радиус фигуры типа <c>Сфера</c>;
        /// для остальных фигур значение может быть <see langword="null"/>.
        /// </value>
        public double? BaseLength { get; set; }

        /// <summary>
        /// Получает или задаёт ширину основания пирамиды.
        /// </summary>
        /// <value>
        /// Ширина основания фигуры типа <c>Пирамида</c>;
        /// для остальных фигур значение может быть <see langword="null"/>.
        /// </value>
        public double? BaseWidth { get; set; }

        /// <summary>
        /// Получает или задаёт длину параллелепипеда.
        /// </summary>
        /// <value>
        /// Длина фигуры типа <c>Параллелепипед</c>;
        /// для остальных фигур значение может быть <see langword="null"/>.
        /// </value>
        public double? Length { get; set; }

        /// <summary>
        /// Получает или задаёт ширину параллелепипеда.
        /// </summary>
        /// <value>
        /// Ширина фигуры типа <c>Параллелепипед</c>;
        /// для остальных фигур значение может быть <see langword="null"/>.
        /// </value>
        public double? Width { get; set; }

        /// <summary>
        /// Получает или задаёт высоту фигуры.
        /// </summary>
        /// <value>
        /// Высота пирамиды или параллелепипеда;
        /// для сферы значение может быть <see langword="null"/>.
        /// </value>
        public double? Height { get; set; }

        /// <summary>
        /// Определяет, нужно ли сериализовать свойство <see cref="Radius"/>.
        /// </summary>
        /// <remarks>
        /// Свойство сериализуется только в том случае, если оно содержит значение.
        /// Это позволяет не записывать в XML параметры, которые не относятся
        /// к текущему типу фигуры.
        /// </remarks>
        /// <returns>
        /// <see langword="true"/>, если радиус задан; иначе <see langword="false"/>.
        /// </returns>
        public bool ShouldSerializeRadius()
        {
            return Radius.HasValue;
        }

        /// <summary>
        /// Определяет, нужно ли сериализовать свойство <see cref="BaseLength"/>.
        /// </summary>
        /// <remarks>
        /// Свойство сериализуется только для фигур, у которых задана длина основания,
        /// например для пирамиды.
        /// </remarks>
        /// <returns>
        /// <see langword="true"/>, если длина основания задана; иначе <see langword="false"/>.
        /// </returns>
        public bool ShouldSerializeBaseLength()
        {
            return BaseLength.HasValue;
        }

        /// <summary>
        /// Определяет, нужно ли сериализовать свойство <see cref="BaseWidth"/>.
        /// </summary>
        /// <remarks>
        /// Свойство сериализуется только для фигур, у которых задана ширина основания,
        /// например для пирамиды.
        /// </remarks>
        /// <returns>
        /// <see langword="true"/>, если ширина основания задана; иначе <see langword="false"/>.
        /// </returns>
        public bool ShouldSerializeBaseWidth()
        {
            return BaseWidth.HasValue;
        }

        /// <summary>
        /// Определяет, нужно ли сериализовать свойство <see cref="Length"/>.
        /// </summary>
        /// <remarks>
        /// Свойство сериализуется только для фигур, у которых задана длина,
        /// например для параллелепипеда.
        /// </remarks>
        /// <returns>
        /// <see langword="true"/>, если длина задана; иначе <see langword="false"/>.
        /// </returns>
        public bool ShouldSerializeLength()
        {
            return Length.HasValue;
        }

        /// <summary>
        /// Определяет, нужно ли сериализовать свойство <see cref="Width"/>.
        /// </summary>
        /// <remarks>
        /// Свойство сериализуется только для фигур, у которых задана ширина,
        /// например для параллелепипеда.
        /// </remarks>
        /// <returns>
        /// <see langword="true"/>, если ширина задана; иначе <see langword="false"/>.
        /// </returns>
        public bool ShouldSerializeWidth()
        {
            return Width.HasValue;
        }

        /// <summary>
        /// Определяет, нужно ли сериализовать свойство <see cref="Height"/>.
        /// </summary>
        /// <remarks>
        /// Свойство сериализуется только для фигур, у которых задана высота,
        /// например для пирамиды или параллелепипеда.
        /// </remarks>
        /// <returns>
        /// <see langword="true"/>, если высота задана; иначе <see langword="false"/>.
        /// </returns>
        public bool ShouldSerializeHeight()
        {
            return Height.HasValue;
        }
    }
}