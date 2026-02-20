namespace Model.Helpers
{
    //TODO: XML +
    /// <summary>
    /// Набор расширений для генератора случайных чисел <see cref="Random"/>.
    /// </summary>
    internal static class RandomExtensions
    {
        /// <summary>
        /// Возвращает случайный элемент из списка.
        /// </summary>
        /// <typeparam name="T">Тип элементов списка.</typeparam>
        /// <param name="random">
        /// Экземпляр <see cref="Random"/>.</param>
        /// <param name="items">
        /// Список элементов, из которого выбирается случайный элемент.
        /// </param>
        /// <param name="listName">
        /// Имя списка используется в тексте исключения для диагностики.
        /// </param>
        /// <returns>
        /// Случайный элемент из <paramref name="items"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="random"/> 
        /// равен <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если <paramref name="items"/> 
        /// равен <see langword="null"/> или не содержит элементов.
        /// </exception>
        public static T NextItem<T>(
            this Random random,
            IReadOnlyList<T> items, 
            string listName
        )
        {
            //TODO: {} +
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (items is null || items.Count == 0)
            {
                throw new InvalidOperationException(
                    $"Источник данных не содержит элементов: {listName}."
                );
            }

            return items[random.Next(items.Count)];
        }
    }
}
