namespace ModelPyramidTests
{
    public class PyramidTests
    {
        /// <summary>
        /// Допустимая погрешность для сравнения числовых значений типа double.
        /// </summary>
        private const double _tolerance = 1e-6;

        [Category("BaseLength")]
        [TestCase(
            double.NaN,
            TestName = "Invalid Base Length Not A Number",
            Description =
                "Проверяет, что нельзя создать пирамиду с NaN в "
                + "BaseLength")]
        [TestCase(
            double.PositiveInfinity,
            TestName = "Invalid Base Length Positive Infinity",
            Description =
                "Проверяет, что нельзя создать пирамиду с положительной "
                + "бесконечностью в BaseLength")]
        [TestCase(
            double.NegativeInfinity,
            TestName = "Invalid Base Length Negative Infinity",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательной "
                + "бесконечностью в BaseLength")]
        [TestCase(
            0.0,
            TestName = "Invalid Base Length Zero",
            Description =
                "Проверяет, что нельзя создать пирамиду с нулевым "
                + "BaseLength")]
        [TestCase(
            -1.0,
            TestName = "Invalid Base Length Minus One",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "BaseLength")]
        [TestCase(
            -10.5,
            TestName = "Invalid Base Length Minus 10_5",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "BaseLength")]
        [TestCase(
            -9999.5,
            TestName = "Invalid Base Length Minus 9999_5",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "BaseLength")]
        public void ConstructorInvalidBaseLengthThrowsArgumentOutOfRangeException(
            double baseLength)
        {
            // Arrange
            double baseWidth = 10.0;
            double height = 15.0;

            // Act
            TestDelegate act = () => new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                act,
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Category("BaseWidth")]
        [TestCase(
            double.NaN,
            TestName = "Invalid Base Width Not A Number",
            Description =
                "Проверяет, что нельзя создать пирамиду с NaN в "
                + "BaseWidth")]
        [TestCase(
            double.PositiveInfinity,
            TestName = "Invalid Base Width Positive Infinity",
            Description =
                "Проверяет, что нельзя создать пирамиду с положительной "
                + "бесконечностью в BaseWidth")]
        [TestCase(
            double.NegativeInfinity,
            TestName = "Invalid Base Width Negative Infinity",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательной "
                + "бесконечностью в BaseWidth")]
        [TestCase(
            0.0,
            TestName = "Invalid Base Width Zero",
            Description =
                "Проверяет, что нельзя создать пирамиду с нулевым "
                + "BaseWidth")]
        [TestCase(
            -1.0,
            TestName = "Invalid Base Width Minus One",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "BaseWidth")]
        [TestCase(
            -10.5,
            TestName = "Invalid Base Width Minus 10_5",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "BaseWidth")]
        [TestCase(
            -9999.5,
            TestName = "Invalid Base Width Minus 9999_5",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "BaseWidth")]
        public void ConstructorInvalidBaseWidthThrowsArgumentOutOfRangeException(
            double baseWidth)
        {
            // Arrange
            double baseLength = 10.0;
            double height = 15.0;

            // Act
            TestDelegate act = () => new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                act,
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Category("Height")]
        [TestCase(
            double.NaN,
            TestName = "Invalid Height Not A Number",
            Description =
                "Проверяет, что нельзя создать пирамиду с NaN в Height")]
        [TestCase(
            double.PositiveInfinity,
            TestName = "Invalid Height Positive Infinity",
            Description =
                "Проверяет, что нельзя создать пирамиду с положительной "
                + "бесконечностью в Height")]
        [TestCase(
            double.NegativeInfinity,
            TestName = "Invalid Height Negative Infinity",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательной "
                + "бесконечностью в Height")]
        [TestCase(
            0.0,
            TestName = "Invalid Height Zero",
            Description =
                "Проверяет, что нельзя создать пирамиду с нулевым Height")]
        [TestCase(
            -1.0,
            TestName = "Invalid Height Minus One",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "Height")]
        [TestCase(
            -10.5,
            TestName = "Invalid Height Minus 10_5",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "Height")]
        [TestCase(
            -9999.5,
            TestName = "Invalid Height Minus 9999_5",
            Description =
                "Проверяет, что нельзя создать пирамиду с отрицательным "
                + "Height")]
        public void ConstructorInvalidHeightThrowsArgumentOutOfRangeException(
            double height)
        {
            // Arrange
            double baseLength = 10.0;
            double baseWidth = 15.0;

            // Act
            TestDelegate act = () => new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                act,
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Category("BaseLength")]
        [TestCase(
            15.5,
            TestName = "Valid Base Length 15_5",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение BaseLength")]
        [TestCase(
            500.0,
            TestName = "Valid Base Length 500",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение BaseLength")]
        [TestCase(
            1000.5,
            TestName = "Valid Base Length 1000_5",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение BaseLength")]
        public void ConstructorValidBaseLengthSetsBaseLength(double baseLength)
        {
            // Arrange
            double baseWidth = 10.0;
            double height = 15.0;

            // Act
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                pyramid.BaseLength,
                Is.EqualTo(baseLength));
        }

        [Category("BaseWidth")]
        [TestCase(
            15.5,
            TestName = "Valid Base Width 15_5",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение BaseWidth")]
        [TestCase(
            500.0,
            TestName = "Valid Base Width 500",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение BaseWidth")]
        [TestCase(
            1000.5,
            TestName = "Valid Base Width 1000_5",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение BaseWidth")]
        public void ConstructorValidBaseWidthSetsBaseWidth(double baseWidth)
        {
            // Arrange
            double baseLength = 10.0;
            double height = 15.0;

            // Act
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                pyramid.BaseWidth,
                Is.EqualTo(baseWidth));
        }

        [Category("Height")]
        [TestCase(
            15.5,
            TestName = "Valid Height 15_5",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение Height")]
        [TestCase(
            500.0,
            TestName = "Valid Height 500",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение Height")]
        [TestCase(
            1000.5,
            TestName = "Valid Height 1000_5",
            Description =
                "Проверяет, что конструктор записывает корректное "
                + "значение Height")]
        public void ConstructorValidHeightSetsHeight(double height)
        {
            // Arrange
            double baseLength = 10.0;
            double baseWidth = 15.0;

            // Act
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Assert
            Assert.That(
                pyramid.Height,
                Is.EqualTo(height));
        }

        [Category("BaseArea")]
        [TestCase(
            10.0,
            5.0,
            50.0,
            TestName = "Base Area 10 By 5 Returns 50",
            Description =
                "Проверяет, что площадь основания пирамиды 10 x 5 равна "
                + "50")]
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
        public void BaseAreaValidBaseLengthAndBaseWidthReturnsExpectedBaseArea(
            double baseLength,
            double baseWidth,
            double expectedBaseArea)
        {
            // Arrange
            double height = 10.0;
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Act
            double actualBaseArea = pyramid.BaseArea;

            // Assert
            Assert.That(
                actualBaseArea,
                Is.EqualTo(expectedBaseArea).Within(_tolerance));
        }

        [Category("FigureType")]
        [Test]
        [Description(
            "Проверяет, что свойство FigureType возвращает строку "
            + "Пирамида")]
        public void FigureTypeAlwaysReturnsPyramid()
        {
            // Arrange
            Pyramid pyramid = new Pyramid(10.0, 5.0, 3.0);

            // Act
            string actualFigureType = pyramid.FigureType;

            // Assert
            Assert.That(
                actualFigureType,
                Is.EqualTo("Пирамида"));
        }

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
            Description = "Проверяет, что объём пирамиды 3 x 3 x 3 равен 9")]
        [TestCase(
            10.0,
            10.0,
            10.0,
            333.3333333333333,
            TestName = "Volume 10 By 10 By 10 Returns 333_333333",
            Description =
                "Проверяет, что объём пирамиды 10 x 10 x 10 равен "
                + "333_333333")]
        public void VolumeValidValuesReturnsExpectedVolume(
            double baseLength,
            double baseWidth,
            double height,
            double expectedVolume)
        {
            // Arrange
            Pyramid pyramid = new Pyramid(baseLength, baseWidth, height);

            // Act
            double actualVolume = pyramid.Volume;

            // Assert
            Assert.That(
                actualVolume,
                Is.EqualTo(expectedVolume).Within(_tolerance));
        }

        [Category("GetDescription")]
        [Test]
        [Description(
            "Проверяет, что GetDescription возвращает корректное "
            + "описание пирамиды")]
        public void GetDescriptionValidValuesReturnsExpectedDescription()
        {
            // Arrange
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

        [Category("Volume")]
        [Test]
        [Description(
            "Проверяет, что слишком большой объём пирамиды вызывает "
            + "OverflowException")]
        public void VolumeTooLargeValuesThrowsOverflowException()
        {
            // Arrange
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
