using System;

namespace Lab9
{
    public class TimeArray
    {
        private Time[] arr;
        private static int count = 0;

        public int Length => arr.Length;

        public static int Count => count;

        public TimeArray()
        {
            arr = new Time[0];
            count++;
        }

        public TimeArray(int length)
        {
            arr = new Time[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = new Time(random.Next(0, 24), random.Next(0, 60));
            }
            count++;
        }

        public TimeArray(Time[] times)
        {
            arr = new Time[times.Length];
            for (int i = 0; i < times.Length; i++)
            {
                arr[i] = times[i];
            }
            count++;
        }

        public Time this[int index]
        {
            get
            {
                CheckIndex(index);
                return arr[index];
            }
            set
            {
                CheckIndex(index);
                arr[index] = value;
            }
        }

        public void Show()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("массив пустой");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}) ", i + 1);
                arr[i].Show();
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new ArgumentException("выход за границы массива");
            }
        }
    }
}