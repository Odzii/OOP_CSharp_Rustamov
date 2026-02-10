using System;
using System.Collections.Generic;
using System.IO;

namespace LabFirst
{
    /// <summary>
    /// Создаёт экземпляры <see cref="Person"/>, 
    /// запрашивая данные у пользователя через консоль.
    /// </summary>
    public sealed class ConsolePersonFactory : IPersonFactory<Person>
    {
        private static readonly HashSet<string> FemaleTokens =
            new(StringComparer.OrdinalIgnoreCase)
            {
                "ж",
                "женский",
                "f",
                "female",
            };

        private static readonly HashSet<string> MaleTokens =
            new(StringComparer.OrdinalIgnoreCase)
            {
                "м",
                "мужской",
                "m",
                "male",
            };

        /// <summary>
        /// Создание объекта для чтения данных с консоли
        /// </summary>
        private readonly TextReader _input;

        /// <summary>
        /// Создание объекта для вывода данных на консоль
        /// </summary>
        private readonly TextWriter _output;

        /// <summary>
        /// Инициализирует новый экземпляр класса 
        /// <see cref="ConsolePersonFactory"/>.
        /// </summary>
        /// <param name="input">Поток ввода.</param>
        /// <param name="output">Поток вывода.</param>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если <paramref name="input"/> 
        /// или <paramref name="output"/> равны <see langword="null"/>.
        /// </exception>
        public ConsolePersonFactory(TextReader input, TextWriter output)
        {
            _input = input 
                ?? throw new ArgumentNullException(nameof(input));
            _output = output 
                ?? throw new ArgumentNullException(nameof(output));
        }

        /// <summary>
        /// Создаёт экземпляр <see cref="Person"/>, 
        /// запрашивая имя, фамилию, возраст и пол у пользователя.
        /// </summary>
        /// <returns>Созданный экземпляр <see cref="Person"/>.</returns>
        public Person Create()
        {
            var person = new Person();

            ReadAndAssignNamePart("Введите имя: ", value 
                => person.Name = value);
            ReadAndAssignNamePart("Введите фамилию: ", value 
                => person.Surname = value);

            person.Age = ReadAge();
            person.Gender = ReadGender();

            _output.WriteLine("Создан экземпляр класса Person.");
            return person;
        }

        private void ReadAndAssignNamePart(string prompt, Action<string> assign)
        {
            if (assign is null)
            {
                throw new ArgumentNullException(nameof(assign));
            }

            while (true)
            {
                _output.Write(prompt);

                string input = (_input.ReadLine() ?? string.Empty).Trim();

                try
                {
                    assign(input);
                    return;
                }
                catch (ArgumentException ex)
                {
                    _output.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Считывает возраст из ввода пользователя.
        /// </summary>
        /// <returns>Возраст в годах.</returns>
        private int ReadAge()
        {
            while (true)
            {
                _output.Write(
                    $"Введите возраст " +
                    $"({Person.MinAge}-{Person.MaxAge}): ");

                string input = (_input.ReadLine() ?? string.Empty).Trim();

                if (!int.TryParse(input, out int age))
                {
                    _output.WriteLine("Некорректный возраст. Повторите ввод.");
                    continue;
                }

                if (age < Person.MinAge || age > Person.MaxAge)
                {
                    _output.WriteLine(
                        $"Возраст должен быть от {Person.MinAge} " +
                        $"до {Person.MaxAge}.");
                    continue;
                }

                return age;
            }
        }

        /// <summary>
        /// Считывает пол из потока ввода.
        /// </summary>
        /// <returns>Значение пола.</returns>
        private Gender ReadGender()
        {
            _output.WriteLine(
                "Введите пол (без учета регистра): " +
                "Male/Female или m/f, Женский/Мужской или ж/м."
            );

            while (true)
            {
                _output.Write("Пол: ");

                string input = (_input.ReadLine() ?? string.Empty).Trim();

                if (FemaleTokens.Contains(input))
                {
                    return Gender.Female;
                }

                if (MaleTokens.Contains(input))
                {
                    return Gender.Male;
                }

                _output.WriteLine("Пол не распознан. Повторите ввод.");
            }
        }
    }
}
