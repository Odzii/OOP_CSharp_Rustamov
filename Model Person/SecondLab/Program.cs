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
        /// <summary>
        /// Тестирование методов проекта <see cref="Model"/>
        /// в соответствии с заданием.
        /// </summary>
        private static void Main()
        {
            Random random = new Random();

            string DataDir = "DataRandomPerson";

            string MalePath = Path.Combine(
                DataDir,
                "MalesNames.txt"
            );

            string FemalePath = Path.Combine(
                DataDir,
                "FemalesNamesPerson.txt"
            );

            string SurnamePath = Path.Combine(
                DataDir,
                "DataSurnamesPerson.txt"
            );

            string PassportsIssuedByPath = Path.Combine(
                DataDir,
                "DataPassportIssuedBy.txt"
            );

            string WorkplaceNamesPath = Path.Combine(
                DataDir,
                "DataWorkplaces.txt"
            );

            string KinderGardensPath = Path.Combine(
                DataDir,
                "DataKinderGardens.txt"
            );

             string SchoolsPath = Path.Combine(
                DataDir,
                "DataSchools.txt"
            );


            IPersonNameSource personSource = new PersonNameFileSource(
                MalePath,
                FemalePath,
                SurnamePath
            );

            IAdultDataSource adultSource = new AdultFileSource(
                PassportsIssuedByPath,
                WorkplaceNamesPath
            );

            IChildEducationSource childSource = new ChildEducationFileSource(
                KinderGardensPath,
                SchoolsPath
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
                PersonBase person = pick == 0 
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

            PersonBase fourth = personList[3];

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