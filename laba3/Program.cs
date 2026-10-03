using System;

namespace Lab3
{
    class Program
    {
        static int ReadIntNumber()
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

        static double ReadDoubleNumber()
        {
            double number;
            bool isCorrect;

            do
            {
                isCorrect = double.TryParse(Console.ReadLine(), out number);
                if (!isCorrect)
                {
                    Console.WriteLine("ошибка: нужно ввести число");
                }
            } while (!isCorrect);

            return number;
        }

        static double GetElement(double x, int i, int sign)
        {
            return sign * Math.Cos(i * x) / Math.Pow(i, 2);
        }

        static double GetSumN(double x, int n)
        {
            double sum = 0;
            int sign = 1;
            for (int i = 1; i <= n; i++)
            {
                sign = -sign;
                sum += GetElement(x, i, sign);
            }

            return sum;
        }

        static double GetSumE(double x, double eps)
        {
            double sum = 0;
            int sign = 1;
            double element;
            int i = 0;
            do
            {
                i++;
                sign = -sign;
                element = GetElement(x, i, sign);
                sum += element;
            } while (Math.Abs(element) >= eps);

            return sum;
        }

        static double GetY(double x)
        {
            return (x * x - Math.PI * Math.PI / 3) / 4;
        }

        static void PrintTable(int n, double eps)
        {
            double a = Math.PI / 5;
            double b = Math.PI;
            int k = 10;
            double step = (b - a) / k;
            Console.WriteLine("Вычисление функции");
            for (int i=0; i <= k; i++)
            {
                double x = a+i*step;
                double sn = GetSumN(x,n);
                double se = GetSumE(x,eps);
                double y = GetY(x);
                Console.WriteLine("X={0:F4} SN={1:F6} SE={2:F6} Y={3:F6}",x,sn,se,y);
            }
        }

        static void Main()
        {
            Console.WriteLine("введите число слагаемых n");
            int n = ReadIntNumber();
            if (n<=0)
            {
                Console.WriteLine("ошибка: n должно быть больше 0");
                return;
            }
            Console.WriteLine("введите точность eps");
            double eps = ReadDoubleNumber();
            if (eps<=0)
            {
                Console.WriteLine("ошибка: eps должно быть больше 0");
                return;
            }
            PrintTable(n,eps);
        }
    }
}
