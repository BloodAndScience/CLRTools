using System;
    using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Afkvalley;

namespace MouseMover
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
                new Exception("Should be some args");
            if(args.Length!=3)
                 new Exception("Should be 3 args x and y and mouse");

            int x = Int32.Parse(args[0]);
            int y = Int32.Parse(args[1]);
            WinAPI.MouseMove(x,y);
            WinAPI.MouseClick(args[2]);
            Console.WriteLine($"{args[2]} click x:{x} y:{y}");
        }
    }
}
