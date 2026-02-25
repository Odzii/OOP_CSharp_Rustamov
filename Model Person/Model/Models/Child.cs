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
        public const int MaxAgeChild = Adult.MinAgeAdult - 1;

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
        /// Проверка корректного задания возраста <see cref="Child"/>
        /// </summary>
        /// <param name="value">
        /// Возраст (целочисленный тип)
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросает исключение о выходе за пределы.
        /// </exception>
        protected override void ValidateAge(int value)
        {
            base.ValidateAge(value);

            if (value > MaxAgeChild)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"Для Child возраст должен быть не больше " +
                    $"{MaxAgeChild} лет."
                );
            }
        }

        /// <summary>
        /// Создает пустой объект <see cref="Child"/>.
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
        ) : base(name, surname, MaxAgeChild, gender)
        {
            Age = age;

            SetParents(mother, father);

            if (!string.IsNullOrWhiteSpace(educationPlaceName))
            {
                SetEducationPlace(educationPlaceName);
            }
        }

        /// <param name="mother">Мать ребёнка (может быть null).</param>
        /// <param name="father">Отец ребёнка (может быть null).</param>
        /// <exception cref="ArgumentException">
        /// Возраст матери должен быть не меньше 18.
        /// </exception>
        public void SetParents(Adult? mother, Adult? father)
        {
            if (mother is not null && mother.Age < Adult.MinAgeAdult)
            {
                throw new ArgumentException(
                    $"Мать должна быть {nameof(Adult)} " +
                    $"или/и возраст не меньше {Adult.MinAgeAdult}",
                    nameof(mother)
                );
            }

            if (father is not null && father.Age < Adult.MinAgeAdult)
            {
                throw new ArgumentException(
                    $"Отец должен быть {nameof(Adult)} " +
                    $"или/и возраст не меньше {Adult.MinAgeAdult}",
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
        /// в виде строки типа <see cref="string"/>.
        /// </summary>
        /// <returns> 
        /// текстовое представление <see cref="Child"/>
        /// </returns>
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
                stringBuilder.AppendLine($"Мать: {Mother.ToBaseString()}");
                stringBuilder.AppendLine("Отец: не указан");
            }
            else if (Mother is null && Father is not null)
            {
                stringBuilder.AppendLine("Мать: не указана");
                stringBuilder.AppendLine($"Отец: {Father.ToBaseString()}");
            }
            else
            {
                stringBuilder.AppendLine($"Мать: {Mother!.ToBaseString()}");
                stringBuilder.AppendLine($"Отец: {Father!.ToBaseString()}");
            }

            stringBuilder.AppendLine(
                string.IsNullOrWhiteSpace(EducationPlaceName)
                ? "Детский сад/школа: не указано"
                : $"Детский сад/школа: {EducationPlaceName}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
