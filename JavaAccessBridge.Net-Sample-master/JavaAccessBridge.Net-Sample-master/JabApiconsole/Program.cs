using JabApiLib.JavaAccessBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAccessBridgeInterop.Win32;

namespace JabApiconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            JabApi.Windows_run();

            NativeMethods.EnumWindows(delegate (IntPtr wnd, IntPtr param)
            {
                var w = wnd;
                var p = param;

               // if (w.ToString() == "9306846")
               // {
                    int vID = 0;
                    Console.WriteLine(w + " " + w.ToString());

                    var javaTree = JabHelpers..GetAccessibleContextInfo(wnd, out vID);

                    if (javaTree !=null)
                    {
                        var ere = "";
                    }
               // }


                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            Console.ReadKey();

        }
    }
}
