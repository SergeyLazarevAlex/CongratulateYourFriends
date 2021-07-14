using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class MyBase
    {
        private string Name;
        private string Surname;
        private string Patronymic;
        private DateTime date;

        //конструктор класса
        public MyBase(string Name, string Surname, string Patronymic, DateTime date)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            this.date = date;
        }

        // Вывод на экран друга
        public static void Print(MyBase frend)
        {
            Console.WriteLine($"ФИО: {frend.Name} {frend.Surname} {frend.Patronymic} . Дата рождения: {frend.date.ToString("d")}");
        }

        //Находит дни рождения к текущей дате
        public static void ToDeyBirthdays(MyBase frend)
        {
            if (frend.date.Day == DateTime.Today.Day && frend.date.Month == DateTime.Today.Month)
                Print(frend);
        }

        //Находит ближайшие дни рождения
        public static void UpcomingBirthdays(MyBase frend)
        {
            DateTime ThisDate = DateTime.Today.AddDays(20);
            if ((frend.date.Day > DateTime.Today.Day && frend.date.Month < ThisDate.Month) ||
                (frend.date.Day <= ThisDate.Day && frend.date.Month == ThisDate.Month))
                Print(frend);
        }
    }
}
