namespace ModelPyramidTests
{
    /// <summary>
    /// Содержит модульные тесты для класса <see cref="Pyramid"/>.
    /// </summary>
    public class PyramidTests : RectangularBaseFigureTestsBase<Pyramid>
    {
        /// <summary>
        /// Получает ожидаемый тип фигуры.
        /// </summary>
        protected override string ExpectedFigureType => "Пирамида";

        /// <summary>
        /// Создает пирамиду с указанными размерами.
        /// </summary>
        /// <param name="baseLength">Длина основания пирамиды.</param>
        /// <param name="baseWidth">Ширина основания пирамиды.</param>
        /// <param name="height">Высота пирамиды.</param>
        /// <returns>Экземпляр класса <see cref="Pyramid"/>.</returns>
        protected override Pyramid CreateFigure(
            double baseLength,
            double baseWidth,
            double height)
        {
            return new Pyramid(baseLength, baseWidth, height);
        }

        /// <summary>
        /// Создает пирамиду со значениями по умолчанию.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Pyramid"/>.</returns>
        protected override Pyramid CreateDefaultFigure()
        {
            return CreateFigure(3.0, 3.0, 3.0);
        }

        /// <summary>
        /// Получает длину основания пирамиды.
        /// </summary>
        /// <param name="pyramid">Тестируемая пирамида.</param>
        /// <returns>Длина основания пирамиды.</returns>
        protected override double GetBaseLength(Pyramid pyramid)
        {
            return pyramid.BaseLength;
        }

        /// <summary>
        /// Получает ширину основания пирамиды.
        /// </summary>
        /// <param name="pyramid">Тестируемая пирамида.</param>
        /// <returns>Ширина основания пирамиды.</returns>
        protected override double GetBaseWidth(Pyramid pyramid)
        {
            return pyramid.BaseWidth;
        }

        /// <summary>
        /// Получает высоту пирамиды.
        /// </summary>
        /// <param name="pyramid">Тестируемая пирамида.</param>
        /// <returns>Высота пирамиды.</returns>
        protected override double GetHeight(Pyramid pyramid)
        {
            return pyramid.Height;
        }

        /// <summary>
        /// Получает тип фигуры.
        /// </summary>
        /// <param name="pyramid">Тестируемая пирамида.</param>
        /// <returns>Тип фигуры.</returns>
        protected override string GetFigureType(Pyramid pyramid)
        {
            return pyramid.FigureType;
        }

        /// <summary>
        /// Получает описание пирамиды.
        /// </summary>
        /// <param name="pyramid">Тестируемая пирамида.</param>
        /// <returns>Описание пирамиды.</returns>
        protected override string GetDescription(Pyramid pyramid)
        {
            return pyramid.GetDescription();
        }

        /// <summary>
        /// Создает ожидаемое описание пирамиды.
        /// </summary>
        /// <param name="pyramid">Тестируемая пирамида.</param>
        /// <returns>Ожидаемое описание пирамиды.</returns>
        protected override string CreateExpectedDescription(Pyramid pyramid)
        {
            return $"Тип фигуры: {pyramid.FigureType} "
                + $"| Основание: {pyramid.BaseLength} х {pyramid.BaseWidth} "
                + $"| Высота пирамиды: {pyramid.Height} "
                + $"| Объем: {pyramid.Volume:G}";
        }

        /// <summary>
        /// Проверяет, что свойство BaseArea возвращает корректную площадь
        /// основания пирамиды.
        /// </summary>
        /// <param name="baseLength">Длина основания пирамиды.</param>
        /// <param name="baseWidth">Ширина основания пирамиды.</param>
        /// <param name="expectedBaseArea">
        /// Ожидаемая площадь основания пирамиды.
        /// </param>
        [Category("BaseArea")]
        [TestCase(
            10.0,
            5.0,
            50.0,
            TestName = "Base Area 10 By 5 Returns 50",
            Description =
                "Проверяет, что площадь основания пирамиды 10 x 5 "
                + "равна 50")]
        [TestCase(
            2.5,
            4.0,
            10.0,
            TestName = "Base Area 2_5 By 4 Returns 10",
            Description =
                "Проверяет, что площадь основания пирамиды 2_5 x 4 "
                + "равна 10")]
        [TestCase(
            3.0,
            3.0,
            9.0,
            TestName = "Base Area 3 By 3 Returns 9",
            Description =
                "Проверяет, что площадь квадратного основания 3 x 3 "
                + "равна 9")]
        public void BaseAreaValidBaseLengthAndBaseWidth(
            double baseLength,
            double baseWidth,
            double expectedBaseArea)
        {
            Pyramid pyramid = CreateFigure(baseLength, baseWidth, 10.0);

            double actualBaseArea = pyramid.BaseArea;

            Assert.That(
                actualBaseArea,
                Is.EqualTo(expectedBaseArea).Within(Settings.Tolerance));
        }

        /// <summary>
        /// Проверяет, что свойство Volume возвращает корректный объем
        /// пирамиды.
        /// </summary>
        /// <param name="baseLength">Длина основания пирамиды.</param>
        /// <param name="baseWidth">Ширина основания пирамиды.</param>
        /// <param name="height">Высота пирамиды.</param>
        /// <param name="expectedVolume">Ожидаемый объем пирамиды.</param>
        [Category("Volume")]
        [TestCase(
            10.0,
            5.0,
            3.0,
            50.0,
            TestName = "Volume 10 By 5 By 3 Returns 50",
            Description =
                "Проверяет, что объём пирамиды 10 x 5 x 3 равен 50")]
        [TestCase(
            3.0,
            3.0,
            3.0,
            9.0,
            TestName = "Volume 3 By 3 By 3 Returns 9",
            Description =
                "Проверяет, что объём пирамиды 3 x 3 x 3 равен 9")]
        [TestCase(
            10.0,
            10.0,
            10.0,
            333.3333333333333,
            TestName = "Volume 10 By 10 By 10 Returns 333_333333",
            Description =
                "Проверяет, что объём пирамиды 10 x 10 x 10 равен "
                + "333_333333")]
        public void VolumeValidValues(
            double baseLength,
            double baseWidth,
            double height,
            double expectedVolume)
        {
            Pyramid pyramid = CreateFigure(baseLength, baseWidth, height);

            double actualVolume = pyramid.Volume;

            Assert.That(
                actualVolume,
                Is.EqualTo(expectedVolume).Within(Settings.Tolerance));
        }

        /// <summary>
        /// Проверяет, что вычисление слишком большого объема пирамиды
        /// выбрасывает исключение <see cref="OverflowException"/>.
        /// </summary>
        [Category("Volume")]
        [Test]
        [Description(
            "Проверяет, что слишком большой объём пирамиды вызывает "
            + "OverflowException")]
        public void VolumeTooLargeValues()
        {
            Pyramid pyramid = CreateFigure(
                double.MaxValue,
                double.MaxValue,
                double.MaxValue);

            Action action = () =>
            {
                _ = pyramid.Volume;
            };

            Assert.That(action, Throws.TypeOf<OverflowException>());
        }
    }
}
