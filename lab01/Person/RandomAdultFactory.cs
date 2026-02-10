using System;
using LabFirst.Helpers;

namespace LabFirst
{
    public sealed class RandomAdultFactory : IPersonFactory<Adult>
    {
        private readonly Random _random;
        private readonly FileDataSource _adultData;

        private const int PassportSeriesLength = 4;
        private const int PassportNumberLength = 6;

        private const double MarriageProbability = 0.6;

        public RandomAdultFactory(FileDataSource adultData, Random random)
        {
            _adultData = adultData ?? throw new ArgumentNullException(nameof(adultData));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public Adult Create()
        {
            Adult adult = CreateSingleAdult();

            if (_random.NextDouble() < MarriageProbability)
            {
                Gender partnerGender = adult.Gender == Gender.Male
                    ? Gender.Female
                    : Gender.Male;

                Adult partner = CreateSingleAdult(forceGender: partnerGender);

                partner.Age = ClampAdultAge(adult.Age + _random.Next(-10, 11));

                adult.Marry(partner);
            }

            return adult;
        }

        private Adult CreateSingleAdult(Gender? forceGender = null)
        {
            Adult adult = new Adult();

            Gender gender = forceGender ?? (_random.Next(2) == 0 ? Gender.Male : Gender.Female);
            adult.Gender = gender;

            adult.Name = gender == Gender.Male
                ? _random.NextItem(_adultData.MaleNames, nameof(_adultData.MaleNames))
                : _random.NextItem(_adultData.FemaleNames, nameof(_adultData.FemaleNames));

            string surname = _random.NextItem(_adultData.Surnames, nameof(_adultData.Surnames));
            surname = RussianVowelsHelper.FixFemaleRussianSurname(surname, gender);
            adult.Surname = surname;

            adult.Age = _random.Next(AgeRules.AdultMinAge, AgeRules.PersonMaxAge + 1);

            string series = _random.Next(0, Pow10(PassportSeriesLength))
                .ToString($"D{PassportSeriesLength}");

            string number = _random.Next(0, Pow10(PassportNumberLength))
                .ToString($"D{PassportNumberLength}");

            string issuedBy = _random.NextItem(
                _adultData.PassportsIssuedBy,
                nameof(_adultData.PassportsIssuedBy)
            );

            DateOnly issueDate = CreateRandomIssueDate(_random, adult.Age);

            adult.SetPassport(series, number, issuedBy, issueDate);

            if (_random.NextDouble() < 0.85)
            {
                string work = _random.NextItem(
                    _adultData.WorkplaceNames,
                    nameof(_adultData.WorkplaceNames)
                );

                adult.SetWorkplace(work);
            }
            else
            {
                adult.ClearWorkplace();
            }

            return adult;
        }

        private static int ClampAdultAge(int age)
        {
            if (age < AgeRules.AdultMinAge) return AgeRules.AdultMinAge;
            if (age > AgeRules.PersonMaxAge) return AgeRules.PersonMaxAge;
            return age;
        }

        private static DateOnly NextDate(Random random, DateOnly fromInclusive, DateOnly toInclusive)
        {
            if (fromInclusive > toInclusive)
                throw new ArgumentException("Неверный диапазон дат.");

            int from = fromInclusive.DayNumber;
            int to = toInclusive.DayNumber;

            int dayNumber = random.Next(from, to + 1);
            return DateOnly.FromDayNumber(dayNumber);
        }

        private static DateOnly CreateRandomIssueDate(Random random, int age)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            DateOnly birthFrom = today.AddYears(-age - 1).AddDays(1);
            DateOnly birthTo = today.AddYears(-age);

            DateOnly birthDate = NextDate(random, birthFrom, birthTo);

            DateOnly issueFrom = birthDate.AddYears(AgeRules.AdultMinAge);
            if (issueFrom > today) issueFrom = today;

            return NextDate(random, issueFrom, today);
        }

        private static int Pow10(int n)
        {
            int x = 1;
            for (int i = 0; i < n; i++) x *= 10;
            return x;
        }
    }
}
