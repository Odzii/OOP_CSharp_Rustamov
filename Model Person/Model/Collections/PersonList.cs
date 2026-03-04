using System.Collections;
using System.Collections.Generic;

namespace Model.Collections
{
    /// <summary>
    /// Представляет список объектов <see cref="PersonBase"/> 
    /// и базовые операции добавления, удаления и поиска.
    /// </summary>
    public class PersonList : IEnumerable<PersonBase>
    {
        /// <summary>
        /// Коллекция элементов списка.
        /// </summary>
        private readonly List<PersonBase> _items = new();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PersonList"/>.
        /// </summary>
        public PersonList()
        {
        }

        /// <summary>
        /// Получает количество элементов в списке.
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Возвращает элемент списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Элемент типа <see cref="PersonBase"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="index"/> 
        /// находится вне диапазона списка.
        /// </exception>
        public PersonBase this[int index] => GetAt(index);

        /// <summary>
        /// Добавляет человека в список.
        /// </summary>
        /// <param name="person">Добавляемый объект <see cref="PersonBase"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="person"/> 
        /// равен <see langword="null"/>.
        /// </exception>
        public void Add(PersonBase person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person), 
                    "Невозможно добавить null в список.");
            }

            _items.Add(person);
        }

        /// <summary>
        /// Удаляет элемент из списка по индексу.
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="index"/> 
        /// находится вне диапазона списка.
        /// </exception>
        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            _items.RemoveAt(index);
        }

        /// <summary>
        /// Возвращает элемент списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Элемент типа <see cref="PersonBase"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="index"/> 
        /// находится вне диапазона списка.
        /// </exception>
        public PersonBase GetAt(int index)
        {
            ValidateIndex(index);

            return _items[index];
        }

        /// <summary>
        /// Возвращает индекс указанного человека в списке.
        /// </summary>
        /// <param name="person">Искомый объект <see cref="PersonBase"/>.</param>
        /// <returns>Индекс элемента или -1, если элемент не найден.</returns>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="person"/> 
        /// равен <see langword="null"/>.
        /// </exception>
        public int IndexOf(PersonBase person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(
                    nameof(person), 
                    "Нельзя передавать null.");
            }

            return _items.IndexOf(person);
        }

        /// <summary>
        /// Очищает список.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Возвращает перечислитель по элементам списка.
        /// </summary>
        /// <returns>Перечислитель <see cref="PersonBase"/>.</returns>
        public IEnumerator<PersonBase> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Возвращает непараметризованный перечислитель по элементам списка.
        /// </summary>
        /// <returns>Перечислитель.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <param name="index">Индекс для проверки.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если индекс вне диапазона <see cref="[0; Count)"/>.
        /// </exception>
        private void ValidateIndex(int index)
        {
            if ((uint)index >= (uint)_items.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    index,
                    "Индекс находится вне диапазона списка.");
            }
        }
    }
}
