using System;
namespace Class1
{
    public class Airline
    {
        public Airline()
        {
            Console.WriteLine("");
        }
        public static void Show_that_it_ready(string str)
        {
            Console.WriteLine("You are read this text from file and this methods take parameter: " + str);
        }
        public string Destination;
        public string Type_Plane;
        public string flight_number;
        public string minute;
        public string hour;
        public string seconds;
        public string day;
        public string month;
        public string years;
        public string weekDay;
        public string[] weekDays = new string[] { "Mon", "Tues", "Wed", "Thut", "Frid", "Sat", "Sund" };
        public int[] Day_month = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        DateTime dt1 = new DateTime();
        public string Destination_
        {
            get
            {
                return Destination;
            }
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
                else
                    Destination = value;
            }
        }
        ///////////////////////////
        public string Type_Plane_
        {
            get
            {
                return Type_Plane;
            }
            set
            {
                if (value == "" && fail == 0)
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
                else
                    Type_Plane = value;
            }
        }
        ///////////////////////////
        public string flight_number_
        {
            get
            {
                return flight_number;
            }
            set
            {
                if (int.Parse(value) >= Int32.MaxValue)
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
                else
                    flight_number = value;
            }
        }
        ///////////////////////////
        public string minute_
        {
            get
            {
                return minute;
            }
            set
            {
                if (60 > Convert.ToInt32(value) && fail == 0)
                {
                    minute = value;
                }
                else
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
            }
        }
        ///////////////////////////
        public string hour_
        {
            get
            {
                return hour;
            }
            set
            {
                if (24 > Convert.ToInt32(value))
                {
                    hour = value;
                }
                else
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
            }
        }
        public string day_
        {
            get
            {
                return day;
            }
            set
            {
                int month = int.Parse(this.month);
                if (int.Parse(value) < 32 && Day_month[month - 1] > int.Parse(value))
                {
                    day = value;
                }
                else
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
            }
        }
        ///////////////////////////
        public string month_
        {
            get
            {
                return month;
            }
            set
            {
                if (int.Parse(value) < 13)
                {
                    month = value;
                }
                else
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
            }
        }
        ///////////////////////////
        public string years_
        {
            get
            {
                return years;
            }
            set
            {
                int year = Convert.ToInt32(time_Now.ToString("yyyy"));
                if (year > Convert.ToInt32(value))
                {
                    years = value;
                }
                else
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
            }
        }
        // not fact
        ///////////////////////////
        ///////////////////////////
        public string weekDay_
        {
            get
            {
                return weekDay;
            }
            set
            {
                for (int i = 0; i < 7; i++)
                {
                    if (value != weekDays[i] && fail == 0)
                    {
                        Console.WriteLine("Error cant be written");
                        fail++;
                    }
                    else
                    {
                        weekDay = value;
                        break;
                    }
                }
            }
        }
        ///////////////////////////
        public int fail = 0;
        public DateTime time_Now = DateTime.Now;
        ///////////////////////////
        public string seconds_
        {
            get
            {
                return seconds;
            }
            set
            {
                if (int.Parse(value) < 61)
                {
                    seconds = value;
                }
                else
                {
                    Console.WriteLine("Error cant be written");
                    fail++;
                }
            }
        }
    }
    ///////////////////////////
    class Class
    {
        static void day(string string_1, Airline[] array_airline, int j)
        {
            for (int i = 0; i < j; i++)
            {
                if (array_airline[i].weekDay == string_1)
                {
                    Console.WriteLine("Destination:" + array_airline[i].Destination);
                    Console.WriteLine("Type plane: " + array_airline[i].Type_Plane);
                    Console.WriteLine("flight number" + array_airline[i].flight_number);
                    Console.WriteLine("Week day" + array_airline[i].weekDay);
                    Console.WriteLine("Plane arrive:" + array_airline[i].years + "." + array_airline[i].month + "." + array_airline[i].day + " time: " + array_airline[i].hour + ":" + array_airline[i].minute + ":" + array_airline[i].seconds);
                    Console.WriteLine();
                }
            }
        }
        static void day_week(string string_, Airline[] array_airline, int j)
        {
            for (int i = 0; i < j; i++)
            {
                if (array_airline[i].Destination == string_)
                {
                    Console.WriteLine("Destination:" + array_airline[i].Destination);
                    Console.WriteLine("Type plane: " + array_airline[i].Type_Plane);
                    Console.WriteLine("flight number" + array_airline[i].flight_number);
                    Console.WriteLine("Week day" + array_airline[i].weekDay);
                    Console.WriteLine("data time: " + array_airline[i].time_Now);
                    Console.WriteLine("Plane arrive:" + array_airline[i].years + "." + array_airline[i].month + "." + array_airline[i].day + " time: " + array_airline[i].hour + ":" + array_airline[i].minute + ":" + array_airline[i].seconds);
                    Console.WriteLine();
                }
            }
        }
        static void Cout(Airline[] array_airline, int j)
        {
            for (int i = 0; i < j; i++)
            {
                if (array_airline[i].fail == 0)
                {
                    Console.WriteLine("Destination:" + array_airline[i].Destination);
                    Console.WriteLine("Type plane: " + array_airline[i].Type_Plane);
                    Console.WriteLine("flight number" + array_airline[i].flight_number);
                    Console.WriteLine("Week day" + array_airline[i].weekDay);
                    Console.WriteLine("data time now: " + array_airline[i].time_Now);
                    Console.WriteLine("Plane arrive:" + array_airline[i].years + "." + array_airline[i].month + "." + array_airline[i].day + " time: " + array_airline[i].hour + ":" + array_airline[i].minute + ":" + array_airline[i].seconds);
                    Console.WriteLine();
                }
            }
        }
        static void add(Airline[] array_airline, int i, int j)
        {
            if (j == i - 1)
            {
                Array.Resize(ref array_airline, i + 1);
                i++;
            }
            Console.Write("Enter destination: ");
            array_airline[j].Destination_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }
            Console.Write("Enter flight number: ");
            array_airline[j].flight_number_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }
            Console.Write("Enter type plane: ");
            array_airline[j].Type_Plane_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }
            Console.Write("Enter minute arrive: ");
            array_airline[j].minute_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }
            Console.Write("Enter hour arrive: ");
            array_airline[j].hour_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }
            Console.Write("Enter month arrive: ");
            array_airline[j].month_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }
            Console.Write("Enter day arrive: ");
            array_airline[j].day_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }

            Console.Write("Enter years arrive: ");
            array_airline[j].years_ = Console.ReadLine();

            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                return;
            }
            Console.Write("Enter week day: ");
            array_airline[j].weekDay_ = Console.ReadLine();
            if (array_airline[j].fail > 0)
            {
                Console.WriteLine("Error written");
                array_airline[j].fail = 0;
            }
            else
            {
                array_airline[j].fail = 0;
                j += 1;
            }
        }
        //////////////////////////////////////////
    }
}