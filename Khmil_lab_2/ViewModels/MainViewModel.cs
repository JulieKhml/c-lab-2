using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Text.RegularExpressions;
using Khmil_lab_2.Models;
using System.Threading.Tasks;

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
                return new DelegateCommand((obj) => setPerson(obj), 
                    (obj)=> (FirstName != null && LastName != null
                    && Email != null && Birthday != null
                    && (Birthday > new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day))
                    && (Birthday < DateTime.Now)
                    && Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")));

            }
        }

        private async void setPerson(object o)
        {
            Person person = null;
            await Task.Run((() =>
            {
                try
                {
                    try
                    {
                        person = new Person(FirstName, LastName, Email, Birthday);
                        MessageBox.Show("Ім'я: " + FirstName + "\n" +
                            "Прізвище: " + LastName + "\n" +
                            "Емейл: " + Email + "\n" +
                            "Дата народження: " + Birthday + "\n" +
                            "Чи 18 років? - " + person.isAdult().ToString() + "\n" +
                            "Західний сонячний знак: " + person.SunSign() + "\n" +
                            "Китайський астрологічний знак: " + person.ChineseSign() + "\n" +
                            "Чи сьогодні день народження? - " + person.IsBirthday().ToString()
                            );
                    }
                    catch (Exception a)
                    {

                        MessageBox.Show(a.Message);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }));
        }



    }
}
