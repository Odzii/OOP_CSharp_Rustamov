using System.Text;

namespace Model.Models
{
    /// <summary>
    /// Ребенок: родители и детский сад/школа.
    /// </summary>
    public class Child : Person
    {
        /// <summary>
        /// Максимальный возраст ребенка.
        /// </summary>
        private const int ChildMaxAge = Limits.ChildMaxAge;

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
        
        /// <summary>
        /// Наименования места образования.
        /// </summary>
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
                if (value > ChildMaxAge)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        //TODO: magic (to const)
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
        ) : base(name, surname, ChildMaxAge, gender)
        {
            Age = age;

            SetParents(mother, father);

            if (!string.IsNullOrWhiteSpace(educationPlaceName))
            {
                SetEducationPlace(educationPlaceName);
            }
        }

        /// <summary>
        /// Установить родителей для <see cref="Child"/>.
        /// </summary>
        /// <param name="mother"></param>
        /// <param name="father"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>
        /// <see cref="Father"/> Отец и
        /// <see cref="Mother"/> мать.
        /// </returns>
        public void SetParents(Adult? mother, Adult? father)
        {
            if (mother is not null && mother.Age < Limits.AdultMinAge)
            {
                throw new ArgumentException(
                    $"Мать должна быть {nameof(Adult)} " +
                    $"или/и возраст не меньше {Limits.AdultMinAge}",
                    nameof(mother)
                );
            }

            if (father is not null && father.Age < Limits.AdultMinAge)
            {
                throw new ArgumentException(
                    $"Отец должен быть {nameof(Adult)} " +
                    $"или/и возраст не меньше {Limits.AdultMinAge}",
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
        /// Возращает основную иформацию об <see cref="Child"/>,
        /// в виде строки типа <see cref="String"/>.
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.GetInfo());

            if (Mother is null && Father is null)
            {
                stringBuilder.AppendLine("Родители: не указаны");
            }
            else if (Mother is not null && Father is null)
            {
                stringBuilder.AppendLine($"Мать: " +
                    $"{Mother.ToBaseString()}");
                stringBuilder.AppendLine("Отец: не указан");
            }
            else if (Mother is null && Father is not null)
            {
                stringBuilder.AppendLine("Мать: не указана");
                stringBuilder.AppendLine($"Отец: " +
                    $"{Father.ToBaseString()}");
            }
            else
            {
                stringBuilder.AppendLine($"Мать: " +
                    $"{Mother!.ToBaseString()}");
                stringBuilder.AppendLine($"Отец: " +
                    $"{Father!.ToBaseString()}");
            }

            stringBuilder.AppendLine(
                string.IsNullOrWhiteSpace(EducationPlaceName)
                ? "Детский сад/школа: не указано"
                : $"Детский сад/школа: {EducationPlaceName}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
