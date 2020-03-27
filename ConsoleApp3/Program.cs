using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDate = GetWorkingDate();
            workingDate -= 9;
            var dateTime = DateTime.Parse("2020/03/07 01:18:00");
            var localTime = dateTime.ToUniversalTime();
            var addHours = localTime.AddHours(-4);
            Console.WriteLine(workingDate);
            Console.ReadKey();
        }

        public static int GetWorkingDate()
        {
            var now = DateTime.Now;
            //now = DateTime.Parse("2020/03/09 11:59:59");
            if (now.Hour < 12)
            {
                now = now.AddDays(-1);
            }

            if (int.TryParse(now.ToString("yyyyMMdd"), out var workingDate))
            {
                return workingDate;
            }

            return now.Year * 10000 + now.Month * 100 + now.Day;
        }
    }
}