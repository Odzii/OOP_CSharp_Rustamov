using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Представляет трёхмерную сферу, определяемую своим радиусом. 
    /// Предоставляет свойства для доступа к радиусу сферы
    /// и вычисления её объёма.
    /// </summary>
    /// <remarks> Объём сферы рассчитывается по формуле (4/3) × π × radius³. 
    /// Радиус должен быть положительным значением,
    /// в противном случае при установке свойства будет выброшено исключение.
    /// </remarks>
    public class Sphere : VolumeFigureBase
    {
        /// <summary>
        /// Радиус сферы, определяющий её размер. 
        /// </summary>
        private double _radius;

        /// <summary>
        /// Инициализирует новый экземпляр класса Sphere с указанным радиусом.
        /// </summary>
        /// <remarks> Если указанный радиус меньше или равен нулю, 
        /// будет выброшено исключение.</remarks>
        /// <param name="radius">Радиус сферы. 
        /// Радиус должен быть положительным значением.</param>
        public Sphere(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Получает или задаёт радиус сферы. Радиус должен быть положительным значением.
        /// </summary>
        /// <remarks>Установка радиуса в неположительное значение вызывает исключение. 
        /// Радиус определяет размер сферы и используется в таких расчетах, 
        /// как площадь и объем.</remarks>
        public double Radius
        {
            get => _radius;
            set
            {
                ValidatePositive(value, nameof(Radius));
                _radius = value;
            }
        }

        /// <summary>
        /// Получает тип фигуры, представляемой этим экземпляром. 
        /// В данном случае возвращает строку "Сфера".
        /// </summary>
        public override string FigureType => "Сфера";

        /// <summary>
        /// Получает объем сферы, рассчитанный по стандартной формуле объема сферы.
        /// </summary>
        /// <remarks>
        /// Объем сферы рассчитывается по формуле (4/3) × π × <see cref="Radius"/>³, 
        /// где <see cref="Radius"/> - это текущий радиус сферы.</remarks>
        public override double Volume => 
            4.0 / 3.0 
            * Math.PI 
            * Math.Pow(Radius, 3);

        /// <summary>
        /// Возвращает строку, описывающую фигуру, включая её тип, радиус и объём.
        /// </summary>
        /// <returns>
        /// Форматированная строка, 
        /// содержащая тип фигуры, радиус и объём,
        /// при этом объём отображается с точностью до двух десятичных знаков.
        /// </returns>
        public override string GetDescription()
        {
            return $"Тип фигуры: {FigureType} " +
                $"| Радиус: {Radius} " +
                $"| Объём: {Volume:F2}";
        }
    }
}
