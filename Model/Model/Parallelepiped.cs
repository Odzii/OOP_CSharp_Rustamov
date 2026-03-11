using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Представляет объёмную геометрическую фигуру — параллелепипед,
    /// задаваемый длиной, шириной и высотой.
    /// </summary>
    /// <remarks>
    /// Параллелепипед — это пространственная фигура, 
    /// у которой противоположные грани попарно равны и параллельны.
    /// В данной реализации рассматривается прямоугольный параллелепипед, 
    /// у которого все грани являются прямоугольниками.
    /// Все размеры фигуры должны быть положительными конечными числами.
    /// Объём вычисляется как произведение длины, ширины и высоты.
    /// </remarks>
    public class Parallelepiped : VolumeFigureBase
    {
        /// <summary>
        /// Длина параллелепипеда.
        /// </summary>
        private double _length;

        /// <summary>
        /// Ширина параллелепипеда.
        /// </summary>
        private double _width;

        /// <summary>
        /// Высота параллелепипеда.
        /// </summary>
        private double _height;

        /// <summary>
        /// Получает или задаёт длину параллелепипеда.
        /// Значение должно быть положительным конечным числом.
        /// </summary>
        public double Length
        {
            get => _length;
            set
            {
                ValidatePositive(value, nameof(Length));
                _length = value;
            }
        }

        /// <summary>
        /// Получает или задаёт ширину параллелепипеда.
        /// Значение должно быть положительным конечным числом.
        /// </summary>
        public double Width
        {
            get => _width;
            set
            {
                ValidatePositive(value, nameof(Width));
                _width = value;
            }
        }

        /// <summary>
        /// Получает или задаёт высоту параллелепипеда.
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
        /// Получает название типа фигуры.
        /// </summary>
        public override string FigureType => "Параллелепипед";

        /// <summary>
        /// Получает объём параллелепипеда.
        /// </summary>
        public override double Volume => Length * Width * Height;

        /// <summary>
        /// Возвращает строковое описание параллелепипеда 
        /// с указанием его размеров.
        /// </summary>
        /// <returns>Строка с типом фигуры, длиной, шириной и высотой.</returns>
        public override string GetDescription()
        {
            return $"Тип фигуры: {FigureType} " +
                $"| Длина: {Length} " +
                $"| Ширина: {Width} " +
                $"| Высота: {Height} " +
                $"| Объем: {Volume:F2}";
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса 
        /// <see cref="Parallelepiped"/> с указанной длиной, шириной и высотой.
        /// </summary>
        /// <param name="length">Длина пирамиды.</param>
        /// <param name="width">Ширина пирамиды.</param>
        /// <param name="height">Высота пирамиды.</param>
        public Parallelepiped(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
    }
}