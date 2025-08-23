namespace AsyncProgrammingPart3TimerCallbacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");
            TimerCallback timeCB = new TimerCallback(PrintTime);
            Timer t = new Timer(
                timeCB,   // The TimerCallback delegate object.
                "apples",     // Any info to pass into the called method (null for no info).
                2000,        // Amount of time to wait before starting (in milliseconds).
                1000);    // Interval of time between calls (in milliseconds)


            _ = new Timer(
                timeCB,   // The TimerCallback delegate object.
                "BWAHAHAHAHAHAHA",     // Any info to pass into the called method (null for no info).
                0,        // Amount of time to wait before starting (in milliseconds).
                10000);    // Interval of time between calls (in milliseconds)
            Console.WriteLine("Hit Enter key to terminate... ");

            Console.ReadLine();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}",
            DateTime.Now.ToLongTimeString());
            Console.WriteLine($"Your param is {state.ToString()}");
        }
    }


}
