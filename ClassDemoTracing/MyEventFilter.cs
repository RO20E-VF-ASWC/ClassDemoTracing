using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ClassDemoTracing
{
    class MyEventFilter:TraceFilter
    {
        public override bool ShouldTrace(TraceEventCache cache, string source, 
            TraceEventType eventType, int id, string formatOrMessage,
            object[] args, object data1, object[] data)
        {
            return (formatOrMessage != null && formatOrMessage.Length < 10);
        }
    }
}
