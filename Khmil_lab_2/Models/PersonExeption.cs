using System;

namespace Khmil_lab_2.Models
{
    class PersonExeption : Exception
    {
        public PersonExeption(string message) : base(message) { }

        public class InvalidNameException : PersonExeption
        {
            internal InvalidNameException(string name) : base(name + " - не може таким бути ім'ям.(тільки англ алфавіт)") { }
        }

        public class InvalidLastNameException : Exception
        {
            internal InvalidLastNameException(string lastName) : base(lastName + " - не може таким бути прізвище.(тільки англ алфавіт") { }
        }

        public class InvalidEmailAddressException : Exception
        {
            internal InvalidEmailAddressException(string email) : base(email + " - невірно введена електронна адреса.") { }
        }

        public class InvalidDDate : Exception
        {
            internal InvalidDDate(DateTime date) : base(date.ToShortDateString() + " - дата надто давня, людина вже б ймовірно померла.") { }
        }

        public class InvalidFDate : Exception
        {
            internal InvalidFDate(DateTime date) : base(date.ToShortDateString() + " - цей день ще не почався") { }
        }
    }
}
