using System;

namespace aula14_intermediate_language
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Module (3,7) = " + Module(3,7));
        }

        /// <summary>
        /// Receives a point coordinates and returns its module.
        /// </summary>
        static double Module(int x, int y){  
            int x2 = x * x;
            int y2 = y * y;
            return Math.Sqrt(x2 + y2);
        }

    }
}
