using System;

namespace Lab9
{
    public class Dialog
    {
        private const int MaxSize = 10;
        // ограничения, чтобы при переводе времени в минуты не было переполнения int
        private const int MaxHours = 1000;
        private const int MaxMinutes = 60000;

        public static int ReadIntNumber()
        {
            int number;
            bool isCorrect;

            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrect)
                {
                    Console.WriteLine("ошибка: нужно ввести целое число");
                }
            } while (!isCorrect);

            return number;
        }

        public static int ReadNumber(int min, int max, string error)
        {
            int number = ReadIntNumber();
            while (number < min || number > max)
            {
                Console.WriteLine("ошибка: {0}, введите число от {1} до {2}", error, min, max);
                number = ReadIntNumber();
            }

            return number;
        }

        public static int ReadChoice(int maxChoice)
        {
            return ReadNumber(1, maxChoice, "такого пункта нет");
        }

        public static int OpenMenu()
        {
            Console.WriteLine();
            Console.WriteLine("МЕНЮ");
            Console.WriteLine("1 - часть 1: класс Time");
            Console.WriteLine("2 - часть 2: операции с Time");
            Console.WriteLine("3 - часть 3: массив TimeArray");
            Console.WriteLine("4 - выход");

            return ReadChoice(4);
        }

        public static int SelectArrayAction()
        {
            Console.WriteLine();
            Console.WriteLine("МАССИВ");
            Console.WriteLine("1 - создать массив");
            Console.WriteLine("2 - напечатать массив");
            Console.WriteLine("3 - найти номер максимального элемента");
            Console.WriteLine("4 - показать элемент по номеру");
            Console.WriteLine("5 - изменить элемент по номеру");
            Console.WriteLine("6 - назад");

            return ReadChoice(6);
        }

        public static int SelectCreateWay()
        {
            Console.WriteLine("1 - пустой массив");
            Console.WriteLine("2 - заполнить случайными значениями");
            Console.WriteLine("3 - заполнить вручную");

            return ReadChoice(3);
        }

        public static int ReadLength()
        {
            Console.WriteLine("введите длину массива (от 1 до {0})", MaxSize);

            return ReadNumber(1, MaxSize, "неверная длина");
        }

        public static int ReadElementNumber()
        {
            Console.WriteLine("введите номер элемента");

            return ReadIntNumber();
        }

        public static int ReadMinutes()
        {
            Console.WriteLine("введите количество минут (от 0 до {0})", MaxMinutes);

            return ReadNumber(0, MaxMinutes, "неверное количество минут");
        }

        public static Time ReadTime(string name)
        {
            Console.WriteLine("введите часы для {0} (от 0 до {1})", name, MaxHours);
            int hours = ReadNumber(0, MaxHours, "неверные часы");
            Console.WriteLine("введите минуты для {0} (от 0 до 59)", name);
            int minutes = ReadNumber(0, 59, "неверные минуты");

            return new Time(hours, minutes);
        }

        public static Time[] ReadTimes(int length)
        {
            Time[] times = new Time[length];
            for (int i = 0; i < length; i++)
            {
                times[i] = ReadTime("элемента " + (i + 1));
            }

            return times;
        }

        public static void ShowTime(string text, Time time)
        {
            Console.Write(text + " = ");
            time.Show();
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowMaxIndex(int maxIndex)
        {
            if (maxIndex == -1)
            {
                Console.WriteLine("ошибка: массив пустой");
                return;
            }

            Console.WriteLine("номер максимального элемента: {0}", maxIndex + 1);
        }

        public static void ShowCount()
        {
            Console.WriteLine("создано объектов Time: {0}", Time.Count);
            Console.WriteLine("создано объектов TimeArray: {0}", TimeArray.Count);
        }
    }
}