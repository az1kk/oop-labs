using System;

namespace Lab9
{
    public class Program
    {
        public static Time SubtractMinutes(Time time, int minutesToSubtract)
        {
            // переводим время в минуты, вычитаем и переводим обратно в часы и минуты
            int total = time.Hours * 60 + time.Minutes - minutesToSubtract;
            if (total < 0)
            {
                total = 0;
            }

            return new Time(total / 60, total % 60);
        }

        public static int FindMaxIndex(TimeArray times)
        {
            // для пустого массива номера нет
            if (times.Length == 0)
            {
                return -1;
            }

            int maxIndex = 0;
            for (int i = 1; i < times.Length; i++)
            {
                if (times[i] > times[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static void Main()
        {
            TimeArray? times = null;

            int part = Dialog.OpenMenu();
            while (part != 4)
            {
                if (part == 1)
                {
                    Time time1 = new Time();
                    Dialog.ShowTime("new Time()", time1);
                    Time time2 = Dialog.ReadTime("t");
                    Dialog.ShowTime("t", time2);
                    int minutes = Dialog.ReadMinutes();
                    Time staticResult = SubtractMinutes(time2, minutes);
                    Time methodResult = time2.SubtractMinutes(minutes);
                    Dialog.ShowTime("SubtractMinutes(t, " + minutes + ")", staticResult);
                    Dialog.ShowTime("t.SubtractMinutes(" + minutes + ")", methodResult);
                    Dialog.ShowCount();
                }

                if (part == 2)
                {
                    Time time1 = Dialog.ReadTime("t1");
                    Time time2 = Dialog.ReadTime("t2");
                    Dialog.ShowTime("t1", time1);
                    Dialog.ShowTime("t2", time2);
                    int minutes = Dialog.ReadMinutes();
                    Dialog.ShowTime("t1 + " + minutes, time1 + minutes);
                    Dialog.ShowTime(minutes + " + t1", minutes + time1);
                    Dialog.ShowTime("t1 + t2", time1 + time2);
                    Dialog.ShowMessage("явное приведение к int: " + (int)time1);
                    bool isNotZero = time1;
                    Dialog.ShowMessage("неявное приведение к bool: " + isNotZero);
                    Dialog.ShowTime("--t1", --time1);
                    Dialog.ShowCount();
                }

                if (part == 3)
                {
                    int action = Dialog.SelectArrayAction();
                    while (action != 6)
                    {
                        // 1 - создать 2 - печать 3 - максимум 4 - показать 5 - изменить
                        if (action == 1)
                        {
                            int way = Dialog.SelectCreateWay();
                            if (way == 1)
                            {
                                times = new TimeArray();
                            }
                            else
                            {
                                int length = Dialog.ReadLength();
                                if (way == 2)
                                {
                                    times = new TimeArray(length);
                                }
                                else
                                {
                                    times = new TimeArray(Dialog.ReadTimes(length));
                                }
                            }
                            times.Show();
                            Dialog.ShowCount();
                        }
                        if (action == 2)
                        {
                            if (times == null)
                            {
                                Dialog.ShowMessage("массив еще не создан");
                            }
                            else
                            {
                                times.Show();
                            }
                        }
                        if (action == 3)
                        {
                            if (times == null)
                            {
                                Dialog.ShowMessage("ошибка: массив еще не создан");
                            }
                            else
                            {
                                Dialog.ShowMaxIndex(FindMaxIndex(times));
                            }
                        }
                        if (action == 4)
                        {
                            if (times == null)
                            {
                                Dialog.ShowMessage("ошибка: массив еще не создан");
                            }
                            else
                            {
                                int number = Dialog.ReadElementNumber();
                                try
                                {
                                    Dialog.ShowTime("элемент " + number, times[number - 1]);
                                }
                                catch (ArgumentException e)
                                {
                                    Dialog.ShowMessage("ошибка: " + e.Message);
                                }
                            }
                        }
                        if (action == 5)
                        {
                            if (times == null)
                            {
                                Dialog.ShowMessage("ошибка: массив еще не создан");
                            }
                            else
                            {
                                int number = Dialog.ReadElementNumber();
                                Time newTime = Dialog.ReadTime("нового элемента");
                                try
                                {
                                    times[number - 1] = newTime;
                                    times.Show();
                                }
                                catch (ArgumentException e)
                                {
                                    Dialog.ShowMessage("ошибка: " + e.Message);
                                }
                            }
                        }
                        action = Dialog.SelectArrayAction();
                    }
                }

                part = Dialog.OpenMenu();
            }
        }
    }
}