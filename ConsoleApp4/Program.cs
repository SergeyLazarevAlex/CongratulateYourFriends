using System;
using System.Globalization;

namespace ConsoleApp4
{
    class Program
    {
        // База моих друганов
        static MyBase[] MyFrends()
        {
            string[] Names = {"Сергей", "Сява","Тоха","Андрей","Рома"};
            string[] Surnames = {"Лазарев","Богров","Бородатый","Белов","Еремеев"};
            string[] Patronymics = {"Александрович", "Сявкин", "Чёрт", "Синяк", "Бендерович"};
            DateTime[] dateTimes = {new DateTime(1990, 12, 06), new DateTime(1991, 11, 06), new DateTime(1989, 07, 20), new DateTime(1990, 08, 01), new DateTime(1995, 07, 19)};
            MyBase[] frends = new MyBase[5];
            for (int i = 0; i < frends.Length; i++)            
                frends[i] = new MyBase(Names[i],Surnames[i],Patronymics[i],dateTimes[i]);
            return frends;
        }

        // Создание друга
        static MyBase CreateFrend()
        {
            Console.Write("Введите имя: ");
            string Name = Console.ReadLine();
            Console.Write("\nВведите отчество: ");
            string Surname = Console.ReadLine();
            Console.Write("\nВведите фамилию: ");
            string Patronymic = Console.ReadLine();
            Console.Write("\nВведите дату рождения (в формате dd.MM.yyyy) : ");
            string MyDate = Console.ReadLine();
            DateTime date = DateTime.ParseExact(MyDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            MyBase frend = new MyBase(Name,Surname,Patronymic,date);
            return frend;
        }

        // Добавление друга
        static void AddFrend(ref MyBase[] friends, MyBase myFrend)
        {
            MyBase[] newfrends = new MyBase[friends.Length + 1];
            for (int i = 0; i < friends.Length; i++)
                newfrends[i] = friends[i];
            newfrends[newfrends.Length - 1] = myFrend;
            friends = newfrends;
        }

        // Удаление друга
        static void DeleteFrend(ref MyBase[] friends)
        {
            Console.Write("\nВведите порядковый номер друга для удаления: ");
            byte indexfr = Convert.ToByte(Console.ReadLine());
            indexfr--;

            MyBase[] newFrends = new MyBase[friends.Length-1];

            for (int i = 0; i < friends.Length; i++)
            {
                if (i < indexfr)
                    newFrends[i] = friends[i];
                if (i == indexfr)
                    i++;
                if (i > indexfr && i!=friends.Length)
                    newFrends[i - 1] = friends[i];
            }

            friends = newFrends;
        }

        // Корректируем друга
        static void FixFrend(ref MyBase[] friends)
        {
            Console.Write("\nВведите порядковый номер друга которого нужно исправить: ");
            byte indexfr = Convert.ToByte(Console.ReadLine());
            indexfr--;
            friends[indexfr] = CreateFrend();
        }

        // Вывод всего на экран
        static void PrintAllInfo(MyBase[] friends)
        {
            Console.WriteLine("Днюхи:");
            for (int i = 0; i < friends.Length; i++)
            {
                Console.Write(i+1+") ");
                MyBase.PrintFriend(friends[i], MyBase.FriendsMaxString(friends));
            }
            MyBase.PrintTodeyBirthdays(friends);
            MyBase.UpcomingBirthdays(friends);
        }
        static void Main(string[] args)
        {
            //первый вывод таблицы
            MyBase[] friends = MyFrends();
            Console.WriteLine("Сегодня: "+ DateTime.Now.ToString("d"));
            PrintAllInfo(friends);
            ConsoleKey key;
            bool condition = true;
            do
            {
                Console.WriteLine("\nВведите операцию: ");
                Console.WriteLine("1 - добавить друга");
                Console.WriteLine("2 - удалить друга");
                Console.WriteLine("3 - редактировать друга");
                Console.WriteLine("Esc - выход");
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        //добавляем друга
                        Console.WriteLine("\nДобавляем нового приятеля: ");
                        MyBase fr = CreateFrend();
                        Console.Clear();
                        AddFrend(ref friends, fr);
                        PrintAllInfo(friends);
                        break;
                    case ConsoleKey.D2:
                        //удаляем друга
                        DeleteFrend(ref friends);
                        Console.Clear();
                        PrintAllInfo(friends);
                        break;
                    case ConsoleKey.D3:
                        //редактируем друга
                        Console.WriteLine("\nРедактируем приятеля: ");
                        FixFrend(ref friends);
                        Console.Clear();
                        PrintAllInfo(friends);
                        break;
                    case ConsoleKey.Escape:
                        //выход из программы
                        condition = false;
                        break;
                }
            }
            while (condition);
        }
    }
}
