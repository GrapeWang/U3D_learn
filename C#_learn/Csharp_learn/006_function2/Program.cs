using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_function2
{
    class Program
    {
        static double Height(int n)
        {
            if (n==0)
            {
                return 100;
            }
            return Height(n - 1)/2;
        }

        static int Die(int n)
        {
            if (n==1)
            {
                return 1;
            }
            return n * Die(n - 1);
        }

        static int Che(int n)
        {
            if (n==1)
            {
                return 1;
            }
            return Che(n - 1) + n * n;
        }

        static void Main(string[] args)
        {
            //Q5
            //double sum = Height(0);
            //for (int i = 1; i < 10; i++)
            //{
            //    sum += 2 * Height(i);
            //}

            //Console.WriteLine("Sum: "+sum+" Height: "+Height(10));
            //Console.ReadKey();

            //Q6
            //int sum=0;
            //for (int i = 1; i < 21; i++)
            //{
            //    sum += Die(i);
            //}

            //Console.WriteLine("Sum: " + sum + " 5!: " + Die(5));
            //Console.ReadKey();

            //Q9
            //string str = Console.ReadLine();
            //string[] strArray = str.Split('.');
            //string xiao = strArray[1];
            //int num = xiao[0]-'0';
            //int output = Convert.ToInt32(strArray[0]);
            //if (num>=5)
            //{
            //    output++;
            //}
            //Console.WriteLine(output);
            //Console.ReadKey();

            //Q10
            //int max=0;
            //for (int i = 1; i < 2000; i++)
            //{
            //    if (Che(i)>=2000)
            //    {
            //        max = i - 1;
            //        break;
            //    }
            //}
            //Console.WriteLine("Max k: "+max);
            //Console.ReadKey();

            //Q11
            for (int i = 1; i <=20; i++)
            {
                for (int j = 1; j <= 33; j++)
                {
                    for (int k = 3; k <=300; k=k+3)
                    {
                        if ((i + j + k) == 100 && (5 * i + 3 * j + k / 3) == 100)
                        {
                            Console.WriteLine("Gong: "+i+" Mu: "+j+" Xiao: "+k);
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
