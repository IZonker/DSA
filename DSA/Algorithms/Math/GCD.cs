namespace DSA.Algorithms.Math
{
    public  static partial class Math
    {
        public static int GCDRecursive(int x, int y)
        {
            if (x == 0)
                return y;
            if (y == 0)
                return x;

            if (x > y)
                return GCDRecursive(x % y, y);
            return GCDRecursive(x, y % x);
        }

        public static int GCD(int x, int y)
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
