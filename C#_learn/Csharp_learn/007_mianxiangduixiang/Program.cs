using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_mianxiangduixiang
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3 v1 = new Vector3();
            //v1.getX(1);
            //v1.getY(1);
            //v1.getZ(1);
            v1.X = 200;
            Console.WriteLine(v1.X);
            Console.ReadKey();
        }
    }
}
