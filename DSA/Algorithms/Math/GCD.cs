using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Algorithms
{
    public static class GCD
    {
        public static int EvaluateR(int x, int y)
        {
            if (x == 0)
                return y;
            if (y == 0)
                return x;

            if (x > y)
                return EvaluateR(x % y, y);
            return EvaluateR(x, y % x);
        }

        public static int Evaluate(int x, int y)
        {
            while (x != 0 && y != 0)
            {
                if (x > y)
                    x = x % y;
                else if (y > x)
                    y = y % x;
            }

            if (x == 0)
                return y;
            return x;
        }
    }
}
