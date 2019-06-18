using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_function
{
    class Program
    {
        static bool isZhi(int num)
        {
            bool isZ = true;
            for (int i = 2; i < num; i++)
            {
                if(num%i==0)
                {
                    isZ = false;
                }
            }

            return isZ;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input number array: ");
            string str = Console.ReadLine();
            string[] numArray = str.Split(' ');
            int[] num = new int[numArray.Length];
            int remain;
            for (int i = 0; i < numArray.Length; i++)
            {
                num[i] = Convert.ToInt32(numArray[i]);
                remain = num[i];
                Console.Write(num[i]+"=");
                for (int j = 2; j < num[i]; j++)
                {
                    if (num[i]%j==0)
                    {
                        if (isZhi(j))
                        {
                            remain = remain / j;
                        }

                        if (isZhi(remain))
                        {
                            Console.Write(j+"*"+remain);
                            break;
                        }
                        else
                        {
                            Console.Write(j+"*");
                        }
                    }
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}
