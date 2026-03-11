using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Представляет пирамиду 
    /// и содержит свойства для вычисления площади основания,
    /// объёма и получения текстового описания фигуры.
    /// </summary>
    public class Pyramid : VolumeFigureBase
    {
        /// <summary>
        /// Длина основания пирамиды.
        /// </summary>
        private double _baseLength;

        /// <summary>
        /// Ширина основания пирамиды.
        /// </summary>
        private double _baseWidth;

        /// <summary>
        /// Высота пирамиды.
        /// </summary>
        private double _height;

        /// <summary>
        /// Получает или задаёт длину основания пирамиды.
        /// Значение должно быть положительным конечным числом.
        /// </summary>
        public double BaseLength
        {
            get => _baseLength;
            set
            {
                ValidatePositive(value, nameof(BaseLength));
                _baseLength = value;
            }
        }

        /// <summary>
        /// Получает или задаёт ширину основания пирамиды.
        /// Значение должно быть положительным конечным числом.
        /// </summary>
        public double BaseWidth
        {
            get => _baseWidth;
            set
            {
                ValidatePositive(value, nameof(BaseWidth));
                _baseWidth = value;
            }
        }

        /// <summary>
        /// Получает или задаёт высоту пирамиды.
        /// Значение должно быть положительным конечным числом.
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                ValidatePositive(value, nameof(Height));
                _height = value;
            }
        }

        /// <summary>
        /// Получает площадь основания пирамиды.
        /// </summary>
        public double BaseArea
        {
            get => BaseLength * BaseWidth;
        }

        /// <summary>
        /// Получает название типа фигуры.
        /// </summary>
        public override string FigureType => "Пирамида";

        /// <summary>
        /// Получает объём пирамиды.
        /// </summary>
        public override double Volume => 1.0 / 3.0 * BaseArea * Height;

        /// <summary>
        /// Возвращает строковое описание пирамиды
        /// с указанием её основных параметров.
        /// </summary>
        /// <returns>
        /// Строка с типом фигуры, размерами основания и высотой.
        /// </returns>
        public override string GetDescription()
        {
            return $"Тип фигуры: {FigureType} " +
                $"| Основание: {BaseWidth} " +
                $"х {BaseLength} " +
                $"| Высота пирамиды: {Height} " +
                $"| Объем: {Volume:F2}";
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Pyramid"/> 
        /// с указанными размерами.
        /// </summary>
        /// <param name="baseLength">Длина основания пирамиды.</param>
        /// <param name="baseWidth">Ширина основания пирамиды.</param>
        /// <param name="height">Высота пирамиды.</param>
        public Pyramid(double baseLength, double baseWidth, double height)
        {
            BaseLength = baseLength;
            BaseWidth = baseWidth;
            Height = height;
        }
    }
}