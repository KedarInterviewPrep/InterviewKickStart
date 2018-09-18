using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingBasics
{
    public class ThreadConcept
    {
        public static void TwoThreads()
        {
            //ThreadStart job = new ThreadStart(ThreadJob);
            var instance = new Test("Other thread instance");
            Thread thread = new Thread(() => instance.MyThreadJob("Prefix", "Suffix"));
            thread.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread: {0}", i);
                thread.Join();
                //Thread.Sleep(200);
            }

            

        }

        static void ThreadJob()
        {
           for(int i =0; i < 10; i++)
            {
                Console.WriteLine($"Other thread: {i}");
                Thread.Sleep(500);
            }
        }
    }


    public class Test
    {
        string prefix = "";
        public Test(string prefix)
        {
            this.prefix = prefix;
        }

        public void MyThreadJob(string myprefix, string mysuffix)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{myprefix}: {i} : {mysuffix}");
                Thread.Sleep(200);
            }
        }
    }
}
