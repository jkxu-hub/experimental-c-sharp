using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentingAsyncAwait
{
    public class MyList
    {
        private int[] _storage { get; set; }
        private int _curr { get; set; } = 0;
        private int _size { get; set; }
        public MyList(int size = 10)
        {
            _storage = new int[size];
            _size = size;
            _curr = 0;
        }
        public void Add(int value)
        {
            _storage[_curr] = value;
            _curr++;
        }

        public async Task<string> giveBread(int time)
        {
            for(int i = 0; i < time; i++){
                Console.WriteLine($"Bread thread: {i}/{time}");
                await Task.Delay(1000);
            }
            return "Bread Done Baking";
        }

        public string View()
        {
            var sb = new StringBuilder();
            foreach(var item in _storage)
            {
                sb.Append(item.ToString() + ", ");
            }
            return sb.ToString();
        }

    }
}
