using System;
using PointLib;

namespace PointApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(3,7);
            Console.WriteLine("Module ="+ p.getModule());
        }

    
    }
}