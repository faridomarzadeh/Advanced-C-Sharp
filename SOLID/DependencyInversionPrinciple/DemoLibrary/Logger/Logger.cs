using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Logger
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"write to Console: {message}");
        }

    }
}
