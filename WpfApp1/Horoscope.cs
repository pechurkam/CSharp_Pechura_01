using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CSharp_Pechura_01
{
    class Horoscope : INotifyPropertyChanged
    {

        private int _age;
        private string _date;
        private string _zodiacSign ;
        private string _zodiacSignCh;
        
       
        public string Age
        {
            get { return $"Ваш вік: {_age}"; }
            
        }
        
        public string Horosc
        {
            get { return $"Знак зодіаку за західною системою: {_zodiacSign}"; }
            set
            {
                _zodiacSign = value;
                OnPropertyChanged();
            } }
        public string HoroscChinese
        {
            get { return $"Китайською системою: {_zodiacSignCh}"; }
            set
            {
                _zodiacSignCh = value;
                OnPropertyChanged();
            }
        }
        public string CalcChineseHorosc()
        {
            string[] zodiacSigns = { "Криса", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака", "Свиня" };
     
            return zodiacSigns[(Convert.ToDateTime(_date).Year - 4) % 12]; 
        }
        public string CalcWesternHorosc()
        {
            DateTime dateToCheck = Convert.ToDateTime(_date);
            string zod = "";
            string[] zodiacSigns = {"Овен", "Телець", "Близнюки", "Paк", "Лев", "Діва", "Терези", "Скорпіон", "Стрілець", "Козоріг", "Водолій", "Риби" };
            if((dateToCheck.Month == 3 && dateToCheck.Day >= 21) || (dateToCheck.Month == 4 && dateToCheck.Day <= 20))
            {
                zod = zodiacSigns[0];
            } else if ((dateToCheck.Month == 4 && dateToCheck.Day >= 21) || (dateToCheck.Month == 5 && dateToCheck.Day <= 20))
            {
                zod = zodiacSigns[1];
            }
            else if ((dateToCheck.Month == 5 && dateToCheck.Day >= 21) || (dateToCheck.Month == 6 && dateToCheck.Day <= 21))
            {
                zod = zodiacSigns[2];
            }
            else if ((dateToCheck.Month == 6 && dateToCheck.Day >= 22) || (dateToCheck.Month == 7 && dateToCheck.Day <= 22))
            {
                zod = zodiacSigns[3];
            }
            else if ((dateToCheck.Month == 7 && dateToCheck.Day >= 23) || (dateToCheck.Month == 8 && dateToCheck.Day <= 23))
            {
                zod = zodiacSigns[4];
            }
            else if ((dateToCheck.Month == 8 && dateToCheck.Day >= 24) || (dateToCheck.Month == 9 && dateToCheck.Day <= 22))
            {
                zod = zodiacSigns[5];
            }
            else if ((dateToCheck.Month == 9 && dateToCheck.Day >= 23) || (dateToCheck.Month == 10 && dateToCheck.Day <= 23))
            {
                zod = zodiacSigns[6];
            }
            else if ((dateToCheck.Month == 10 && dateToCheck.Day >= 24) || (dateToCheck.Month == 11 && dateToCheck.Day <= 22))
            {
                zod = zodiacSigns[7];
            }
            else if ((dateToCheck.Month == 11 && dateToCheck.Day >= 23) || (dateToCheck.Month == 12 && dateToCheck.Day <= 21))
            {
                zod = zodiacSigns[8];
            }
            else if ((dateToCheck.Month == 12 && dateToCheck.Day >= 22) || (dateToCheck.Month == 1 && dateToCheck.Day <= 20))
            {
                zod = zodiacSigns[9];
            }
            else if ((dateToCheck.Month == 1 && dateToCheck.Day >= 21) || (dateToCheck.Month == 2 && dateToCheck.Day <= 20))
            {
                zod = zodiacSigns[10];
            }
            else if ((dateToCheck.Month == 2 && dateToCheck.Day >= 21) || (dateToCheck.Month == 3 && dateToCheck.Day <= 20))
            {
                zod = zodiacSigns[11];
            }
            return zod;
        }

        private async void SignInInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            
            await Task.Run(() => Thread.Sleep(1000));
            LoaderManager.Instance.HideLoader();
            
            _age = (DateTime.Today - Convert.ToDateTime(_date)).Days / 365;
            OnPropertyChanged(nameof(Age));

            OnPropertyChanged();

            Horosc = CalcWesternHorosc();
            HoroscChinese = CalcChineseHorosc();

            if (Convert.ToDateTime(_date) > DateTime.Today || _age > 135)
            {
                MessageBox.Show("Not correct date!");
            }
            if (Convert.ToDateTime(_date).Day == DateTime.Today.Day && Convert.ToDateTime(_date).Month == DateTime.Today.Month)
            {
                MessageBox.Show("Happy birthday, dear!" +
                                " I'm proud of you and wish you lots " +
                                "of love and happiness.");
            }
            
        }
        private RelayCommand<object> _signInCommand;
        public RelayCommand<object> SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(
                           SignInInplementation, o => CanExecuteCommand()));
            }
        }
        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_date);

        }
        public string GetDate
        {
            get => _date;
            set
            {
                _date = value;
               OnPropertyChanged();

            }
        }


        

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
