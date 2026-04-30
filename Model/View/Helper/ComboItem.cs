namespace View.Helper
{
    /// <summary>
    /// Представляет элемент выпадающего списка с отображаемым названием
    /// и связанным с ним значением.
    /// </summary>
    /// <typeparam name="T">
    /// Тип значения, связанного с элементом выпадающего списка.
    /// </typeparam>
    public class ComboItem<T>
    {
        /// <summary>
        /// Возвращает или задаёт значение элемента.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Возвращает или задаёт отображаемое название элемента.
        /// </summary>
        public string Name { get; set; }
    }
}