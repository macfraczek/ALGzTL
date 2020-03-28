using System;

namespace ALGzTL.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string log)
        {
            Console.WriteLine(log);
        }

        public void Error(string log)
        {
            Console.WriteLine("ERROR." + log);
        }
    }
}
