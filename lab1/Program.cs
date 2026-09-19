using System;

namespace Lab1
{
    class Program
    {
        static int ReadIntNumber(string name)
        {
            int number;
            bool isCorrect;
            do
            {
                Console.Write("введите {0}: ", name);
                isCorrect = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrect)
                    Console.WriteLine("ошибка: {0} должно быть целым числом", name);
            } while (!isCorrect);
            return number;
        }

        static double ReadDoubleNumber(string name)
        {
            double number;
            bool isCorrect;
            do
            {
                Console.Write("введите {0}: ", name);
                isCorrect = double.TryParse(Console.ReadLine(), out number);
                if (!isCorrect)
                    Console.WriteLine("ошибка: {0} должно быть числом", name);
            } while (!isCorrect);
            return number;
        }

        static double CalculateFunction(double x)
        {
            return Math.Pow(Math.Abs(x + 1), 1.0 / 4) + 1 / Math.Pow(x, 2);
        }

        static void RunTask1()
        {
            Console.WriteLine("Задача 1");
            int n = ReadIntNumber("n");
            int m = ReadIntNumber("m");
            double x = ReadDoubleNumber("x");

            int product = n++ * --m;
            Console.WriteLine("n++ * --m = {0}, n = {1}, m = {2}", product, n, m);
            bool isNLess = n-- < m++;
            Console.WriteLine("n-- < m++ = {0}, n = {1}, m = {2}", isNLess, n, m);
            bool isNGreater = --n > --m;
            Console.WriteLine("--n > --m = {0}, n = {1}, m = {2}", isNGreater, n, m);

            if (x == 0)
                Console.WriteLine("ошибка: при x = 0 выражение вычислить нельзя, деление на ноль");
            else
                Console.WriteLine("f({0}) = {1}", x, CalculateFunction(x));
        }

        static void RunTask2()
        {
            Console.WriteLine("Задача 2");
            double x1 = ReadDoubleNumber("x1");
            double y1 = ReadDoubleNumber("y1");

            bool isInArea = (x1 * y1 >= 0 && Math.Abs(x1) + Math.Abs(y1) <= 1)
                || (x1 * y1 < 0 && x1 * x1 + y1 * y1 <= 1);

            Console.WriteLine("точка ({0}; {1}) принадлежит области: {2}", x1, y1, isInArea);
        }

        static void RunTask3()
        {
            Console.WriteLine("Задача 3");
            double aDouble = 1000;
            double bDouble = 0.0001;
            float aFloat = 1000f;
            float bFloat = 0.0001f;

            double sumDouble = Math.Pow(aDouble + bDouble, 4);
            double partDouble = Math.Pow(aDouble, 4) + 6 * aDouble * aDouble * bDouble * bDouble + Math.Pow(bDouble, 4);
            double numeratorDouble = sumDouble - partDouble;
            double denominatorDouble = 4 * aDouble * Math.Pow(bDouble, 3) + 4 * Math.Pow(aDouble, 3) * bDouble;
            double resultDouble = numeratorDouble / denominatorDouble;

            float sumFloat = (float)Math.Pow(aFloat + bFloat, 4);
            float partFloat = (float)Math.Pow(aFloat, 4) + 6 * aFloat * aFloat * bFloat * bFloat + (float)Math.Pow(bFloat, 4);
            float numeratorFloat = sumFloat - partFloat;
            float denominatorFloat = 4 * aFloat * (float)Math.Pow(bFloat, 3) + 4 * (float)Math.Pow(aFloat, 3) * bFloat;
            float resultFloat = numeratorFloat / denominatorFloat;

            Console.WriteLine("double: числитель = {0}, знаменатель = {1}", numeratorDouble, denominatorDouble);
            Console.WriteLine("double: результат = {0}", resultDouble);
            Console.WriteLine("float: числитель = {0}, знаменатель = {1}", numeratorFloat, denominatorFloat);
            Console.WriteLine("float: результат = {0}", resultFloat);
        }

        static void Main(string[] args)
        {
            RunTask1();
            Console.WriteLine();
            RunTask2();
            Console.WriteLine();
            RunTask3();
        }
    }
}
