namespace ModelPyramidTests
{
    public class PyramidTests
    {
        /// <summary>
        /// Допустимая погрешность для сравнения числовых значений типа double.
        /// </summary>
        private const double _tolerance = 1e-6;

        // Arrange
        [Category("BaseLength")]
        [TestCase(
            double.NaN,
            TestName = "Constructor InvalidBaseLengthNaN ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с NaN в BaseLength")]
        [TestCase(
            double.PositiveInfinity,
            TestName = "Constructor InvalidBaseLengthPositiveInfinity ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с положительной бесконечностью в BaseLength")]
        [TestCase(
            double.NegativeInfinity,
            TestName = "Constructor InvalidBaseLengthNegativeInfinity ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательной бесконечностью в BaseLength")]
        [TestCase(
            0.0,
            TestName = "Constructor InvalidBaseLengthZero ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с нулевым BaseLength")]
        [TestCase(
            -1.0,
            TestName = "Constructor InvalidBaseLengthMinus 1 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным BaseLength")]
        [TestCase(
            -10.5,
            TestName = "Constructor InvalidBaseLengthMinus 10_5 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным BaseLength")]
        [TestCase(
            -9999.5,
            TestName = "Constructor InvalidBaseLengthMinus 9999_5 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным BaseLength")]
        public void ConstructorInvalidBaseLengthThrowsArgumentOutOfRangeException(
            double baseLength)
        {
            double baseWidth = 10.0;
            double height = 15.0;

            // Act
            TestDelegate act = () => new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                act,
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        // Arrange
        [Category("BaseWidth")]
        [TestCase(
            double.NaN,
            TestName = "Constructor InvalidBaseWidthNaN ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с NaN в BaseWidth")]
        [TestCase(
            double.PositiveInfinity,
            TestName = "Constructor InvalidBaseWidthPositiveInfinity ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с положительной бесконечностью в BaseWidth")]
        [TestCase(
            double.NegativeInfinity,
            TestName = "Constructor InvalidBaseWidthNegativeInfinity ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательной бесконечностью в BaseWidth")]
        [TestCase(
            0.0,
            TestName = "Constructor InvalidBaseWidthZero ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с нулевым BaseWidth")]
        [TestCase(
            -1.0,
            TestName = "Constructor InvalidBaseWidthMinus 1 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным BaseWidth")]
        [TestCase(
            -10.5,
            TestName = "Constructor InvalidBaseWidthMinus 10_5 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным BaseWidth")]
        [TestCase(
            -9999.5,
            TestName = "Constructor InvalidBaseWidthMinus 9999_5 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным BaseWidth")]
        public void ConstructorInvalidBaseWidthThrowsArgumentOutOfRangeException(
            double baseWidth)
        {
            double baseLength = 10.0;
            double height = 15.0;

            // Act
            TestDelegate act = () => new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                act,
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        // Arrange
        [Category("Height")]
        [TestCase(
            double.NaN,
            TestName = "Constructor InvalidHeightNaN ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с NaN в Height")]
        [TestCase(
            double.PositiveInfinity,
            TestName = "Constructor InvalidHeightPositiveInfinity ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с положительной бесконечностью в Height")]
        [TestCase(
            double.NegativeInfinity,
            TestName = "Constructor InvalidHeightNegativeInfinity ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательной бесконечностью в Height")]
        [TestCase(
            0.0,
            TestName = "Constructor InvalidHeightZero ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с нулевым Height")]
        [TestCase(
            -1.0,
            TestName = "Constructor InvalidHeight minus 1 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным Height")]
        [TestCase(
            -10.5,
            TestName = "Constructor InvalidHeight minus 10_5 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным Height")]
        [TestCase(
            -9999.5,
            TestName = "Constructor InvalidHeight minus 9999_5 ThrowsArgumentOutOfRangeException",
            Description = "Проверяет, что нельзя создать пирамиду с отрицательным Height")]
        public void ConstructorInvalidHeightThrowsArgumentOutOfRangeException(
            double height)
        {
            double baseLength = 10.0;
            double baseWidth = 15.0;

            // Act
            TestDelegate act = () => new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                act,
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        // Arrange
        [Category("BaseLength")]
        [TestCase(
            15.5,
            TestName = "Constructor ValidBaseLength 15_5 SetsBaseLength",
            Description = "Проверяет, что конструктор записывает корректное значение BaseLength")]
        [TestCase(
            500.0,
            TestName = "Constructor ValidBaseLength 500 SetsBaseLength",
            Description = "Проверяет, что конструктор записывает корректное значение BaseLength")]
        [TestCase(
            1000.5,
            TestName = "Constructor ValidBaseLength 1000_5 SetsBaseLength",
            Description = "Проверяет, что конструктор записывает корректное значение BaseLength")]
        public void ConstructorValidBaseLengthSetsBaseLength(double baseLength)
        {
            double baseWidth = 10.0;
            double height = 15.0;

            // Act
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                pyramid.BaseLength,
                Is.EqualTo(baseLength));
        }

        // Arrange
        [Category("BaseWidth")]
        [TestCase(
            15.5,
            TestName = "Constructor ValidBaseWidth 15_5 SetsBaseWidth",
            Description = "Проверяет, что конструктор записывает корректное значение BaseWidth")]
        [TestCase(
            500.0,
            TestName = "Constructor ValidBaseWidth 500 SetsBaseWidth",
            Description = "Проверяет, что конструктор записывает корректное значение BaseWidth")]
        [TestCase(
            1000.5,
            TestName = "Constructor ValidBaseWidth 1000_5 SetsBaseWidth",
            Description = "Проверяет, что конструктор записывает корректное значение BaseWidth")]
        public void ConstructorValidBaseWidthSetsBaseWidth(double baseWidth)
        {
            double baseLength = 10.0;
            double height = 15.0;

            // Act
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                pyramid.BaseWidth,
                Is.EqualTo(baseWidth));
        }

        // Arrange
        [Category("Height")]
        [TestCase(
            15.5,
            TestName = "Constructor ValidHeight 155 SetsHeight",
            Description = "Проверяет, что конструктор записывает корректное значение Height")]
        [TestCase(
            500.0,
            TestName = "Constructor ValidHeight 500 SetsHeight",
            Description = "Проверяет, что конструктор записывает корректное значение Height")]
        [TestCase(
            1000.5,
            TestName = "Constructor ValidHeight 1000_5 SetsHeight",
            Description = "Проверяет, что конструктор записывает корректное значение Height")]
        public void ConstructorValidHeightSetsHeight(double height)
        {
            double baseLength = 10.0;
            double baseWidth = 15.0;

            // Act
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                pyramid.Height,
                Is.EqualTo(height));
        }

        // Arrange
        [Category("BaseArea")]
        [TestCase(
            10.0,
            5.0,
            50.0,
            TestName = "BaseArea BaseLength 10 BaseWidth 5 Returns 50",
            Description = "Проверяет, что площадь основания пирамиды 10 x 5 равна 50")]
        [TestCase(
            2.5,
            4.0,
            10.0,
            TestName = "BaseArea BaseLength 2_5 BaseWidth 4 Returns 10",
            Description = "Проверяет, что площадь основания пирамиды 2_5 x 4 равна 10")]
        [TestCase(
            3.0,
            3.0,
            9.0,
            TestName = "BaseArea BaseLength 3 BaseWidth 3 Returns 9",
            Description = "Проверяет, что площадь квадратного основания 3 x 3 равна 9")]
        public void BaseAreaValidBaseLengthAndBaseWidthReturnsExpectedBaseArea(
            double baseLength,
            double baseWidth,
            double expectedBaseArea)
        {
            double height = 10.0;
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Act
            double actualBaseArea = pyramid.BaseArea;

            // Assert
            Assert.That(
                actualBaseArea,
                Is.EqualTo(expectedBaseArea).Within(_tolerance));
        }

        // Arrange
        [Category("FigureType")]
        [Test]
        [Description("Проверяет, что свойство FigureType возвращает строку Пирамида")]
        public void FigureTypeAlwaysReturnsPyramid()
        {
            Pyramid pyramid = new Pyramid(10.0, 5.0, 3.0);

            // Act
            string actualFigureType = pyramid.FigureType;

            // Assert
            Assert.That(
                actualFigureType,
                Is.EqualTo("Пирамида"));
        }

        // Arrange
        [Category("Volume")]
        [TestCase(
            10.0,
            5.0,
            3.0,
            50.0,
            TestName = "Volume BaseLength 10 BaseWidth 5 Height 3 Returns 50",
            Description = "Проверяет, что объём пирамиды 10 x 5 x 3 равен 50")]
        [TestCase(
            3.0,
            3.0,
            3.0,
            9.0,
            TestName = "Volume BaseLength 3 BaseWidth 3 Height 3 Returns 9",
            Description = "Проверяет, что объём пирамиды 3 x 3 x 3 равен 9")]
        [TestCase(
            10.0,
            10.0,
            10.0,
            333.3333333333333,
            TestName = "Volume BaseLength 10 BaseWidth 10 Height 10 Returns 333_333333",
            Description = "Проверяет, что объём пирамиды 10 x 10 x 10 равен 333_333333")]
        public void VolumeValidValuesReturnsExpectedVolume(
            double baseLength,
            double baseWidth,
            double height,
            double expectedVolume)
        {
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Act
            double actualVolume = pyramid.Volume;

            // Assert
            Assert.That(
                actualVolume,
                Is.EqualTo(expectedVolume).Within(_tolerance));
        }

        // Arrange
        [Category("GetDescription")]
        [Test]
        [Description("Проверяет, что GetDescription возвращает корректное описание пирамиды")]
        public void GetDescriptionValidValuesReturnsExpectedDescription()
        {
            Pyramid pyramid = new Pyramid(3.0, 3.0, 3.0);

            string expectedDescription =
                "Тип фигуры: Пирамида " +
                "| Основание: 3 х 3 " +
                "| Высота пирамиды: 3 " +
                "| Объем: 9";

            // Act
            string actualDescription = pyramid.GetDescription();

            // Assert
            Assert.That(
                actualDescription,
                Is.EqualTo(expectedDescription));
        }

        // Arrange
        [Category("Volume")]
        [Test]
        [Description("Проверяет, что слишком большой объём пирамиды вызывает OverflowException")]
        public void VolumeTooLargeValuesThrowsOverflowException()
        {
            Pyramid pyramid = new Pyramid(
                double.MaxValue,
                double.MaxValue,
                double.MaxValue);

            // Act
            TestDelegate act = () =>
            {
                double volume = pyramid.Volume;
            };

            // Assert
            Assert.That(
                act,
                Throws.TypeOf<OverflowException>());
        }
    }
}
