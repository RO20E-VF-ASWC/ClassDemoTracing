using System;

namespace ClassDemoTracing
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceWorker worker = new TraceWorker();
            worker.Start();

            Console.ReadLine();
        }
    }
}
