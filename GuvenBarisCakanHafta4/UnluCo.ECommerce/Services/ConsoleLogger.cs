using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.ECommerce.Services
{
    //Console 'a loglama yapılabilmesi için yazılmıştır.
    public class ConsoleLogger : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"[ConsoleLogger] - {message}");
        }
    }
}
