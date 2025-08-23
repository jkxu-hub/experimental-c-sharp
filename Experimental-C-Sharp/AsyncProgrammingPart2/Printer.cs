using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingPart2
{
    public class Printer
    {
        // Lock token.
        private object threadLock = new object();
        /**
         * if you are attempting to lock down code in a static method, simply declare a private static object 
         * member variable to serve as the lock token.
         */

        public void PrintNumbers()
        {
            // Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()",
            Thread.CurrentThread.Name);
            // Print out numbers.
            for (int i = 0; i < 10; i++)
            {
                // Put thread to sleep for a random amount of time.
                Random r = new Random();
                Thread.Sleep(1000 * r.Next(5));
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }

        public void PrintNumbersThreadSafe()
        {
            Console.WriteLine("-> {0} is executing PrintNumbersThreadSafe()",
                Thread.CurrentThread.Name);

            // Use the private object lock token.
            lock (threadLock)
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(123 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }

        //This method is equivalent to the thread-safe example above
        /*
         * Now, given that the lock keyword seems to require less code than making explicit use of the System.
             Threading.Monitor type, you might wonder about the benefits of using the Monitor type directly. The short 
            answer is control. If you use the Monitor type, you can instruct the active thread to wait for some duration of 
            time (via the static Monitor.Wait() method), inform waiting threads when the current thread is completed 
            (via the static Monitor.Pulse() and Monitor.PulseAll() methods), and so on.

        * would your program operate faster if you did Monitor.Wait() so that blocked threads are notified?

         */
        public void PrintNumbersWithMonitors()
        {
            Monitor.Enter(threadLock);
            try
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}
