using System;
using System.Text.RegularExpressions;
using static Khmil_lab_2.Models.PersonExeption;

namespace Khmil_lab_2.Models
{
    class Person
    {

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if ((firstName.Length < 2) || (Regex.IsMatch(firstName, "[^a-zA-Z]"))) throw new InvalidNameException(firstName);
            else
            {
                if ((lastName.Length < 2) || (Regex.IsMatch(lastName, "[^a-zA-Z]"))) throw new InvalidLastNameException(lastName);
                else
                {
                    if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) throw new InvalidEmailAddressException(email);
                    else
                    {
                        if (dateOfBirth > DateTime.Now) throw new InvalidFDate(dateOfBirth);
                        else
                        {
                            if (dateOfBirth < new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day)) throw new InvalidDDate(dateOfBirth);
                            else
                            {
                                _firstName = firstName;
                                _lastName = lastName;
                                _email = email;
                                _dateOfBirth = dateOfBirth;
                            }
                        }
                    }
                }
            }
        }

        internal string Name
        {
            get { return _firstName; }
            private set
            {
                _firstName = value;
            }
        }


        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set
            {
                _dateOfBirth = value;
            }
        }

        public bool isAdult()
        {
            return (DateTime.Now.Year - _dateOfBirth.Year) >= 18;
        }

        public bool IsBirthday()
        {
            return _dateOfBirth.Day == DateTime.Today.Day && _dateOfBirth.Month == DateTime.Today.Month;
        }

        public string ChineseSign()
        {
            string[] zodiacSigns = {
                "Щур",
                "Бик",
                "Тигр",
                "Кролик",
                "Дракон",
                "Змія",
                "Кінь",
                "Вівці",
                "Мавпа",
                "Півень",
                "Собака",
                "Свиня"
            };

            const int ZodiacStartYear = 4; //1960
            const int Months = 12;

            int remainder = (_dateOfBirth.Year - ZodiacStartYear) % Months;

            return zodiacSigns[remainder];
        }

        public string SunSign()
        {
            string str = "";
            switch (_dateOfBirth.Month)
            {
                case 1:
                    str = _dateOfBirth.Day <= 20 ? "Козеріг" : "Водолій";
                    break;
                case 2:
                    str = _dateOfBirth.Day <= 18 ? "Водолій" : "Риби";
                    break;
                case 3:
                    str = _dateOfBirth.Day <= 20 ? "Риби" : "Овен";
                    break;
                case 4:
                    str = _dateOfBirth.Day <= 20 ? "Овен" : "Тельці";
                    break;
                case 5:
                    str = _dateOfBirth.Day <= 21 ? "Тельці" : "Близнюки";
                    break;
                case 6:
                    str = _dateOfBirth.Day <= 21 ? "Близнюки" : "Рак";
                    break;
                case 7:
                    str = _dateOfBirth.Day <= 22 ? "Рак" : "Лев";
                    break;
                case 8:
                    str = _dateOfBirth.Day <= 23 ? "Лев" : "Діва";
                    break;
                case 9:
                    str = _dateOfBirth.Day <= 23 ? "Діва" : "Терези";
                    break;
                case 10:
                    str = _dateOfBirth.Day <= 23 ? "Терези" : "Скорпіон";
                    break;
                case 11:
                    str = _dateOfBirth.Day <= 22 ? "Скорпіон" : "Стрілець";
                    break;
                case 12:
                    str = _dateOfBirth.Day <= 21 ? "Стрілець" : "Козеріг";
                    break;
                default:
                    str = "Ваш знак зодіаку не знайшли! Спробуйте ще раз!";
                    break;
            }
            return str;
        }
    }
}
