using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMIDUDTRACE
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLogTraceListener logTrace = new EventLogTraceListener("MyTrace");
            Trace.Listeners.Add(logTrace);
            Trace.Listeners.Add(new ConsoleTraceListener());

            Trace.TraceError("Dette er en fejl");

            Trace.Close();
            Console.WriteLine("Slut");
            Console.ReadLine();
        }
    }
}
