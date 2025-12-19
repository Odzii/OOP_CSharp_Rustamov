using Lab01;
using static System.Net.Mime.MediaTypeNames;
namespace FirstLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Шаг 1 - создание двух списков с тремя объектами Person
            var (firstList, secondList) = TestCreateTwoListOfPerson();

            var testDictionary = new Dictionary<string, Action>
            {
                ["Вывод в консоль созданных списков"] = () =>
                    TestPrintOfTwoList(firstList, secondList),
                ["Добавление нового объекта типа Person"] = () =>
                    TestAddPerson(firstList),
                ["Проверка ссылочного типа данных"] = () =>
                    TestCopyReferenceEquals(firstList, secondList),
                ["Удаление объекта Person"] = () =>
                    TestRemovePerson(firstList, secondList),
                ["Полная очистка списка"] = () =>
                    TestClearList(secondList, nameof(secondList)),
                ["Создание случайного экземпляра класса"] = () =>
                    Person.GetRandomPerson(),
                ["Чтение с клавиатуры для создания объекта Person"] = () =>
                    Person.ReadFromConsole()
            };

            foreach (var item in testDictionary)
            {
                ColorTitle(item.Key);
                item.Value();
                ReadKeyForContinue();
            }
        }

        /// <summary>
        /// Вывод сообщения о нажатии клавиши для продолжения работы.
        /// </summary>
        static void ReadKeyForContinue()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            Console.WriteLine();
        }

        static void ColorTitle(string text)
        {
            Action forConsoleWriteLine = new Action(() => {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < text.Length; i++)
                    Console.Write("-");
                Console.WriteLine();
                Console.ResetColor();
            }
            );
            forConsoleWriteLine();
            Console.WriteLine(text);
            forConsoleWriteLine();
        }

        /// <summary>
        ///Вывод в консоль, значения списка с экземплярами класса Person.
        /// </summary>
        /// <param name="personList"></param>
        /// <param name="listName"></param>
        private static void PrintList(PersonList personList, string listName)
        {
            int count = personList.Count;

            Console.WriteLine("Содержимое списка {0}:", listName);

            for (int i = 0; i < count; i++)
            {
                Person person = personList.GetAt(i);

                Console.WriteLine(
                    "  [{0}] Имя: {1} | Фамилия: {2} | Возраст: {3} | Пол: {4}",
                    i,
                    person.Name,
                    person.Surname,
                    person.Age,
                    person.Gender);
            }

            Console.WriteLine();
        }


        private static Person[] CreateSixPersons()
        {
            var firstListPersonOne = new Person("Ruslan", "Rustamov", 16,
                Gender.Male);
            var firstListPersonTwo = new Person("Александр", "Македонский", 20,
                Gender.Male);
            var firstListPersonThree = new Person("James", "Bond",
                110, Gender.Female);
            var secondListPersonOne = new Person("Борис", "Бритва", 16,
                Gender.Male);
            var secondListPersonTwo = new Person("Жаргалма", "Цыдыпова", 20,
                Gender.Male);
            var secondListPersonThree = new Person("Дмитрий", "Цырен-Галсанов",
                110, Gender.Female);

            Person[] arrayPerson = { firstListPersonOne, firstListPersonTwo,
                firstListPersonThree, secondListPersonOne,
                secondListPersonTwo, secondListPersonThree };
            return arrayPerson;
        }


        public static (PersonList, PersonList) TestCreateTwoListOfPerson()
        {
            var firstList = new PersonList();
            var secondList = new PersonList();

            Person[] arrayOfPersons = CreateSixPersons();

            for (int i = 0; i < 3; i++)
            {
                firstList.Add(arrayOfPersons[i]);
                secondList.Add(arrayOfPersons[i + 3]);
            }
            ColorTitle($"Созданы списки: {nameof(firstList)} и" +
                $" {nameof(secondList)}.");
            ReadKeyForContinue();
            return (firstList, secondList);
        }

        public static void TestPrintOfTwoList(
            PersonList firstList,
            PersonList secondList
        )
        {
            PrintList(firstList, "firstList");
            PrintList(secondList, "secondList");

        }

        public static void TestAddPerson(PersonList firstList)
        {
            Person firstListPersonFour = new Person("Oleg", "Rasputin", 44, Gender.Female);
            firstList.Add(firstListPersonFour);
            firstListPersonFour.Print();
            PrintList(firstList, "firstList");
        }

        public static void TestCopyReferenceEquals(
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

        public static void TestRemovePerson(
            PersonList firstList,
            PersonList secondList
        )
        {
            firstList.RemoveAt(1);
            PrintList(firstList, "firstList");
            PrintList(secondList, "secondList");
        }

        public static void TestClearList(PersonList personList, string name)
        {
            personList.Clear();
            Console.WriteLine("Количество элементов в списке {0}: {1}",
                name, personList.Count);
        }

    }
}
