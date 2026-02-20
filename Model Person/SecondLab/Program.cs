using Model.Factories;
using Model.Interfaces;
using Model.Models;
using Model.Sources;
using static System.Net.Mime.MediaTypeNames;

namespace SecondLab
{
    /// <summary>
    /// Точка входа в консольное приложение лабораторной работы.
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Random random = new Random();

            IPersonNameSource personSource = new PersonNameFileSource(
                malePath: MalePath,
                femalePath: FemalePath,
                surnamePath: SurnamePath);

            IAdultDataSource adultSource = new AdultFileSource(
                passportsIssuedByPath: PassportsIssuedByPath,
                workplaceNamesPath: WorkplaceNamesPath);

            IChildEducationSource childSource = new ChildEducationFileSource(
                kinderGardensPath: KinderGardensPath,
                schoolsPath: SchoolsPath);

            IPersonFactory<Adult> adultFactory =
                new RandomAdultFactory(personSource, adultSource, random);

            IPersonFactory<Child> childFactory =
                new RandomChildFactory(personSource, adultSource, childSource, random);

            // a) Создаём список и добавляем 7 человек в случайном порядке.
            List<Person> personList = new();

            for (int i = 0; i < 7; i++)
            {
                int pick = random.Next(2);
                Person p = pick == 0 ? adultFactory.Create() : childFactory.Create();
                personList.Add(p);
            }

            // b) Вывод описания всех людей списка.
            WriteGreenHeader("=== Описание всех людей ===");
            for (int i = 0; i < personList.Count; i++)
            {
                WriteRedHeader($"--- #{i + 1} ({personList[i].GetType().Name}) ---");
                //Console.WriteLine();
                Console.WriteLine(personList[i].GetInfo());
                Console.WriteLine();
            }

            // c) Проверка 4-го человека и вызов специфичного метода.
            Person fourth = personList[3];

            WriteGreenHeader("=== Проверка 4-го человека ===");
            Console.WriteLine($"4-й человек имеет тип: {fourth.GetType().Name}");

            if (fourth is Adult a)
            {
                // Метод только для Adult.
                a.WorkplaceName = string.Empty;
                Console.WriteLine("WorkplaceName очищено (Adult).");
            }
            else if (fourth is Child c)
            {
                // Метод только для Child.
                c.ClearEducationPlace();
                Console.WriteLine(
                    "Вызван Child.ClearEducationPlace() место обучения очищено.");
            }

            Console.WriteLine();
            WriteGreenHeader("=== Описание 4-го после вызова метода ===");
            Console.WriteLine(fourth.GetInfo());
        }

        private static void WriteGreenHeader(string text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(text);

            Console.ForegroundColor = oldColor;
        }

        private static void WriteRedHeader(string text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(text);

            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        /// Каталог с файлами исходных данных для генерации людей.
        /// </summary>
        private const string DataDir = "DataRandomPerson";

        /// <summary>
        /// Путь к файлу со списком мужских имён.
        /// </summary>
        private const string MalePath = DataDir + "/MalesNames.txt";

        /// <summary>
        /// Путь к файлу со списком женских имён.
        /// </summary>
        private const string FemalePath = DataDir + "/FemalesNamesPerson.txt";

        /// <summary>
        /// Путь к файлу со списком фамилий.
        /// </summary>
        private const string SurnamePath = DataDir + "/DataSurnamesPerson.txt";

        /// <summary>
        /// Путь к файлу со списком "кем выдан паспорт".
        /// </summary>
        private const string PassportsIssuedByPath =
            DataDir + "/DataPassportIssuedBy.txt";

        /// <summary>
        /// Путь к файлу со списком мест работы.
        /// </summary>
        private const string WorkplaceNamesPath =
            DataDir + "/DataWorkplaces.txt";

        /// <summary>
        /// Путь к файлу со списком детских садов.
        /// </summary>
        private const string KinderGardensPath =
            DataDir + "/DataKinderGardens.txt";

        /// <summary>
        /// Путь к файлу со списком школ.
        /// </summary>
        private const string SchoolsPath = DataDir + "/DataSchools.txt";
    }
}