namespace Model.Interfaces
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
