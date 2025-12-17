using Lab01;
namespace FirstLab
{
    internal class Program
    {
        static void ReadKeyForContinue()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }

        // Создать метод, позволяющий создать список
        // для экземпляра класса Person 

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

        static void Main(string[] args)
        {
            //Console.WriteLine("Демонстрация правильности работы классов.");
            //ReadKeyForContinue();
            //Console.WriteLine("Шаг 1: Создание двух списков ");
            //var firstList = new PersonList();
            //var firstListPersonOne = new Person("Ruslan", "Rustamov", 16, 
            //    Gender.Male);
            //var firstListPersonTwo = new Person("Ivan", "Ivanov", 20, 
            //    Gender.Male);
            //var firstListPersonThree = new Person("Noname", "Nonamovich", 
            //    110, Gender.Female);
            //firstList.Add(firstListPersonOne);
            //firstList.Add(firstListPersonTwo);
            //firstList.Add(firstListPersonThree);

            //var secondList = new PersonList();
            //var secondListPersonOne = new Person("Борис", "Бритва", 16,
            //    Gender.Male);
            //var secondListPersonTwo = new Person("Арес", "Аресов", 20,
            //    Gender.Male);
            //var secondListPersonThree = new Person("Пушка", "Гонка",
            //    110, Gender.Female);
            //secondList.Add(secondListPersonOne);
            //secondList.Add(secondListPersonTwo);
            //secondList.Add(secondListPersonThree);

            //Console.WriteLine($"Созданы списки: {nameof(firstList)} и" +
            //    $" {nameof(secondList)}.");

            //ReadKeyForContinue();
            //Console.WriteLine("Шаг 2: Вывод содержимого каждого списка" +
            //    " на экран");

            //PrintList(firstList, "firstList");
            //PrintList(secondList, "secondList");
            //ReadKeyForContinue();

            //Console.WriteLine($"Шаг 3: Добавление нового человека в список" +
            //    $" {nameof(firstList)} ");
            //Person firstListPersonFour = new Person("Oleg", "Rasputin", 44,
            //    Gender.Female);
            //firstList.Add(firstListPersonFour);
            //PrintList(firstList, "firstList");
            //ReadKeyForContinue();

            //Console.WriteLine($"Шаг 4: Пример работы с ссылочным типом данных");
            //Person secondPersonFromFirstList = firstList.GetAt(1);
            //secondList.Add(secondPersonFromFirstList);
            //Person personFromFirst = firstList.GetAt(1);
            //Person personFromSecond = secondList.GetAt(secondList.Count - 1);
            //bool sameObject = ReferenceEquals(personFromFirst, 
            //    personFromSecond);
            //Console.WriteLine("Скопированный из первого списка объект " +
            //    "и вставленный во второй список объект " +
            //    "являются одним и тем же объектом?: {0}", sameObject);
            //ReadKeyForContinue();

            //Console.WriteLine($"Шаг 5: Удаление второго человека " +
            //    $"из списка {nameof(firstList)}");
            //firstList.RemoveAt(1);
            //PrintList(firstList, "firstList");
            //PrintList(secondList, "secondList");
            //ReadKeyForContinue();

            //Console.WriteLine($"Шаг 6: Очистка списка {nameof(secondList)}");
            //secondList.Clear();
            //Console.WriteLine("Количество элементов в списке {0}", 
            //    secondList.Count);
            //ReadKeyForContinue();

            Person p1 = Person.GetRandomPerson();
            p1.Print();

            Console.WriteLine($"Задание 4: метод чтения персоны с клавиатуры " +
                $"вывод персоны на экран."
            );
            Person newPerson = new Person();
            newPerson.ReadFromConsole();
            newPerson.Print();
            ReadKeyForContinue();
        }
    }
}
