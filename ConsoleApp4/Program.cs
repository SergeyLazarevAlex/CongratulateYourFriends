using System;
using System.Globalization;

namespace ConsoleApp4
{
    class Program
    {
        // База моих друганов
        static MyBase[] MyFrends()
        {
            MyBase[] frends = new MyBase[5];
            MyBase frend1 = new MyBase("Сергей", "Лазарев", "Александрович", new DateTime(1990, 12, 06));
            frends[0] = frend1;
            MyBase frend2 = new MyBase("Сява", "Богров", "Сявкин", new DateTime(1991, 11, 06));
            frends[1] = frend2;
            MyBase frend3 = new MyBase("Тоха", "Бородатый", "Чёрт", new DateTime(1989, 07, 20));
            frends[2] = frend3;
            MyBase frend4 = new MyBase("Андрей", "Белов", "Синяк", new DateTime(1990, 08, 01));
            frends[3] = frend4;
            MyBase frend5 = new MyBase("Рома", "Еремеев", "Бендерович", new DateTime(1995, 07, 13));
            frends[4] = frend5;
            return frends;
        }

        // Вывод на экран список всех друзей
        static void Print(MyBase[] array)
        {
            Console.WriteLine("Днюхи:");
            for (int i = 0; i < array.Length; i++)
                MyBase.Print(array[i]);
        }

        // печать днюх
        static void PrintBirthdays(MyBase[] frends)
        {
            Console.WriteLine("\nСегодня день рождение: ");
            for (int i = 0; i < frends.Length; i++)
                MyBase.ToDeyBirthdays(frends[i]);
            Console.WriteLine("\nБлижайшие дни рождения (20 дней): ");
            for (int i = 0; i < frends.Length; i++)
                MyBase.UpcomingBirthdays(frends[i]);
        }

        // создание друга
        static MyBase CreateFrend()
        {
            Console.Write("Введите имя: ");
            string Name = Console.ReadLine();
            Console.Write("\nВведите фамилию: ");
            string Surname = Console.ReadLine();
            Console.Write("\nВведите фамилию: ");
            string Patronymic = Console.ReadLine();
            Console.Write("\nВведите дату рождения (в формате dd.MM.yyyy) : ");
            string MyDate = Console.ReadLine();
            DateTime date = DateTime.ParseExact(MyDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            MyBase frend = new MyBase(Name,Surname,Patronymic,date);
            return frend;
        }

        //добавление друга
        static MyBase[] AddFrend(MyBase[] frends, MyBase myFrend)
        {
            MyBase[] newfrends = new MyBase[frends.Length + 1];
            for (int i = 0; i < frends.Length; i++)
                newfrends[i] = frends[i];
            newfrends[newfrends.Length - 1] = myFrend;
            return newfrends;
        }

        //удаление друга
        static MyBase[] DeleteFrend(MyBase[] frends)
        {
            Console.Write("\nВведите порядковый номер друга для удаления: ");
            byte indexfr = Convert.ToByte(Console.ReadLine());
            indexfr--;
            MyBase[] newFrends = new MyBase[frends.Length-1];

            for (int i = 0; i < frends.Length; i++)
            {
                if (i < indexfr)
                    newFrends[i] = frends[i];
                if (i == indexfr)
                    i++;
                if (i > indexfr && i!=frends.Length)
                    newFrends[i - 1] = frends[i];
            }

            return newFrends;
        }

        //корректируем друга
        static MyBase[] FixFrend(ref MyBase[] frends)
        {
            Console.Write("\nВведите порядковый номер друга которого нужно исправить: ");
            byte indexfr = Convert.ToByte(Console.ReadLine());
            indexfr--;
            frends[indexfr] = CreateFrend();
            return frends;
        }
        static void Main(string[] args)
        {
            //первый вывод таблицы
            MyBase[] frends = MyFrends();
            Console.WriteLine("Сегодня: "+ DateTime.Now.ToString("d"));
            Print(frends);
            PrintBirthdays(frends);
            ConsoleKey key;
            bool bl = true;
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
                        frends = AddFrend(frends, fr);
                        Print(frends);
                        PrintBirthdays(frends);
                        break;
                    case ConsoleKey.D2:
                        //удаляем друга
                        frends = DeleteFrend(frends);
                        Console.Clear();
                        Print(frends);
                        PrintBirthdays(frends);
                        break;
                    case ConsoleKey.D3:
                        //редактируем друга
                        Console.WriteLine("\nРедактируем приятеля: ");
                        FixFrend(ref frends);
                        Console.Clear();
                        Print(frends);
                        PrintBirthdays(frends);
                        break;
                    case ConsoleKey.Escape:
                        bl = false;
                        break;
                }
            }
            while (bl);
        }
    }
}
