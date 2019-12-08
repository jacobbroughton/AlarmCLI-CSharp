using System;

namespace AlarmCLI
{
    class Program
    {

        public static void Main()
        {
            SetAlarm();
        }

        public static void TimerLoop(System.Timers.ElapsedEventHandler timeThis, System.Timers.ElapsedEventHandler timeThat)
        {
            System.Timers.Timer secTimer = new System.Timers.Timer();
            secTimer.Interval = 1000;
            secTimer.Elapsed += timeThis;
            secTimer.Elapsed += timeThat;
            secTimer.Enabled = true;
            Console.ReadLine();
        }

        private static void GiveTime(object source, System.Timers.ElapsedEventArgs e)
        {
            DateTime DateTimeNow = DateTime.Now;
            Console.Clear();
            Console.WriteLine(DateTimeNow.ToString("h:mm:ss tt"));
            Console.WriteLine(DateTimeNow.ToString("D"));
        }

        public static void SetAlarm()
        {
            Console.Write("Would you like to set an alarm? (yes/no)... ");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo == "yes")
            {
                Console.Write("Set hour: ");
                string hourStr = Console.ReadLine();
                Console.Write("Set minute: ");
                string minStr = Console.ReadLine();
                Console.Write("AM or PM? ");
                string amOrPmLower = Console.ReadLine();
                string amOrPm = amOrPmLower.ToUpper();
                if(hourStr != null && minStr != null && amOrPm != null)
                {
                    string alarmTime = hourStr + ":" + minStr + " " + amOrPm;
                    Console.WriteLine("Your alarm has been set to {0}", alarmTime);


                    void checkTime(object source, System.Timers.ElapsedEventArgs e)
                    {
                        DateTime timeNow = DateTime.Now;
                        string timeNowStr = timeNow.ToString("h:mm tt");

                        if (timeNowStr == alarmTime)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        } else
                        {
                            Console.ResetColor();
                        }
                    }
                    TimerLoop(checkTime, GiveTime);


                } else
                {
                    Console.Write("Please try again.");
                    TimerLoop(GiveTime, null);
                }

            }
            else
            {
                TimerLoop(GiveTime, null);
            }
        }
    }
}
