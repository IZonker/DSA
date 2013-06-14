using System.Collections.Generic;

namespace DSA.Algorithms.Sorting
{
    public static partial class Sorting
    {
        public  static IList<int> SolveDutchNationalFlagProblem (this IList<int> list)
        {
            int low = -1;
            int high = list.Count;

            for (int i = 0; i < high;) 
            {
                switch (list[i])
                {
                    case 0: { Swap(list, i, ++low); ++i; } break;
                    case 1: { ++i;                       } break;
                    case 2: { Swap(list, i, --high);     } break;
                }
            }

            return list;
        }
    }
}
