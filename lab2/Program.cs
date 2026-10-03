using System;

namespace Lab2
{
    class Program
    {
        static int ReadIntNumber()
        {
            int number;
            bool isCorrect;

            do {
                isCorrect = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrect)
                {
                    Console.WriteLine("ошибка: нужно ввести целое число");
                }
            } while (!isCorrect);

            return number;
        }

        static int GetDigitSum(int k)
        {
            int sum = 0;
            while (k != 0) {
                int digit = Math.Abs(k % 10);
                sum += digit;
                k /= 10;
            }

            return sum;
        }

        static void RunTask1()
        {
            Console.WriteLine("ЗАДАНИЕ 1");
            int count = 0;
            Console.WriteLine("введите число K");
            int k = ReadIntNumber();
            if (k == 0)
            {
                Console.WriteLine("ошибка: K не может быть равно 0");
                return;
            }
            Console.WriteLine("сколько чисел в последовательности?");
            int n = ReadIntNumber();
            if (n <= 0)
            {
                Console.WriteLine("ошибка: n должно быть больше нуля");
                return;
            }
            Console.WriteLine("введите числа, каждое с новой строки");
            for (int i = 1; i <= n; i++)
            {
                int a = ReadIntNumber();
                if (a % k == 0)
                {
                    count += 1;
                }
            }
            Console.WriteLine("в последовательности {0} чисел кратных {1}", count, k);
        }

        static void RunTask2()
        {
            Console.WriteLine();
            Console.WriteLine("ЗАДАНИЕ 2");
            Console.WriteLine("введите последовательность, 0 = конец");
            int sum = 0;
            int a;
            do
            {
                a = ReadIntNumber();
                if (a % 2 != 0)
                {
                    sum += a;
                }
            } while (a != 0);
            Console.WriteLine("сумма нечетных элементов равна {0}", sum);
        }

        static void RunTask3()
        {
            Console.WriteLine();
            Console.WriteLine("ЗАДАНИЕ 3");
            Console.WriteLine("введите число k");
            int k = ReadIntNumber();
            int sum = GetDigitSum(k);
            Console.WriteLine("сумма цифр равна {0}", sum);
        }

        static void Main()
        {
            RunTask1();
            RunTask2();
            RunTask3();
        }
    }
}