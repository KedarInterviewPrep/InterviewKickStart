using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadConcept.TwoThreads();
            
            // Producer Consumer.
            ProducerCopnsumerTest.RunTest();

            Console.ReadKey();
        }
    }
}
