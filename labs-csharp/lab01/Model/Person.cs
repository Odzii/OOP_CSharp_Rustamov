using System;
namespace Model
{
    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
    public class Person
    {

        private string _name;
        private string _surname;
        private int _age;
        private Gender _gender;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public int Age
        {
            get => _age;
            set => _age = Math.Max(Math.Min(value, 150), 0);
        }

        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public Person(string name, string surname, int age, Gender gender)
        {
            _name = name;
            _surname = surname;
            Age =  age;
            _gender = gender;
        }
      

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
