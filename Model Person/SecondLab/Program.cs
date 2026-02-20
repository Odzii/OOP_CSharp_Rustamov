using Model.Factories;
using Model.Interfaces;
using Model.Models;
using Model.Sources;

namespace SecondLab
{
    internal static class Program
    {
        private static void Main()
        {
            var random = new Random();

            //TODO: magic (to const)
            var source = new FileDataSource(
                malePath: "DataRandomPerson/MalesNames.txt",
                femalePath: "DataRandomPerson/FemalesNamesPerson.txt",
                surnamePath: "DataRandomPerson/DataSurnamesPerson.txt",
                passportsIssuedByPath: "DataRandomPerson/DataPassportIssuedBy.txt",
                workplaceNamesPath: "DataRandomPerson/DataWorkplaces.txt",
                kinderGardens: "DataRandomPerson/DataKinderGardens.txt",
                schools: "DataRandomPerson/DataSchools.txt"

            );

            IPersonFactory<Person> personFactory = new RandomPersonFactory(source, random);
            IPersonFactory<Adult> adultFactory = new RandomAdultFactory(source, random);
            IPersonFactory<Child> childFactory = new RandomChildFactory(source, random);

            // a) создаём список PersonList и добавляем 7 человек в случайном порядке
            List<Person> personList = new();

            for (int i = 0; i < 7; i++)
            {
                int pick = random.Next(2); // 0 - Adult, 1 - Child
                Person p = pick == 0 ? adultFactory.Create() : childFactory.Create();
                personList.Add(p);
            }

            // b) вывод описания всех людей списка
            Console.WriteLine("=== Описание всех людей ===");
            for (int i = 0; i < personList.Count; i++)
            {
                Console.WriteLine($"--- #{i + 1} ({personList[i].GetType().Name}) ---");
                Console.WriteLine(personList[i].GetInfo());
                Console.WriteLine();
            }

            // c) определить тип 4-го человека и вызвать специфичный метод
            Person fourth = personList[3];

            Console.WriteLine("=== Проверка 4-го человека ===");
            Console.WriteLine($"4-й человек имеет тип: {fourth.GetType().Name}");

            if (fourth is Adult a)
            {
                // метод только Adult 
                //TODO: add method Marry
                /// <see cref="Adult.Marry(Adult)"/>
                a.WorkplaceName = string.Empty;
                Console.WriteLine("Вызван Adult.ClearWorkplace() — место работы очищено.");
            }
            else if (fourth is Child c)
            {
                // метод только Child
                c.ClearEducationPlace();
                Console.WriteLine("Вызван Child.ClearEducationPlace() — место обучения очищено.");
            }

            Console.WriteLine();
            Console.WriteLine("=== Описание 4-го после вызова метода ===");
            Console.WriteLine(fourth.GetInfo());
        }
    }
}
