using System;
using  System.Timers;

namespace Timer
{
    class Program
    {
        private const int UpdateInterval= 3;
        private static DateTime _endTime;
        static void Main(string[] args)
        {

            Console.WriteLine("Please input amount of minutes");
            string input = Console.ReadLine();


            if (input.Length==0)
                Console.WriteLine("Please provide amount of time");

            int minutes;

            if (!int.TryParse(input, out minutes))
                Console.WriteLine("Please input only numbers");
            else
                StartTimer(minutes);

        }

        private static void StartTimer(int minutes)
        {
            _endTime = DateTime.Now.AddMinutes(minutes); 

            System.Timers.Timer timer = new System.Timers.Timer(UpdateInterval*1000);
            timer.Elapsed += OnTimerTick;
            timer.Start();
            Console.Read();

        }

        private static void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            TimeSpan interval = _endTime-DateTime.Now;
            Console.WriteLine($"Time Left {Math.Round(interval.TotalMinutes)}:{interval.Seconds}");
            if (interval.Minutes < 0)
            {
                Environment.Exit(0);

            }

        }
    }
}
