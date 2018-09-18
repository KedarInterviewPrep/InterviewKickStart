using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingBasics
{
    public class ProducerCopnsumerTest
    {
        public static void RunTest()
        {
            var pc = new ProducerConsumer<int>(50);
            var r1 = new Random(1);
            var r2 = new Random(2);

            // Producer threads.

            Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Task.Run(() =>
                    {
                        pc.Produce(i);
                        Console.WriteLine($"Producer Produced: {i}");
                    });
                    Thread.Sleep(r1.Next(100));
                }
            });
            // consumer threads.

            Task.Run(() =>
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            Task.Run(() =>
                            {
                                var item = pc.Consume();
                                Console.WriteLine($"Consumer consumed: {item}");
                            });
                            Thread.Sleep(r2.Next(1000));
                        }
                    });
        }
    }

    public class ProducerConsumer<T>
    {
        int maxSize;
        Queue<T> q;
        private readonly object qLock = new object();

        public ProducerConsumer(int size)
        {
            this.maxSize = size;
            q = new Queue<T>(size);
        }

        public void Produce(T item)
        {
            lock (qLock)
            {
                while (q.Count == maxSize)
                {
                    Monitor.Wait(qLock);
                }

                q.Enqueue(item);
                if (q.Count > 0)
                {
                    Monitor.PulseAll(qLock);
                }
            }
        }

        public T Consume()
        {
            T item;
            lock (qLock)
            {
                while (q.Count == 0)
                {
                    Monitor.Wait(qLock);
                }

                item = q.Dequeue();

                if(q.Count < this.maxSize)
                    Monitor.PulseAll(qLock);
            }
            return item;
        }
    }
}
