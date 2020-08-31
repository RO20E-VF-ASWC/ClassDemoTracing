using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ClassDemoTracing
{
    class MyOwnTraceListener:TraceListener
    {
        private StreamWriter sw;
        public MyOwnTraceListener():this("MyOwnTraceListener")
        {

        }

        public MyOwnTraceListener(string name) : base(name)
        {
            sw = new StreamWriter("MyOwnTraceListener.txt",true);
            sw.AutoFlush = true;

        }

        public override void Write(string message)
        {
            if (message == null) return;

            if (message.Contains("peter"))
            {
                sw.Write("PETER: " + message);
            }
            else
            {
                sw.Write(message);
            }
        }

        public override void WriteLine(string message)
        {
            if (message == null) return;

            if (message.Contains("peter"))
            {
                sw.WriteLine("PETER: " + message);
            }
            else
            {
                sw.WriteLine(message);
            }
        }
    }
}
