using System;
using System.Text.RegularExpressions;

namespace Lab5
{
    class Program
    {
        const int MaxSize = 10;

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

        static int ReadChoice(int maxChoice, string error = "такого пункта нет")
        {
            int choice = ReadIntNumber();
            while (choice < 1 || choice > maxChoice)
            {
                Console.WriteLine("ошибка: {0}, введите число от 1 до {1}", error, maxChoice);
                choice = ReadIntNumber();
            }

            return choice;
        }

        static int OpenMenu()
        {
            Console.WriteLine();
            Console.WriteLine("МЕНЮ");
            Console.WriteLine("1 - двумерный массив");
            Console.WriteLine("2 - рваный массив");
            Console.WriteLine("3 - строка");
            Console.WriteLine("4 - выход");

            return ReadChoice(4);
        }

        static int SelectMatrixAction()
        {
            Console.WriteLine();
            Console.WriteLine("ДВУМЕРНЫЙ МАССИВ");
            Console.WriteLine("1 - создать массив");
            Console.WriteLine("2 - напечатать массив");
            Console.WriteLine("3 - удалить столбцы с K1 по K2");
            Console.WriteLine("4 - назад");

            return ReadChoice(4);
        }

        static int SelectJaggedAction()
        {
            Console.WriteLine();
            Console.WriteLine("РВАНЫЙ МАССИВ");
            Console.WriteLine("1 - создать массив");
            Console.WriteLine("2 - напечатать массив");
            Console.WriteLine("3 - добавить строку в начало");
            Console.WriteLine("4 - назад");

            return ReadChoice(4);
        }

        static int SelectStringAction()
        {
            Console.WriteLine();
            Console.WriteLine("СТРОКА");
            Console.WriteLine("1 - ввести строку с клавиатуры");
            Console.WriteLine("2 - выбрать готовую строку");
            Console.WriteLine("3 - напечатать строку");
            Console.WriteLine("4 - обработать строку");
            Console.WriteLine("5 - назад");

            return ReadChoice(5);
        }

        static int SelectFillWay()
        {
            Console.WriteLine("1 - заполнить вручную");
            Console.WriteLine("2 - заполнить случайными числами");

            return ReadChoice(2);
        }

        static int[,] CreateMatrix()
        {
            Console.WriteLine("введите количество строк (от 1 до {0})", MaxSize);
            int rows = ReadChoice(MaxSize, "неверное количество");
            Console.WriteLine("введите количество столбцов (от 1 до {0})", MaxSize);
            int columns = ReadChoice(MaxSize, "неверное количество");
            int way = SelectFillWay();

            int[,] matrix = new int[rows, columns];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                if (way == 1)
                {
                    Console.WriteLine("строка {0}: введите числа, каждое с новой строки", i + 1);
                }
                for (int j = 0; j < columns; j++)
                {
                    if (way == 1)
                    {
                        matrix[i, j] = ReadIntNumber();
                    }
                    else
                    {
                        matrix[i, j] = random.Next(0, 100);
                    }
                }
            }

            return matrix;
        }

        static void PrintArray(int[,] matrix)
        {
            if (matrix == null)
            {
                Console.WriteLine("массив пустой");
                return;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static int[,] DeleteColumns(int[,] matrix, int k1, int k2)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int newColumns = columns - (k2 - k1 + 1);
            if (newColumns == 0)
            {
                return null;
            }

            int[,] newMatrix = new int[rows, newColumns];
            for (int i = 0; i < rows; i++)
            {
                int newJ = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (j < k1 - 1 || j > k2 - 1)
                    {
                        newMatrix[i, newJ] = matrix[i, j];
                        newJ++;
                    }
                }
            }

            return newMatrix;
        }

        static int[] CreateRow(int length, int way)
        {
            int[] row = new int[length];
            Random random = new Random();
            if (way == 1)
            {
                Console.WriteLine("введите числа строки, каждое с новой строки");
            }
            for (int j = 0; j < length; j++)
            {
                if (way == 1)
                {
                    row[j] = ReadIntNumber();
                }
                else
                {
                    row[j] = random.Next(0, 100);
                }
            }

            return row;
        }

        static int[][] CreateJagged()
        {
            Console.WriteLine("введите количество строк (от 1 до {0})", MaxSize);
            int rows = ReadChoice(MaxSize, "неверное количество");
            int way = SelectFillWay();

            int[][] jagged = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("введите длину строки {0} (от 1 до {1})", i + 1, MaxSize);
                int length = ReadChoice(MaxSize, "неверная длина");
                jagged[i] = CreateRow(length, way);
            }

            return jagged;
        }

        static void PrintArray(int[][] jagged)
        {
            if (jagged == null)
            {
                Console.WriteLine("массив пустой");
                return;
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write("{0,4}", jagged[i][j]);
                }
                Console.WriteLine();
            }
        }

        static void AddFirstRow(ref int[][] jagged, int[] newRow)
        {
            int[][] newJagged = new int[jagged.Length + 1][];
            newJagged[0] = newRow;
            for (int i = 0; i < jagged.Length; i++)
            {
                newJagged[i + 1] = jagged[i];
            }
            jagged = newJagged;
        }

        static string ReadText()
        {
            Console.WriteLine("введите строку, в конце каждого предложения . ! или ?");
            string text;
            bool isCorrect;

            do
            {
                text = Console.ReadLine().Trim();
                isCorrect = text.EndsWith(".") || text.EndsWith("!") || text.EndsWith("?");
                if (!isCorrect)
                {
                    Console.WriteLine("ошибка: строка пустая или в конце нет . ! ?");
                }
            } while (!isCorrect);

            return text;
        }

        static string ChooseTestText(params string[] texts)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, texts[i]);
            }
            int number = ReadChoice(texts.Length);

            return texts[number - 1];
        }

        static string ReverseWord(string word)
        {
            if (word.Length <= 1)
            {
                return word;
            }

            return ReverseWord(word.Substring(1)) + word[0];
        }

        static void SortByLength(string[] words)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = 0; j < words.Length - 1 - i; j++)
                {
                    if (words[j].Length < words[j + 1].Length)
                    {
                        string temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }
        }

        static string ProcessSentence(string sentence)
        {
            char end = sentence[sentence.Length - 1];
            string body = sentence.Substring(0, sentence.Length - 1).Trim();

            string[] words = Regex.Split(body, @"\s+");
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();
                char last = word[word.Length - 1];
                if (last == ',' || last == ';' || last == ':')
                {
                    words[i] = ReverseWord(word.Substring(0, word.Length - 1)) + last;
                }
                else
                {
                    words[i] = ReverseWord(word);
                }
            }

            SortByLength(words);

            string result = string.Join(" ", words);
            result = result.Substring(0, 1).ToUpper() + result.Substring(1);

            return result + end;
        }

        static string ProcessText(string text)
        {
            MatchCollection sentences = Regex.Matches(text, @"[^.!?]+[.!?]");
            string result = "";
            foreach (Match sentence in sentences)
            {
                result = result + ProcessSentence(sentence.Value.Trim()) + " ";
            }

            return result.Trim();
        }

        static void Main()
        {
            int[,] matrix = null;
            int[][] jagged = null;
            string text = null;

            int task = OpenMenu();
            while (task != 4)
            {
                if (task == 1)
                {
                    int action = SelectMatrixAction();
                    while (action != 4)
                    {
                        // 1 - создать 2 - напечатать 3 - удалить столбцы
                        if (action == 1)
                        {
                            matrix = CreateMatrix();
                            PrintArray(matrix);
                        }
                        if (action == 2)
                        {
                            PrintArray(matrix);
                        }
                        if (action == 3)
                        {
                            if (matrix == null)
                            {
                                Console.WriteLine("ошибка: массив пустой, удалять нечего");
                            }
                            else
                            {
                                int columns = matrix.GetLength(1);
                                Console.WriteLine("введите K1 (от 1 до {0})", columns);
                                int k1 = ReadChoice(columns, "нет такого столбца");
                                Console.WriteLine("введите K2 (от 1 до {0})", columns);
                                int k2 = ReadChoice(columns, "нет такого столбца");
                                if (k1 > k2)
                                {
                                    Console.WriteLine("ошибка: K1 не может быть больше K2");
                                }
                                else
                                {
                                    matrix = DeleteColumns(matrix, k1, k2);
                                    PrintArray(matrix);
                                }
                            }
                        }
                        action = SelectMatrixAction();
                    }
                }

                if (task == 2)
                {
                    int action = SelectJaggedAction();
                    while (action != 4)
                    {
                        // 1 - создать 2 - напечатать 3 - добавить строку
                        if (action == 1)
                        {
                            jagged = CreateJagged();
                            PrintArray(jagged);
                        }
                        if (action == 2)
                        {
                            PrintArray(jagged);
                        }
                        if (action == 3)
                        {
                            if (jagged == null)
                            {
                                Console.WriteLine("ошибка: массив пустой, сначала создайте его");
                            }
                            else
                            {
                                Console.WriteLine("введите длину новой строки (от 1 до {0})", MaxSize);
                                int length = ReadChoice(MaxSize, "неверная длина");
                                int way = SelectFillWay();
                                int[] newRow = CreateRow(length, way);
                                AddFirstRow(ref jagged, newRow);
                                PrintArray(jagged);
                            }
                        }
                        action = SelectJaggedAction();
                    }
                }

                if (task == 3)
                {
                    int action = SelectStringAction();
                    while (action != 5)
                    {
                        // 1 - ввести 2 - выбрать готовую 3 - напечатать 4 - обработать
                        if (action == 1)
                        {
                            text = ReadText();
                        }
                        if (action == 2)
                        {
                            text = ChooseTestText("Программировать на C# не сложно.", "Codex плохо пишет код?", "Матрицы бывают разных видов!");
                        }
                        if (action == 3)
                        {
                            if (text == null)
                            {
                                Console.WriteLine("строка пустая");
                            }
                            else
                            {
                                Console.WriteLine(text);
                            }
                        }
                        if (action == 4)
                        {
                            if (text == null)
                            {
                                Console.WriteLine("ошибка: строка пустая, сначала введите или выберите строку");
                            }
                            else
                            {
                                Console.WriteLine("результат:");
                                Console.WriteLine(ProcessText(text));
                            }
                        }
                        action = SelectStringAction();
                    }
                }

                task = OpenMenu();
            }
        }
    }
}