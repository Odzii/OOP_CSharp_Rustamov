using LabFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFirst
{
    /// <summary>
    /// Интерфейс для создания экземпляра классов
    /// <see cref="Person"/>,
    /// <see cref="Adult"/>,
    /// <see cref="Child"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPersonFactory<out T> where T: Person
    {
        /// <summary>
        /// Метод для создания экземпляра класса любого из 
        /// реализованных типов.
        /// </summary>
        /// <returns></returns>
        T Create();
    }
}
