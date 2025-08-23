using System.Reflection;
using System.Threading;

namespace AsyncProgramming
{
    internal class SystemThreadingFun
    {
        public static void PrintPrimaryThreadStats()
        {
            Console.WriteLine("*****Primary Thread stats ****\n");
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";
            
            Console.WriteLine($"ID of current thread: {primaryThread.ManagedThreadId}");
            Console.WriteLine($"Thread Name: {primaryThread.Name}");
            Console.WriteLine($"Has thread started? {primaryThread.IsAlive}");
            Console.WriteLine($"Priority Level: {primaryThread.Priority}");
            Console.WriteLine($"Thread State: {primaryThread.ThreadState}");
        }

        //*******Set thread priority with caution:
        //It is possible to jack up the priority level on a set of threads, thereby preventing lower-priority threads from executing at their required levels.
        public static void ChangePriorityToLowest()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
        }

        public static void PrintNumberAsync(bool isAsync)
        {
            Console.WriteLine("***** Print Numbers Async  *****\n");
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            Console.WriteLine("-> {0} is executing Main()",
            Thread.CurrentThread.Name);
            // Make worker class.
            Printer p = new Printer();

            if (isAsync)
            {
                Thread backgroundThread = 
                    new Thread(new ThreadStart(p.PrintNumbers));

                backgroundThread.Name = "Secondary";
                backgroundThread.Start();

                Console.WriteLine();
            }
            else
            {
                p.PrintNumbers();
            }
        }
        void Add(object data)
        {
            if (data is AddParams ap)
            {
                Console.WriteLine("ID of thread in Add(): {0}",
                Environment.CurrentManagedThreadId);
                Console.WriteLine("{0} + {1} is {2}",
                ap.a, ap.b, ap.a + ap.b);
            }
        }

        public void ParameterizedAdditionAsync()
        {
            AutoResetEvent _waitHandle = new AutoResetEvent(false);

            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
            Environment.CurrentManagedThreadId);
            // Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Wait here until you are notified!
            _waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();
        }
    }
}


/*
 * System.Threading Namespace:
 * - access to thread state, locking/synchronization mechanisms, thread pool, timer class 
 * 
 * Types:                       Meaning
 * 
 * Interlocked:                 Provides atomic operations for variables that are shared by multiple threads
 * 
 * Monitor:                     Provides the synchronization of threading objects using locks and wait/signals. The C# lock keyword uses a Monitor object under the hood.
 * 
 * Mutex:                       The synchronization primitive can be used for synchornization between application domain boundaries.
 * 
 * Parameterized                ThreadStart: This delegate allows a thread to call methods that take any number of arguments.
 * 
 * Semaphore:                   This type allows you to limit the number of threads that can access a resource concurrently.
 * 
 * Thread:                      This type represents a thread that executes within the .NET Core Runtime.
 * 
 * ThreadPool:                  This type allows you to interact with the .NET Core Runtime-maintained thread pool within a given process.
 * 
 * ThreadPriority:              This enum represents a thread's priority level (Highest, Normal, etc.)
 * 
 * ThreadStart:                 This delegate is used to specify the method to call for a given thread. 
 *                              Unlike the ParameterizedThreadStart delegate, targets of ThreadStart must always have the same prototype.
 *                              
 * ThreadState:                 This enum specifies the valid states a thread may take (Running, Aborted, etc.).
 * 
 * Timer:                       This type provides a mechanism for executing a method at specified intervals.
 * 
 * TimerCallback:               This delegate type is used in conjunction with Timer types.
 * 
 * 
 */

/*
 *  Going into depth about System.Threading.Thread
 *  
 *  Types                       Meaning
 *  
 *  Static Members
 *  
 *  ExecutionContext:           This read-only property returns information relevant to the logical thread of execution, including security, call synchronization, localization, and transaction contexts.
 *  
 *  CurrentThread:              This read-only property returns a reference to the currently running thread.
 *  
 *  Sleep():                    This method suspends the current thread for a specified time.


 *  Instance-Level members
 *  
 *  IsAlive:                    Returns a Boolean that indicates whether this thread has been started (and has not yet terminated or aborted)
 *  
 *  IsBackground:               Gets or sets a value indicating whether this thread is a "background thread" 
 *                              Allows you to establish a friendly text name of the thread.
 *  
 *  Priority:                   Gets or sets the priority of a thread, which may be assigned a value from the ThreadPriority enumeration.
 *  
 *  ThreadState:                Gets the state of this thread, which may be assigned a vlaue from the ThreadState enumeration.
 *  
 *  Abort():                    Instructs the .NET Core Runtime to terminate the thread as soon as possible
 *  
 *  Interrupt():                Interrupts (e.g., wakes) the current thread from a suitable wait period.
 *  
 *  Join():                     Blocks the calling thread until the specified thread (the one on which Join is called) exits.
 *  
 *  Resume():                   Resumes a thread that has been previously suspended.
 *  
 *  Start():                    instructs the .NET Core Runtime to execute the thread ASAP.
 *  
 *  Suspend():                  Suspends the thread. If the thread is already suspended, a call to Suspend() has no effect.
 *  
 *  **** NOTE: Aborting or suspending an active thread is generally considered a bad idea. 
 *  **** When you do so, there is a chance (however small) that a thread could "leak" its workload when disturbed or terminated.
 *  
 *  
 *
 *  Foreground threads can prevent the current application from terminating. The .NET 
 *  Core Runtime will not shut down an application (which is to say, unload the hosting 
 *  AppDomain) until all foreground threads have ended.
 *
 *  Background threads (sometimes called daemon threads) are viewed by the .NET 
 *  Core Runtime as expendable paths of execution that can be ignored at any point 
 *  in time (even if they are currently laboring over some unit of work). Thus, if all 
 *  foreground threads have terminated, all background threads are automatically killed 
 *  when the application domain unloads.
 *
 *It is important to note that foreground and background threads are not synonymous with primary 
and worker threads. By default, every thread you create via the Thread.Start() method is automatically a 
foreground thread. Again, this means that the AppDomain will not unload until all threads of execution have 
completed their units of work. In most cases, this is exactly the behavior you require.
 *
 *
 *
 *
 *
 *
 *
 
 
 */



