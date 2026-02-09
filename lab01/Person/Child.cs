using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFirst
{
    /// <summary>
    /// Ребенок: родители и детский сад/школа.
    /// </summary>
    internal class Child : Person
    {
        /// <summary>
        /// Максимальный возраст ребенка.
        /// </summary>
        private const int MaxAge = AgeRules.ChildMaxAge;

        /// <summary>
        /// Мать ребенка (может быть Null).
        /// </summary>
        public Adult? Mother
        {
            get;
            private set;
        }

        /// <summary>
        /// Отец ребенка (может быть Null).
        /// </summary>
        public Adult? Father
        {
            get;
            private set;
        }

        public string? EducationPlaceName
        {
            get;
            private set;
        }

        /// <summary>
        /// Получить значение возраста.
        /// </summary>
        public new int Age
        {
            get => base.Age;

            set
            {
                if (value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"Для Child возраст должен быть не больше 18 лет"
                    );
                }

                base.Age = value;
            }
        }

        /// <summary>
        /// Создает пустой объект <see cref="Adult"/>.
        /// </summary>
        public Child()
        {

        }

        /// <summary>
        /// Создаёт ребёнка с основными данными.
        /// </summary>
        public Child(
            string name,
            string surname,
            int age,
            Gender gender,
            Adult? mother = null,
            Adult? father = null,
            string? educationPlaceName = null
        ) : base(name, surname, MaxAge, gender)
        {
            Age = age;

            SetParents(mother, father);

            if (!string.IsNullOrWhiteSpace(educationPlaceName))
            {
                SetEducationPlace(educationPlaceName);
            }
        }

        public void SetParents(Adult? mother, Adult? father)
        {
            if (mother is not null && mother.Age < AgeRules.AdultMinAge)
            {
                throw new ArgumentException(
                    $"Мать должна быть {nameof(Adult)} " +
                    $"или/и возраст не меньше {AgeRules.AdultMinAge}",
                    nameof(mother)
                );
            }

            if (father is not null && father.Age < AgeRules.AdultMinAge)
            {
                throw new ArgumentException(
                    $"Отец должен быть {nameof(Adult)} " +
                    $"или/и возраст не меньше {AgeRules.AdultMinAge}",
                    nameof(father)
                );
            }

            Father = father;
            Mother = mother;
        }

        /// <summary>
        /// Задать детский сад или школу.
        /// </summary>
        /// <param name="educationPlaceName">Десткий сад/школа</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывает исключение в случае null или strint.Empty</exception>
        public void SetEducationPlace(string educationPlaceName)
        {
            if (string.IsNullOrWhiteSpace(educationPlaceName))
            {
                throw new ArgumentException(
                    "Название детского сада/школы не может быть пустым.",
                    nameof(educationPlaceName)
                    );
            }

            EducationPlaceName = educationPlaceName;
        }

        /// <summary>
        /// Очистить название детского сада/школы.
        /// </summary>
        public void ClearEducationPlace()
        {
            EducationPlaceName = null;
        }

        /// <summary>
        /// Формат вывода основных данных о 
        /// <see cref="Child"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string motherInfo = 
                Mother is null 
                ? "-" 
                : $"{Mother.Name} {Mother.Surname}";

            string fatherInfo = 
                Father is null 
                ? "-" 
                : $"{Father.Name} {Father.Surname}";
            string placeEducationName = 
                string.IsNullOrWhiteSpace(EducationPlaceName) 
                ? "-" 
                : EducationPlaceName;

            return base.ToString()
                + $"\tMother: {motherInfo}"
                + $"\tFather: {fatherInfo}"
                + $"EducationPlaceName: {placeEducationName}";
        }
    }
}
