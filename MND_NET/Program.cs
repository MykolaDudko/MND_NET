using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MND_NET
{
    //critical section
    class Program
    {
        static object locker = new object();

        static void WriteSecond()
        {
            for (int i = 0; i < 20; i++)
            {
                lock (locker)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new string(' ', 10) + "Secondary");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(100);
                }
            }
        }

        static void Main()
        {
            Console.SetWindowSize(80, 45);

            ThreadStart writeSecond = new ThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start();

            for (int i = 0; i < 20; i++)
            {
                lock (locker)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Primary");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(100);
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }

    //class MyClass
    //{
    //    object block = new object();

    //    public void Method()
    //    {
    //        int hash = Thread.CurrentThread.GetHashCode();

    //        Monitor.Enter(block); 

    //        for (int counter = 0; counter < 10; counter++)
    //        {
    //            Console.WriteLine("Поток # {0}: шаг {1}", hash, counter);
    //            Thread.Sleep(100);
    //        }
    //        Console.WriteLine(new string('-', 20));

    //        Monitor.Exit(block);  
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Console.SetWindowSize(80, 40);

    //        MyClass instance = new MyClass();

    //        for (int i = 0; i < 3; i++)
    //        {
    //            new Thread(instance.Method).Start();
    //        }

    //        // Delay.
    //        Console.ReadKey();
    //    }
    //}
}
