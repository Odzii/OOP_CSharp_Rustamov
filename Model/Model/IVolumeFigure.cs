using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Определяет контракт для фигур, обладающих объемом,
    /// таких как параллелепипед, пирамида и сфера.
    /// </summary>
    /// <remarks> Типы реализации должны указывать тип фигуры 
    /// и предоставлять логику для расчёта её объёма.</remarks>
    public interface IVolumeFigure
    {
        /// <summary>
        /// Получить тип фигуры представляемой этим экземпляром.
        /// </summary>
        /// <remarks> Это свойство предоставляет классификацию фигуры.</remarks>
        public string FigureType { get; }

        /// <summary>
        /// Получить объём объекта, измеряемый в кубических единицах.
        /// </summary>
        public double Volume { get; }

        /// <summary>
        /// Получить текстовое описание фигуры, включая её тип и объём.
        /// </summary>
        /// <returns></returns>
        public string GetDescription();
    }
}
