using System.Collections.Generic;

namespace View.Serialization
{
    /// <summary>
    /// Представляет сериализуемый контейнер списка фигур.
    /// </summary>
    /// <remarks>
    /// Используется как корневой объект при сохранении и загрузке
    /// коллекции фигур из файла.
    /// </remarks>
    public class FiguresFileData
    {
        /// <summary>
        /// Получает или задаёт список сериализуемых фигур.
        /// </summary>
        /// <value>Коллекция объектов <see cref="FigureData"/>.</value>
        public List<FigureData> Figures { get; set; } = new List<FigureData>();
    }
}