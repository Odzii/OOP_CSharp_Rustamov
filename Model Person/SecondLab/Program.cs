using System;
using System.IO;
using System.Xml.Serialization;

using Model.Collections;
using Model.Enums;
using Model.Factories;
using Model.Interfaces;
using Model.Models;
using Model.Sources;

namespace SecondLab
{
    /// <summary>
    /// Точка входа в консольное приложение лабораторной работы.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Тестирование методов проекта <see cref="Model"/>
        /// в соответствии с заданием.
        /// </summary>
        private static void Main()
        {
            Random random = new Random();

            string dataDirectory = "DataRandomPerson";

            string malePath = Path.Combine(dataDirectory, "MalesNames.txt");

            string femalePath = Path.Combine(dataDirectory, "FemalesNamesPerson.txt");

            string surnamePath = Path.Combine(dataDirectory, "DataSurnamesPerson.txt");

            string passportsIssuedByPath = Path.Combine(
                dataDirectory,
                "DataPassportIssuedBy.txt");

            string workplaceNamesPath = Path.Combine(
                dataDirectory,
                "DataWorkplaces.txt");

            string kinderGardensPath = Path.Combine(
                dataDirectory,
                "DataKinderGardens.txt");

             string schoolsPath = Path.Combine(
                dataDirectory,
                "DataSchools.txt");

            int countList = 7;


            IPersonNameSource personSource = new PersonNameFileSource(
                malePath,
                femalePath,
                surnamePath);

            IAdultDataSource adultSource = new AdultFileSource(
                passportsIssuedByPath,
                workplaceNamesPath);

            IChildEducationSource childSource = new ChildEducationFileSource(
                kinderGardensPath,
                schoolsPath);

            IPersonFactory<Adult> adultFactory =
                new RandomAdultFactory(
                    personSource,
                    adultSource,
                    random);

            IPersonFactory<Child> childFactory =
                new RandomChildFactory(
                    personSource,
                    adultSource,
                    childSource,
                    random);

            ConsoleColor colorTask = ConsoleColor.Green;

            ConsoleColor colorHeader = ConsoleColor.Red;

            ColorHeader(
                "a) Создаём список " +
                "и добавляем 7 человек в случайном порядке.",
                colorTask);

            PersonList personList = new();

            for (int i = 0; i < countList; i++)
            {
                int pick = random.Next(2);
                PersonBase person = pick == 0 
                    ? adultFactory.Create() 
                    : childFactory.Create();
                
                personList.Add(person);
            }

            WaitForKey();

            ColorHeader(
                "b) Выводим описание всех людей списка.",
                colorTask);

            ColorHeader(
                "=== Описание всех людей ===", 
                ConsoleColor.Green);

            for (int i = 0; i < personList.Count; i++)
            {
                ColorHeader(
                    $"--- #{i + 1} " +
                    $"({personList[i].GetType().Name}) ---",
                    colorHeader);

                Console.WriteLine(personList[i].GetInfo());
                Console.WriteLine();
            }

            WaitForKey();

            ColorHeader(
                "c) Определяем тип 4-го человека и вызываем специфичный метод.",
                colorTask);

            PersonBase fourth = personList[3];

            ColorHeader(
                "=== Проверка 4-го человека ===", 
                colorHeader);

            Console.WriteLine(
                $"4-й человек имеет тип: " +
                $"{fourth.GetType().Name}");

            if (fourth is Adult adult)
            {
                if (adult.Status == MaritalStatus.Married 
                    && adult.Partner != null)
                {
                    Console.WriteLine("=== Вызов Divorce ===");

                    adult.Divorce();

                    Console.WriteLine($"Брак очищен: {adult.Status}.");
                }
                else
                {
                    Console.WriteLine("=== Вызов Marry ===");

                    Adult partner;

                    do
                    {
                        partner = adultFactory.Create();
                    }
                    while (partner.Status == MaritalStatus.Married
                           || partner.Partner != null
                           || partner.Gender == adult.Gender);

                    adult.Marry(partner);

                    Console.WriteLine(
                        $"Добавлен партнер: " +
                        $"{adult.Partner?.Surname}.");
                }
            }

            else if (fourth is Child child)
            {
                Console.WriteLine("=== Вызов EducationPlaceName ===");

                child.ClearEducationPlace();
                
                Console.WriteLine(
                    $"Место обучения очищено: {child.EducationPlaceName}.");
            }

            Console.WriteLine();

            ColorHeader(
                "=== Описание 4-го после вызова метода ===", 
                 colorTask);

            Console.WriteLine(fourth.GetInfo());

            WaitForKey();
        }

        /// <summary>
        /// Позволяет закрасить текст заданным цветом
        /// </summary>
        /// <param name="text"> Текст</param>
        /// <param name="consoleColor"> Цвет</param>
        private static void ColorHeader(
            string text, 
            ConsoleColor consoleColor)
        {
            if (consoleColor is ConsoleColor color)
            {
                Console.ForegroundColor = color;
            }

            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод ожидающий нажатия клавиши для продолжения, 
        /// с выводом сообщения.
        /// </summary>
        /// <param name="message">
        /// Сообщение, выводимое перед ожиданием нажатия клавиши 
        /// </param>
        private static void WaitForKey(
            string message = "Нажмите любую клавишу для продолжения...")
        {
            ColorHeader(message, ConsoleColor.DarkGray);

            Console.ReadKey(intercept: true);
            Console.WriteLine();
        }
    }
}