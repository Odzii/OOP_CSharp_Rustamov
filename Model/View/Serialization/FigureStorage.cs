using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace View.Serialization
{
    internal static class FigureStorage
    {
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

        private static FigureData ToFigureData(VolumeFigureBase figure)
        {
            switch (figure)
            {
                case Sphere sphere:
                    return new FigureData
                    {
                        FigureKind = "Сфера",
                        Radius = sphere.Radius
                    };

                case Pyramid pyramid:
                    return new FigureData
                    {
                        FigureKind = "Пирамида",
                        BaseLength = pyramid.BaseLength,
                        BaseWidth = pyramid.BaseWidth,
                        Height = pyramid.Height
                    };

                case Parallelepiped parallelepiped:
                    return new FigureData
                    {
                        FigureKind = "Параллелепипед",
                        Length = parallelepiped.Length,
                        Width = parallelepiped.Width,
                        Height = parallelepiped.Height
                    };

                default:
                    throw new NotSupportedException("Неизвестный тип фигуры.");
            }
        }

        private static VolumeFigureBase ToFigureModel(FigureData figureData)
        {
            switch (figureData.FigureKind)
            {
                case "Сфера":
                    return new Sphere(
                        figureData.Radius 
                        ?? throw new InvalidOperationException(
                            "Не задан Radius."));

                case "Пирамида":
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

                case "Параллелепипед":
                    return new Parallelepiped(
                        figureData.Length 
                        ?? throw new InvalidOperationException(
                            "Не задан Length."),
                        figureData.Width ?? throw new InvalidOperationException(
                            "Не задан Width."),
                        figureData.Height 
                        ?? throw new InvalidOperationException(
                            "Не задан Height."));

                default:
                    throw new NotSupportedException(
                        "Неизвестный тип фигуры в файле.");
            }
        }
    }
}