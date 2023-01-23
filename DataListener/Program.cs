using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_PupSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bootstrap APP");

            DataService dataService = new DataService();
            Thread t = new Thread(dataService.StartDataService);
            t.IsBackground = false;
            t.Start();

            Console.WriteLine("Bootstrapping APP done");
        }
    }
}
