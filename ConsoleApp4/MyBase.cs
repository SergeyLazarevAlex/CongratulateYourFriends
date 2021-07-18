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
        public static void PrintFriend(MyBase friend)
        {
            Console.WriteLine($"ФИО: {friend.Name} {friend.Surname} {friend.Patronymic} . Дата рождения: {friend.date.ToString("d")}");
        }

        //Выводит дни рождения к текущей дате
        public static void PrintTodeyBirthdays(MyBase[] friends)
        {
            Console.WriteLine("\nСегодня день рождение: ");
            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i].date.Day == DateTime.Today.Day && friends[i].date.Month == DateTime.Today.Month)
                    PrintFriend(friends[i]);
            }
        }

        //Выводит ближайшие дни рождения
        public static void UpcomingBirthdays(MyBase[] friends)
        {
            DateTime ThisDate = DateTime.Today.AddDays(20);
            Console.WriteLine("\nБлижайшие дни рождения (20 дней): ");
            for (int i = 0; i < friends.Length; i++)
            {
                if ((friends[i].date.Day > DateTime.Today.Day && friends[i].date.Month < ThisDate.Month) ||
                (friends[i].date.Day <= ThisDate.Day && friends[i].date.Month == ThisDate.Month))
                    PrintFriend(friends[i]);
            }
        }
    }
}
