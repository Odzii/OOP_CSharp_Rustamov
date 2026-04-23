using Model;
using System.Xml.Serialization;

namespace View.Serialization
{
    /// <summary>
    /// Предоставляет методы сохранения и загрузки фигур в файл.
    /// </summary>
    /// <remarks>
    /// Класс выполняет преобразование объектов бизнес-модели
    /// в сериализуемые DTO-объекты и обратно.
    /// </remarks>
    internal static class FigureStorage
    {

        /// <summary>
        /// Сохраняет коллекцию фигур в файл.
        /// </summary>
        /// <param name="filePath">Путь к файлу сохранения.</param>
        /// <param name="figures">Коллекция фигур для сохранения.</param>
        public static void Save(
            string filePath, 
            IEnumerable<VolumeFigureBase> figures)
        {
            FiguresFileData fileData = new FiguresFileData();

            foreach (VolumeFigureBase figure in figures)
            {
                fileData.Figures.Add(ToFigureData(figure));
            }

            XmlSerializer serializer 
                = new XmlSerializer(typeof(FiguresFileData));

            using (FileStream stream = File.Create(filePath))
            {
                serializer.Serialize(stream, fileData);
            }
        }

        /// <summary>
        /// Загружает коллекцию фигур из файла.
        /// </summary>
        /// <param name="filePath">Путь к файлу загрузки.</param>
        /// <returns>Список загруженных фигур.</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если файл не содержит корректных данных.
        /// </exception>
        public static List<VolumeFigureBase> Load(string filePath)
        {
            XmlSerializer serializer 
                = new XmlSerializer(typeof(FiguresFileData));

            using (FileStream stream = File.OpenRead(filePath))
            {
                FiguresFileData? fileData 
                    = serializer.Deserialize(stream) as FiguresFileData;

                if (fileData == null)
                {
                    throw new InvalidOperationException(
                        "Файл не содержит корректных данных.");
                }

                List<VolumeFigureBase> figures = new List<VolumeFigureBase>();

                foreach (FigureData figureData in fileData.Figures)
                {
                    figures.Add(ToFigureModel(figureData));
                }

                return figures;
            }
        }

        /// <summary>
        /// Преобразует объект бизнес-модели в сериализуемую модель файла.
        /// </summary>
        /// <param name="figure">Объект фигуры бизнес-модели.</param>
        /// <returns>Экземпляр <see cref="FigureData"/>.</returns>
        /// <exception cref="NotSupportedException">
        /// Выбрасывается, если тип фигуры не поддерживается.
        /// </exception>
        private static FigureData ToFigureData(VolumeFigureBase figure)
        {
            switch (figure)
            {
                //TODO: duplication
                case Sphere sphere:
                {
                    return new FigureData
                    {
                        FigureKind = "Сфера",
                        Radius = sphere.Radius
                    };
                }

                case Pyramid pyramid:
                {
                    return new FigureData
                    {
                        FigureKind = "Пирамида",
                        BaseLength = pyramid.BaseLength,
                        BaseWidth = pyramid.BaseWidth,
                        Height = pyramid.Height
                    };
                }

                case Parallelepiped parallelepiped:
                {
                    return new FigureData
                    {
                        FigureKind = "Параллелепипед",
                        Length = parallelepiped.Length,
                        Width = parallelepiped.Width,
                        Height = parallelepiped.Height
                    };
                }

                default:
                {
                    throw new NotSupportedException("Неизвестный тип фигуры.");
                }
            }
        }

        /// <summary>
        /// Преобразует сериализуемую модель файла в объект бизнес-модели.
        /// </summary>
        /// <param name="figureData">Сериализуемые данные фигуры.</param>
        /// <returns>Экземпляр фигуры, наследуемой 
        /// от <see cref="VolumeFigureBase"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, 
        /// если в сериализованных данных отсутствуют обязательные параметры.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// Выбрасывается, если тип фигуры не поддерживается.
        /// </exception>
        private static VolumeFigureBase ToFigureModel(FigureData figureData)
        {
            switch (figureData.FigureKind)
            {
                //TODO: duplication
                case "Сфера":
                {
                    return new Sphere(
                        figureData.Radius
                        ?? throw new InvalidOperationException(
                            "Не задан Radius."));
                }

                case "Пирамида":
                {
                    return new Pyramid(
                        figureData.BaseLength
                        ?? throw new InvalidOperationException(
                            "Не задан BaseLength."),
                        figureData.BaseWidth
                        ?? throw new InvalidOperationException(
                            "Не задан BaseWidth."),
                        figureData.Height
                        ?? throw new InvalidOperationException(
                            "Не задан Height."));
                }

                case "Параллелепипед":
                {
                    return new Parallelepiped(
                        figureData.Length
                        ?? throw new InvalidOperationException(
                            "Не задан Length."),
                        figureData.Width
                        ?? throw new InvalidOperationException(
                            "Не задан Width."),
                        figureData.Height
                        ?? throw new InvalidOperationException(
                            "Не задан Height."));
                }

                default:
                {
                    throw new NotSupportedException(
                        "Неизвестный тип фигуры в файле.");
                }
            }
        }
    }
}