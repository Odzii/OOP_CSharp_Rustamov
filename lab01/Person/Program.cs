using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
namespace Person
{
    /// <summary>
    /// Представляет человека с именем и фамилией, возрастом и полом. <see cref="Person"/>
    /// </summary>

    public class Person
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        private string _name;
        
        /// <summary>
        /// Фамилия человека
        /// </summary>
        private string _surname;
        
        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;
        
        /// <summary>
        /// Пол человека
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Получает или задает имя человека
        /// </summary>
        public string Name
        {
            get => _name;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(
                        "Имя не может быть пустым, содержать только пробелы или быть null.",
                        nameof(value)
                    );

                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Имя не может содержать цифр.", nameof(Name));
                
                _name = value;
             }
        }

        /// <summary>
        /// Получает или задает фамилию человека
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Фамилия не может быть пустой или Null.", nameof(Surname));

                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Фамилия не может содержать цифр.", nameof(Surname));

                _surname = value; }
        }

        /// <summary>
        /// Получает или задает возраст человека в полных годах.
        /// Значение ограничивается диапазоном от 0 до 150 включительно.
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                const int minAge = 0;
                const int maxAge = 150;
                if (value < minAge || value > maxAge)
                    throw new ArgumentOutOfRangeException(
                        nameof(Age),
                        $"Возраст должен быть от {minAge} до {maxAge}."
                    );

                _age = value;
            }
        }

        /// <summary>
        /// Получить или и проверить гендер человека.
        /// </summary>
        public Gender Gender
        {
            get => _gender;
            set
            {
                if (value == Gender.Unknown)
                    throw new ArgumentException("Пол должен быть явно указан Male или Female.", nameof(value));
                _gender = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класс <see cref="Person""/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Person(string name, string surname, int age, Gender gender)
        {   
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }


        static void Main(string[] args)
        {
            Person person = new Person("Ruslan", "Rustamov", 162222, Gender.Male);
            Console.WriteLine(person.Gender);
        }
    }
}
