using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Laborator1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ExportEvent example = new ExportEvent();

            // add callback to  delegate
            example.OnChange += (sender, e) => Console.WriteLine("Event " + e.Name + " with  Value=" + e.Value);
            example.OnChange += (sender, e) => Console.WriteLine("Event " + e.Name + " with  Value=" + e.Value);
            example.OnChange += (sender, e) => Console.WriteLine("Event " + e.Name + " with  Value=" + e.Value);

            // raise the event
            example.Raise();
           
            ThreadStart childref1 = new ThreadStart(CallToFirstChildThread);
            ThreadStart childref2 = new ThreadStart(CallToSecondChildThread);
            Thread childThread1 = new Thread(childref1);
            Thread childThread2 = new Thread(childref2);
            childThread1.Start();
            childThread2.Start();
            Console.ReadLine();
        }

        public static void CallToFirstChildThread()
        {
            int value = 19;
            String result = "Start fir: " + Thread.CurrentThread.Name + " " + DateTime.Now + " Numar natural dat = " + value;
            Console.WriteLine(result);
            result = "Iesire temporara fir: " + Thread.CurrentThread.Name + " " + DateTime.Now;
            Console.WriteLine(result);
            result = "End fir: " + Thread.CurrentThread.Name + " " + DateTime.Now + " Numar prim = " + nr_prim_method_1(value);
            Console.WriteLine(result);
        }
        public static void CallToSecondChildThread()
        {
            int value = 19;
            String result = "Start fir: " + Thread.CurrentThread.Name + "  " + DateTime.Now + " Numar natural dat = " + value;
            Console.WriteLine(result);
            result = "Iesire temporara fir: " + Thread.CurrentThread.Name + " "  + DateTime.Now;
            Console.WriteLine(result);
            result = "End fir: " + Thread.CurrentThread.Name + " " + DateTime.Now + " Numar prim = " + nr_prim_method_2(value);
            Console.WriteLine(result);
        }
        public static int nr_prim_method_1(int number)
        {
            int prim = 2;
            bool ok;
            for (int i = 3; i < number; i++)
            {
                ok = true;
                for (int j = 2; j < i/2; j++)
                    if (i % j == 0)
                    {
                        ok = false;
                        break;
                    }
                if (ok == true)
                {
                    prim = i;
                }
            }
            return prim;
        }
        public static int nr_prim_method_2(int number)
        {
            int prim = 2;
            bool ok;
            for (int i = number - 1; i >= 3; i--)
            {
                ok = true;
                for (int j = 2; j < i/2; j++)
                    if (i % j == 0)
                    {
                        ok = false;
                        break;
                    }
                if (ok == true)
                {
                    prim = i;
                    break;
                }
            }
            return prim;
        }
    }
}
