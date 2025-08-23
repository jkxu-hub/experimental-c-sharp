using System.Reflection;

namespace AsyncProgrammingPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads *****\n");
            Printer p = new Printer();
            // Make 10 threads that are all pointing to the same
            // method on the same object.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbersThreadSafe))
                {
                    Name = $"Worker thread #{i}"
                };
            }
            // Now start each one.
            foreach (Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }
    }
}
