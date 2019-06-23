using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsAccessBridgeInterop;

namespace JABConsole
{
    class Program
    {
        static void Main(string[] args)
        {

                var jab = new JABController();
                jab.InicializarDriver()
                    .CheckJVM();


            Task t = new Task(() =>
            {
                while (true)
                {
                    jab.CheckJVM();
                    Thread.Sleep(1000);
                }
            });

            t.Start();

            Console.ReadKey();

        }
    
    }
}
