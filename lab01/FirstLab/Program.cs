using System;
using System.Collections.Generic;

using LabFirst;

namespace FirstLab
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Шаг 1 - создание двух списков с тремя объектами Person
            var (firstList, secondList) = CreateInitialPersonLists();

            var tests = new List<(string Title, Action Run)>
            {
                ("Вывод в консоль созданных списков",
                    () => ShowLists(firstList, secondList)),

                ("Добавление нового объекта типа Person",
                    () => DemoAddPerson(firstList)),

                ("Проверка ссылочного типа данных",
                    () => DemoReferenceCopy(firstList, secondList)),

                ("Удаление объекта Person",
                    () => DemoRemovePerson(firstList, secondList)),

                ("Полная очистка списка",
                    () => DemoClearList(secondList, nameof(secondList))),

                ("Создание случайного экземпляра класса",
                    () => { _ = Person.GetRandomPerson(); }),

                ("Чтение с клавиатуры для создания объекта Person",
                    () => { _ = Person.ReadFromConsole(); })
            };

            foreach (var test in tests)
            {
                WriteTitle(test.Title);
                test.Run();
                WaitForKeyPress();
            }
        }

        /// <summary>
        /// Вывод сообщения о нажатии клавиши для продолжения работы.
        /// </summary>
        private static void WaitForKeyPress()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            Console.WriteLine();
        }

        private static void WriteTitle(string text)
        {
            void PrintSeparator()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('-', text.Length));
                Console.ResetColor();
            }

            PrintSeparator();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
            PrintSeparator();
        }

        private static void PrintPersonList(PersonList personList, string listName)
        {
            int count = personList.Count;

            Console.WriteLine("Содержимое списка {0}:", listName);

            for (int i = 0; i < count; i++)
            {
                Person person = personList.GetAt(i);

                person.Print();
            }

            Console.WriteLine();
        }

        private static Person[] CreateSamplePersons()
        {
            return new[]
            {
                new Person("Ruslan", "Rustamov", 16, Gender.Male),
                new Person("Александр", "Македонский", 20, Gender.Male),
                new Person("James", "Bond", 110, Gender.Female),
                new Person("Борис", "Бритва", 16, Gender.Male),
                new Person("Жаргалма", "Цыдыпова", 20, Gender.Male),
                new Person("Дмитрий", "Цырен-Галсанов", 110, Gender.Female),
            };
        }

        private static (PersonList, PersonList) CreateInitialPersonLists()
        {
            var firstList = new PersonList();
            var secondList = new PersonList();

            Person[] arrayOfPersons = CreateSamplePersons();

            for (int i = 0; i < 3; i++)
            {
                firstList.Add(arrayOfPersons[i]);
                secondList.Add(arrayOfPersons[i + 3]);
            }
            WriteTitle($"Созданы списки: {nameof(firstList)} и" +
                $" {nameof(secondList)}.");
            WaitForKeyPress();
            return (firstList, secondList);
        }

        private static void ShowLists(
            PersonList firstList,
            PersonList secondList
        )
        {
            PrintPersonList(firstList, nameof(firstList));
            PrintPersonList(secondList, nameof(secondList));

        }

        private static void DemoAddPerson(PersonList firstList)
        {
            Person firstListPersonFour =
                new Person("Oleg", "Rasputin", 44, Gender.Female);
            firstList.Add(firstListPersonFour);
            firstListPersonFour.Print();
            PrintPersonList(firstList, nameof(firstList));
        }

        private static void DemoReferenceCopy(
            PersonList firstList,
            PersonList secondList
        )
        {
            Person secondPersonFromFirstList = firstList.GetAt(1);
            secondList.Add(secondPersonFromFirstList);
            Person personFromFirst = firstList.GetAt(1);
            Person personFromSecond = secondList.GetAt(secondList.Count - 1);
            bool sameObject = ReferenceEquals(personFromFirst,
                personFromSecond);
            Console.WriteLine("Скопированный из первого списка объект " +
                "и вставленный во второй список объект " +
                "являются одним и тем же объектом?: {0}",
                sameObject ? "Да" : "Нет"
            );
        }

        private static void DemoRemovePerson(
            PersonList firstList,
            PersonList secondList
        )
        {
            firstList.RemoveAt(1);
            PrintPersonList(firstList, "firstList");
            PrintPersonList(secondList, "secondList");
        }

        private static void DemoClearList(PersonList personList, string name)
        {
            personList.Clear();
            Console.WriteLine("Количество элементов в списке {0}: {1}",
                name, personList.Count);
        }

    }
}
