using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    /// <summary>
    /// Представляет список объектов <see cref="PersonList"/>,
    /// представляющий операции добавления, удаления и поиска.
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
        /// Добавляет человека в список
        /// </summary>
        /// <param name="person"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(Person person)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person), "Невозможно добавить null в список.");
            
            _items.Add(person);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне диапазона списка.");

            _items.RemoveAt(index);
        }

        public Person GetAt(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне диапазона списка.");

            return _items[index];
        }

        public int IndexOf(Person person)
        { 
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return _items.IndexOf(person); 
        }

        public void Clear()
        { 
            _items.Clear(); 
        }
    }
}
