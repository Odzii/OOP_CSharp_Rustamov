using Model.Collections;
using Model.Enums;
using Model.Factories;
using Model.Interfaces;
using Model.Models;
using Model.Sources;
using System;
using System.IO;

namespace SecondLab
{
    /// <summary>
    /// Точка входа в консольное приложение лабораторной работы.
    /// </summary>
    internal static class Program
    {
        //TODO: XML
        private static void Main()
        {
            Random random = new Random();

            IPersonNameSource personSource = new PersonNameFileSource(
                malePath: MalePath,
                femalePath: FemalePath,
                surnamePath: SurnamePath
            );

            IAdultDataSource adultSource = new AdultFileSource(
                passportsIssuedByPath: PassportsIssuedByPath,
                workplaceNamesPath: WorkplaceNamesPath
            );

            IChildEducationSource childSource = new ChildEducationFileSource(
                kinderGardensPath: KinderGardensPath,
                schoolsPath: SchoolsPath
            );

            IPersonFactory<Adult> adultFactory =
                new RandomAdultFactory(
                    personSource,
                    adultSource,
                    random
                );

            IPersonFactory<Child> childFactory =
                new RandomChildFactory(
                    personSource,
                    adultSource,
                    childSource,
                    random
                );

            WriteTaskHeader(
                'a',
                "Создаём список и добавляем 7 человек в случайном порядке."
            );

            PersonList personList = new();

            for (int i = 0; i < 7; i++)
            {
                int pick = random.Next(2);
                Person person = pick == 0 
                    ? adultFactory.Create() 
                    : childFactory.Create();
                
                personList.Add(person);
            }

            WaitForKey();

            WriteTaskHeader(
                'b',
                "Выводим описание всех людей списка."
            );

            WriteGreenHeader("=== Описание всех людей ===");
            for (int i = 0; i < personList.Count; i++)
            {
                WriteRedHeader($"--- #{i + 1} " +
                    $"({personList[i].GetType().Name}) ---"
                );

                Console.WriteLine(personList[i].GetInfo());
                Console.WriteLine();
            }

            WaitForKey();

            WriteTaskHeader(
                'c',
                "Определяем тип 4-го человека и вызываем специфичный метод."
            );

            Person fourth = personList[3];

            WriteGreenHeader("=== Проверка 4-го человека ===");
            Console.WriteLine(
                $"4-й человек имеет тип: " +
                $"{fourth.GetType().Name}"
            );

            if (fourth is Adult adult)
            {
                if (adult.Status != MaritalStatus.Single)
                {
                    Console.WriteLine("=== Вызов Divorce ===");

                    adult.Divorce();

                    Console.WriteLine($"Брак очищено: {adult.Status}.");
                }
                else
                {
                    Console.WriteLine("=== Вызов Marry ===");

                    adult.Marry(adultFactory.Create());

                    Console.WriteLine($"Добавлен партнер: {adult.Partner}.");
                }
            }

            else if (fourth is Child child)
            {
                Console.WriteLine("=== Вызов EducationPlaceName ===");

                child.ClearEducationPlace();
                
                Console.WriteLine(
                    $"Место обучения очищено: {child.EducationPlaceName}."
                );
            }

            Console.WriteLine();

            WriteGreenHeader("=== Описание 4-го после вызова метода ===");

            Console.WriteLine(fourth.GetInfo());

            WaitForKey();
        }

        //TODO: XML
        private static void WriteGreenHeader(string text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(text);

            Console.ForegroundColor = oldColor;
        }

        //TODO: XML
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
        private static readonly string MalePath = Path.Combine(
            DataDir, 
            "MalesNames.txt"
        );

        /// <summary>
        /// Путь к файлу со списком женских имён.
        /// </summary>
        private static readonly string FemalePath = Path.Combine(
            DataDir, 
            "FemalesNamesPerson.txt"
        );

        /// <summary>
        /// Путь к файлу со списком фамилий.
        /// </summary>
        private static readonly string SurnamePath = Path.Combine(
            DataDir, 
            "DataSurnamesPerson.txt"
        );

        /// <summary>
        /// Путь к файлу со списком "кем выдан паспорт".
        /// </summary>
        private static readonly string PassportsIssuedByPath = Path.Combine(
            DataDir, 
            "DataPassportIssuedBy.txt"
        );

        /// <summary>
        /// Путь к файлу со списком мест работы.
        /// </summary>
        private static readonly string WorkplaceNamesPath = Path.Combine(
            DataDir,
            "DataWorkplaces.txt"
        );

        /// <summary>
        /// Путь к файлу со списком детских садов.
        /// </summary>
        private static readonly string KinderGardensPath = Path.Combine(
            DataDir,
            "DataKinderGardens.txt"
        );

        /// <summary>
        /// Путь к файлу со списком школ.
        /// </summary>
        private static readonly string SchoolsPath = Path.Combine(
            DataDir,
            "DataSchools.txt"
        );

        /// <summary>
        /// Метод ожидающий нажатия клавиши для продолжения, 
        /// с выводом сообщения.
        /// </summary>
        /// <param name="message">
        /// Сообщение, выводимое перед ожиданием нажатия клавиши 
        /// </param>
        private static void WaitForKey
            (string message = "Нажмите любую клавишу для продолжения..."
        )
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);

            Console.ForegroundColor = oldColor;

            Console.ReadKey(intercept: true);
            Console.WriteLine();
        }

        /// <summary>
        /// Подсветка заголовка задачи с указанием буквы задачи и текста
        /// </summary>
        /// <param name="taskLetter"> Буква пункта задания </param>
        /// <param name="text"> Название задания </param>
        private static void WriteTaskHeader(char taskLetter, string text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[{taskLetter}] ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);

            Console.ForegroundColor = oldColor;
        }
    }
}