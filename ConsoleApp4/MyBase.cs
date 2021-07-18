using System;

namespace ConsoleApp4
{
    class MyBase
    {
        private string Name;
        private string Surname;
        private string Patronymic;
        private DateTime date;

        // Конструктор класса
        public MyBase(string Name, string Surname, string Patronymic, DateTime date)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            this.date = date;
        }

        // Находим самую длинную строку
        public static int FriendsMaxString(MyBase[] friends)
        {
            int indexLenght = 0;
            string myfriends;
            for (int i = 0; i < friends.Length; i++)
            {
                myfriends = String.Concat(friends[i].Name, " ", friends[i].Surname, " ", friends[i].Patronymic);
                if (myfriends.Length > indexLenght)
                    indexLenght = myfriends.Length;
            }
            return indexLenght;
        }

        // Вывод на экран друга
        public static void PrintFriend(MyBase friend, int indexLenght)
        {
            string myfriend = String.Concat(friend.Name, " ", friend.Surname, " ", friend.Patronymic).PadRight(indexLenght);
            Console.WriteLine($"ФИО: {myfriend} | Дата рождения: {friend.date.ToString("d")}");
        }

        // Выводит дни рождения к текущей дате
        public static void PrintTodeyBirthdays(MyBase[] friends)
        {
            Console.WriteLine("\nСегодня день рождение: ");
            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i].date.Day == DateTime.Today.Day && friends[i].date.Month == DateTime.Today.Month)
                    PrintFriend(friends[i], FriendsMaxString(friends)+3);
            }
        }

        // Выводит ближайшие дни рождения
        public static void UpcomingBirthdays(MyBase[] friends)
        {
            DateTime ThisDate = DateTime.Today.AddDays(20);
            Console.WriteLine("\nБлижайшие дни рождения (20 дней): ");
            for (int i = 0; i < friends.Length; i++)
            {
                if ((friends[i].date.Day > DateTime.Today.Day && friends[i].date.Month < ThisDate.Month) ||
                (friends[i].date.Day <= ThisDate.Day && friends[i].date.Month == ThisDate.Month))
                    PrintFriend(friends[i], FriendsMaxString(friends)+3);
            }
        }
    }
}
