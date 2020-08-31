using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;

namespace ClassDemoTracing
{
    internal class TraceWorker
    {
        private TraceListener tlOwn;

        public TraceWorker()
        {
            // simple trace listeners
            TraceListener tlConsole = new ConsoleTraceListener();
            tlConsole.Filter = new EventTypeFilter(SourceLevels.All);

            // trace listener - file in solution folder
            TraceListener tlFile = new TextWriterTraceListener(new StreamWriter("ClassDemoLogFile.txt"));
            tlFile.Filter = new EventTypeFilter(SourceLevels.Warning);

            // trace listener - file in solution folder
            TraceListener tlXmlFile = new XmlWriterTraceListener(new StreamWriter("ClassDemoLogFile.xml"));
            tlXmlFile.Filter = new EventTypeFilter(SourceLevels.Warning);

            // This is deprecated in .Net Core does only exists by download a nuget packet 'Microsoft.Extensions.Logging.EventLog'
            //trace listener - windows event log
            TraceListener tlEventLog = new EventLogTraceListener("MyTrace");
            tlEventLog.Filter = new EventTypeFilter(SourceLevels.Error);

            // My own trace listener
            tlOwn = new MyOwnTraceListener();
            tlOwn.Filter = new EventTypeFilter(SourceLevels.All);

            Trace.Listeners.Add(tlConsole);
            Trace.Listeners.Add(tlFile);
            Trace.Listeners.Add(tlXmlFile);
            Trace.Listeners.Add(tlEventLog);
            Trace.Listeners.Add(tlOwn);

        }

        public void Start()
        {

            // different tracing
            Trace.TraceInformation("This is information");
            Trace.TraceWarning("This is warning");
            Trace.TraceError("This is error");
            Trace.WriteLine("this is critical", "Critical");


            // change filter
            tlOwn.Filter = new MyEventFilter();
            Trace.TraceError("uden p e t e r");
            Trace.TraceError("med peter");


            Trace.Close();
        }
    }
}