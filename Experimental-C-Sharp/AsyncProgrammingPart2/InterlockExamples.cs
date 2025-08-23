using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingPart2
{

    /*
        CompareExchange() Safely tests two values for equality and, if equal, exchanges one of the values with a third
         Decrement() - Safely decrements a value by 1
        Exchange() - Safely swaps two values
        Increment() - Safely increments a value by 1

     */
    public class InterlockExamples
    {
        private object myLockToken = new object();
        private int intVal = 5;
        

        internal void incrementNum()
        {
            lock (myLockToken)
            {
                intVal++;
            }
        }

        internal void incrementNumWithInterlocked()
        {
            intVal = Interlocked.Increment(ref intVal);

        }
        

    }
}
