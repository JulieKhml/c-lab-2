using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Khmil_lab_2.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string _FirstName;
        private string _LastName;
        private string _Email;
        private DateTime _Birthday = DateTime.Now;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                OnPropertyChanged();

            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                OnPropertyChanged();

            }
        }
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();

            }
        }
        public DateTime Birthday
        {
            get { return _Birthday; }
            set
            {
                _Birthday = value;
                OnPropertyChanged();

            }
        }


        public bool isAdult()
        {
            return (DateTime.Now.Year - Birthday.Year) >= 18;
        }

        public bool IsBirthday()
        {
            return Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month;
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

            int remainder = (Birthday.Year - ZodiacStartYear) % Months;

            return zodiacSigns[remainder];
        }

        public string SunSign()
        {
            string str = "";
            switch (Birthday.Month)
            {
                case 1:
                    str = Birthday.Day <= 20 ? "Козеріг" : "Водолій";
                    break;
                case 2:
                    str = Birthday.Day <= 18 ? "Водолій" : "Риби";
                    break;
                case 3:
                    str = Birthday.Day <= 20 ? "Риби" : "Овен";
                    break;
                case 4:
                    str = Birthday.Day <= 20 ? "Овен" : "Тельці";
                    break;
                case 5:
                    str = Birthday.Day <= 21 ? "Тельці" : "Близнюки";
                    break;
                case 6:
                    str = Birthday.Day <= 21 ? "Близнюки" : "Рак";
                    break;
                case 7:
                    str = Birthday.Day <= 22 ? "Рак" : "Лев";
                    break;
                case 8:
                    str = Birthday.Day <= 23 ? "Лев" : "Діва";
                    break;
                case 9:
                    str = Birthday.Day <= 23 ? "Діва" : "Терези";
                    break;
                case 10:
                    str = Birthday.Day <= 23 ? "Терези" : "Скорпіон";
                    break;
                case 11:
                    str = Birthday.Day <= 22 ? "Скорпіон" : "Стрілець";
                    break;
                case 12:
                    str = Birthday.Day <= 21 ? "Стрілець" : "Козеріг";
                    break;
                default:
                    str = "Ваш знак зодіаку не знайшли! Спробуйте ще раз!";
                    break;
            }
            return str;
        }
 

        public DateTime MinDate
        {
            get { return new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day); }
        }
        public DateTime MaxDate
        {
            get { return DateTime.Now; }
        }
   
        public MainViewModel()
        {

        }

        public DelegateCommand GetInfo
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    try
                    {
                        MessageBox.Show("Ім'я: " + FirstName + "\n" +
                            "Прізвище: " + LastName + "\n" +
                            "Емейл: " + Email + "\n" +
                            "Дата народження: " + Birthday + "\n" +
                            "Чи 18 років? - " + isAdult().ToString() + "\n" +
                            "Західний сонячний знак: " + SunSign() + "\n" +
                            "Китайський астрологічний знак: " + ChineseSign() + "\n" +
                            "Чи сьогодні день народження? - " + IsBirthday().ToString()
                            );
                    }
                    catch(Exception)
                    {

                        MessageBox.Show("ERROR!!!!");
                    }
                }, (obj)=> (FirstName != null && LastName != null && Email != null && Birthday != null));

            }
        }

 
    }
}
