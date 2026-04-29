using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Helper
{
    public static class FigureTypeExtensions
    {
        public static string ToDisplay(this FigureType type) => type switch
        {
            FigureType.Sphere => "Сфера",
            FigureType.Pyramid => "Пирамида",
            FigureType.Parallelepiped => "Параллелепипед",
            _ => type.ToString()
        };
    }
}
