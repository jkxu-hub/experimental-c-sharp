namespace AsyncProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Hello, {args[0]}");
            Console.WriteLine($"Hello, world");

            var utils = new ThreadUtils();
            var threadingFun = new SystemThreadingFun();

            ThreadUtils.ExtractExecutingThread();
            SystemThreadingFun.PrintPrimaryThreadStats();
            SystemThreadingFun.PrintNumberAsync(false);
            threadingFun.ParameterizedAdditionAsync();

            /*
             * 1. Task Parallel Library (TPL)
             * 2. Parallel LINQ (PLINQ)
             * 3. intrinsic asynchronous keywords of C# async and await
             */
        }
    }
}
