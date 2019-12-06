using System;

namespace AlarmCLI
{
    class Program
    {

        public static void Main()
        {
            System.Timers.Timer secTimer = new System.Timers.Timer();
            secTimer.Interval = 1000;
            secTimer.Elapsed += GiveTime;
            secTimer.Enabled = true;
            Console.ReadLine();
        }

        private static void GiveTime(object source, System.Timers.ElapsedEventArgs e)
        {
            DateTime DateTimeNow = DateTime.Now;
            Console.Clear();
            Console.WriteLine("The time is: " + DateTimeNow.ToString("h:mm:ss tt"));
        } 
    }
}
