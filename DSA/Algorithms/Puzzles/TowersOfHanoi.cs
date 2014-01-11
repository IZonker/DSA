using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms.Puzzles
{
    public static partial class Puzzles
    {
        public static void Hanoi(int n, char from, char to, char help)
        {
            if (n > 0)
            {
                Hanoi(n - 1, from, help, to);
                Move(n, from, to);
                Hanoi(n - 1, help, to,   from);
            }
        }

        static void Move(int x, char from, char to)
        {
            Console.WriteLine("  Move disk " + x + " from " + from + " to " + to);
        }
    }
}
