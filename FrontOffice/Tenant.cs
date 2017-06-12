using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice
{
    public class Tenant
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(myFun);
            t.Name = "Thread1";
            t.IsBackground = false;
            t.Start();
            Console.WriteLine("Main thread Running");
            Console.ReadKey();
        }
    }
}