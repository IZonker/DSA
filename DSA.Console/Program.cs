using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.DataStructures.Lists;

namespace DSA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.Reverse(list.Head);*/
            Func<int> f = () => 4*825;

            var d = Math.Log(1000, 10);
            System.Console.WriteLine(f());

            System.Console.Read();
        }
    }
}
