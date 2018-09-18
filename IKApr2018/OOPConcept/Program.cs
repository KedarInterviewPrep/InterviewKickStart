using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            #region VirtualMethods
            Base b1 = new Base();
            Console.WriteLine();
            Base b2 = new Derived();
            Console.WriteLine();

            b1.NonVirtual();
            b1.Virtual();
            b2.NonVirtual();
            b2.Virtual();
            #endregion

            Console.ReadKey();
        }
    }


    public class Base
    {
        public Base()
        {
            Console.WriteLine("Base class constructor called.");
        }

        public void NonVirtual()
        {
            Console.WriteLine("Base non-virtual method called.");
        }

        public virtual void Virtual()
        {
            Console.WriteLine("Base virtual method called.");
        }
    }

    public class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derived class constructor called.");
        }

        public void NonVirtual()
        {
            Console.WriteLine("Base virtual method called.");
        }

        public override void Virtual()
        {
            Console.WriteLine("derived virtual method called.");
        }
    }
}
