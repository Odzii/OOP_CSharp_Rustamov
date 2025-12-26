using System;
using System.Collections.Generic;

namespace LabFirst
{
    /// <summary>
    /// Представляет список объектов <see cref="Person"/> и операции добавления,
    /// удаления и поиска.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Внутреннее хранилище элементов.
        /// </summary>
        private readonly List<Person> _items;

        /// <summary>
        /// Инициализирует пустой список людей.
        /// </summary>
        public PersonList()
        {
            _items = new List<Person>();
        }

        /// <summary>
        /// Получает количество элементов в списке.
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Добавляет человека в список.
        /// </summary>
        /// <param name="person">
        /// Добавляемый объект <see cref="Person"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// Если <paramref name="person"/> равен null.</exception>
        public void Add(Person person)
        {
            //TODO: {}
            if (person is null)
                throw new ArgumentNullException(
                    nameof(person),
                    "Невозможно добавить null в список."
                );

            _items.Add(person);
        }

        /// <summary>
        /// Удаляет элемент из списка по индексу.
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Если индекс вне диапазона списка.</exception>
        public void RemoveAt(int index)
        {
            //TODO: {}
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Индекс находится вне диапазона списка."
                );

            _items.RemoveAt(index);
        }

        /// <summary>
        /// Возвращает элемент списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Элемент типа <see cref="Person"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Если индекс вне диапазона списка.</exception>
        public Person GetAt(int index)
        {
            //TODO: {}
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Индекс находится вне диапазона списка."
                );

            return _items[index];
        }

        /// <summary>
        /// Возвращает индекс указанного человека в списке.
        /// </summary>
        /// <param name="person">Искомый объект <see cref="Person"/>.</param>
        /// <returns>Индекс элемента или -1, если элемент не найден.</returns>
        /// <exception cref="ArgumentNullException">
        /// Если <paramref name="person"/> равен null.</exception>
        public int IndexOf(Person person)
        {
            //TODO: {}
            if (person is null)
                throw new ArgumentNullException(
                    nameof(person),
                    "Нельзя передавать null."
                );

            return _items.IndexOf(person);
        }

        /// <summary>
        /// Очищает список.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }
    }
}
