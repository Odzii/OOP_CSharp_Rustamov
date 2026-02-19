namespace Model.Helpers
{
    internal static class RandomExtensions
    {
        public static T NextItem<T>(this Random random, IReadOnlyList<T> items, string listName)
        {
            if (random is null)
                throw new ArgumentNullException(nameof(random));

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
