using System;

namespace Lab9
{
    public class Time
    {
        private int hours;
        private int minutes;
        private static int count = 0;

        public int Hours
        {
            get { return hours; }
            set
            {
                // часов не может быть меньше 0, а больше 23 можно: время - это интервал
                if (value < 0)
                {
                    hours = 0;
                }
                else
                {
                    hours = value;
                }
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value > 59)
                {
                    minutes = 0;
                }
                else
                {
                    minutes = value;
                }
            }
        }

        public static int Count => count;

        public Time()
        {
            Hours = 0;
            Minutes = 0;
            count++;
        }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            count++;
        }

        public void Show()
        {
            Console.WriteLine("{0}:{1:D2}", hours, minutes);
        }

        public Time SubtractMinutes(int minutesToSubtract)
        {
            return CreateFromMinutes(GetTotalMinutes() - minutesToSubtract);
        }

        public static Time operator --(Time time)
        {
            return time.SubtractMinutes(1);
        }

        public static explicit operator int(Time time)
        {
            return time.hours;
        }

        // по варианту true, если часы не равны нулю
        public static implicit operator bool(Time time)
        {
            return time.hours != 0;
        }

        public static Time operator +(Time time, int minutesToAdd)
        {
            return CreateFromMinutes(time.GetTotalMinutes() + minutesToAdd);
        }

        public static Time operator +(int minutesToAdd, Time time)
        {
            return time + minutesToAdd;
        }

        public static Time operator +(Time time1, Time time2)
        {
            return time1 + time2.GetTotalMinutes();
        }

        // время сравнивается по общему количеству минут
        public static bool operator >(Time time1, Time time2)
        {
            return time1.GetTotalMinutes() > time2.GetTotalMinutes();
        }

        public static bool operator <(Time time1, Time time2)
        {
            return time1.GetTotalMinutes() < time2.GetTotalMinutes();
        }

        private int GetTotalMinutes()
        {
            return hours * 60 + minutes;
        }

        // переводит минуты обратно в часы и минуты, меньше 0:00 время быть не может
        private static Time CreateFromMinutes(int totalMinutes)
        {
            if (totalMinutes < 0)
            {
                totalMinutes = 0;
            }

            return new Time(totalMinutes / 60, totalMinutes % 60);
        }
    }
}