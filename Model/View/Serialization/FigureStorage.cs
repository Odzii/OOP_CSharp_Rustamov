using Model;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        /// Хранит соответствие между типом фигуры и функциями преобразования
        /// модели фигуры в данные для сохранения и обратно.
        /// </summary>
        /// <remarks>
        /// Ключом словаря является тип фигуры. Значение содержит функцию преобразования
        /// объекта <see cref="VolumeFigureBase"/> в объект <see cref="FigureData"/>
        /// и функцию восстановления объекта <see cref="VolumeFigureBase"/>
        /// из объекта <see cref="FigureData"/>.
        /// </remarks>
        private static readonly Dictionary
            <FigureType,
                (Func<VolumeFigureBase, FigureData> toData,
                Func<FigureData, VolumeFigureBase> toModel)> _mappers = new()
                    {
                        [FigureType.Sphere] = (
                            f => new FigureData
                            {
                                FigureKind = FigureType.Sphere,
                                Radius = ((Sphere)f).Radius
                            },
                            d => new Sphere(
                                d.Radius 
                                ?? throw new InvalidOperationException(
                                    "Radius не задан"))
                        ),

                        [FigureType.Pyramid] = (
                            f => new FigureData
                            {
                                FigureKind = FigureType.Pyramid,
                                BaseLength = ((Pyramid)f).BaseLength,
                                BaseWidth = ((Pyramid)f).BaseWidth,
                                Height = ((Pyramid)f).Height
                            },
                            d => new Pyramid(
                                d.BaseLength 
                                ?? throw new InvalidOperationException(
                                    "BaseLength не задан"),
                                d.BaseWidth 
                                ?? throw new InvalidOperationException(
                                    "BaseWidth не задан"),
                                d.Height 
                                ?? throw new InvalidOperationException(
                                    "Height не задан"))
                        ),

                        [FigureType.Parallelepiped] = (
                            f => new FigureData
                            {
                                FigureKind = FigureType.Parallelepiped,
                                Length = ((Parallelepiped)f).Length,
                                Width = ((Parallelepiped)f).Width,
                                Height = ((Parallelepiped)f).Height
                            },
                            d => new Parallelepiped(
                                d.Length ?? throw new InvalidOperationException(
                                    "Length не задан"),
                                d.Width ?? throw new InvalidOperationException(
                                    "Width не задан"),
                                d.Height ?? throw new InvalidOperationException(
                                    "Height не задан"))
                        )
                    };


        /// <summary>
        /// Сохраняет коллекцию фигур в файл.
        /// </summary>
        /// <param name="filePath">Путь к файлу сохранения.</param>
        /// <param name="figures">Коллекция фигур для сохранения.</param>
        public static void Save(
            string filePath, 
            IEnumerable<IVolumeFigure> figures)
        {
            FiguresFileData fileData = new FiguresFileData();

            foreach (VolumeFigureBase figure in figures)
            {
                var type = figure switch
                {
                    Sphere => FigureType.Sphere,
                    Pyramid => FigureType.Pyramid,
                    Parallelepiped => FigureType.Parallelepiped,
                    _ => throw new NotSupportedException()
                };

                fileData.Figures.Add(_mappers[type].toData(figure));
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

                foreach (var data in fileData.Figures)
                {
                    figures.Add(_mappers[data.FigureKind].toModel(data));
                }
                return figures;
            } 
        }
    }
}