using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.LLStackQueue
{
    // Typical APIs to be implemented.
    // Push(), Pop(), Count(), Peek(), GetMinElement()

    public class MinStack<T> where T: IComparable<T>
    {
        private Stack<T> data;
        private Stack<T> minStack;
        private int maxSize;

        public MinStack(int size)
        {
            maxSize = size;
            data = new Stack<T>(size);
            minStack = new Stack<T>(size);
        }

        public void Push(T value)
        {
            if(data.Count == maxSize)
            {
                throw new ApplicationException("Stack is Full!"); // new StackFullException("");
            }


            data.Push(value);
            if(minStack.Count == 0 || minStack.Peek().CompareTo(value) >= 0) // value on the minstack is greater than  or equal to upcoming item.
            {
                minStack.Push(value);
            }
        }

        public T Pop()
        {
            if(data.Count == 0)
            {
                throw new ApplicationException("Stack is empty"); // new EmptyStackException();
            }

            var val = data.Pop();
            if(val.CompareTo(minStack.Peek()) == 0)
            {
                minStack.Pop();
            }

            return val;
        }

        public T Peek()
        {
            if (data.Count == 0)
            {
                throw new ApplicationException("Stack is empty"); // new EmptyStackException();
            }

            return data.Peek();
        }

        public int Count()
        {
            return data.Count;
        }

        public T GetMinElement()
        {
            if (minStack.Count == 0)
            {
                throw new ApplicationException("Stack is empty"); // new EmptyStackException();
            }

            return minStack.Peek();
        }

        public void PrintStack()
        {
            if (data.Count == 0)
            {
                Console.WriteLine("Empty Stack!");
                return;
            }

            Console.WriteLine($"Top Element {data.Peek().ToString()}");
            Console.WriteLine($"Min Element {minStack.Peek().ToString()}");
            Console.WriteLine($"Data Stack Size: {data.Count}, MinStack Size: {minStack.Count} ");
            Console.WriteLine();
        }
    }
}
