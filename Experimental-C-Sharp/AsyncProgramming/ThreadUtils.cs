using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class ThreadUtils
    {
        //Definition: A thread is a path of execution within a process
        public static void ExtractExecutingThread()
        {
            //Get the thread currently
            //executing this method.
            Thread currThread = Thread.CurrentThread;

        }

        //Definition: An appdomain is an abstraction of how an OS represents an executable managed by .Net core platform.
        //Less CPU/memory used than a normal process
        public static void ExtractAppDomainHostingThread()
        {
            //Obtain the AppDomain hosting the current thread.
            AppDomain ad = Thread.GetDomain();
        }

        //Defintion: Execution Context - the "environment" in which code runs — it defines what data, resources, and rules are available to that running code.
        public static void ExtractCurrentThreadExecutionContext()
        {
            //Obtain the execution context under which the
            //current thread is operating
            ExecutionContext ctx = Thread.CurrentThread.ExecutionContext;

        }
    }
}
