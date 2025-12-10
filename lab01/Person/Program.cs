using System;
namespace Person
{
    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
    /// <summary>
    /// Представляет человека с именем и фамилией, возрастом и полом.
    /// </summary>

    public class Person
    {

        private string _name;
        private string _surname;
        private int _age;
        private Gender _gender;

        /// <summary>
        /// Получает или задает имя человека
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Получает или задает фамилию человека
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        /// <summary>
        /// Получает или задает возраст человека в полных годах.
        /// Значение ограничивается диапазоном от 0 до 150 включительно.
        /// </summary>
        public int Age
        {
            get => _age;
            set => _age = Math.Max(Math.Min(value, 150), 0);
        }

        /// <summary>
        /// Получает или задает пол человека.
        /// </summary>
        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
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
            _name = name;
            _surname = surname;
            Age = age;
            _gender = gender;
        }


        static void Main(string[] args)
        {
            Person person = new Person("Ruslan", "Rustamov", 1600, Gender.Male);
            Console.WriteLine(person.Age);
        }
    }
}
