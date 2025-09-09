using System.Text;
using System.Threading.Tasks;

namespace ExperimentingAsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MyList list = new MyList(10);
            list.Add(1);
            Console.WriteLine(list.View());

            Task<string>? futureBread = list.giveBread(10);
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"Main Thread {i}/8");
                await Task.Delay(1000);
            }
            
            string myBread = await futureBread;
            Console.WriteLine(myBread);


        }


    }
}
