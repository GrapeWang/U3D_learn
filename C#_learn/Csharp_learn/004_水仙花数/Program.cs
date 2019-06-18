using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_水仙花数
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1
            //Console.WriteLine("水仙花数有： ");
            //int ge;
            //int shi;
            //int bai;
            //for (int i = 100; i < 1000; i++)
            //{
            //    ge = i % 10;
            //    shi = i / 10 % 10;
            //    bai = i / 100 % 10;
            //    if (i == ge * ge * ge + shi * shi * shi + bai * bai * bai)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //Q2
            //int a = 364;
            //int bottle = 0;
            //int nbottle = 0;
            //int drink = 0;
            //do
            //{
            //    drink = drink + a;
            //    nbottle = a;
            //    a = (nbottle + bottle) / 3;
            //    bottle = (nbottle + bottle) % 3;
            //} while (a>0);
            //Console.WriteLine("Drink: "+drink+" "+"Bottle: "+bottle);

            //Q3
            //Random rd = new Random();
            //int num = rd.Next(0,51);
            //Console.WriteLine(num);
            //Console.WriteLine("Input an integer from 0 to 50: ");
            //while (true)
            //{
            //    int input = Convert.ToInt32(Console.ReadLine());
            //    if (num < input)
            //    {
            //        Console.WriteLine("你猜大了");
            //    }
            //    else if (num > input)
            //    {
            //        Console.WriteLine("你猜小了");
            //    }
            //    else
            //    {
            //        Console.WriteLine("你猜对了！");
            //        break;
            //    }

            //}

            //Q4
            //Console.WriteLine("Input a string: ");
            //string input = Console.ReadLine();
            //char[] output = input.ToCharArray();
            //int temp;
            //for (int i = 0; i < output.Length; i++)
            //{
            //    if (output[i] >= 'a' && output[i] <= 'w')
            //    {
            //        temp = output[i]+3;
            //        output[i] = (char)temp;
            //    }

            //    if (output[i] >= 'A' && output[i] <= 'W')
            //    {
            //        temp = output[i] + 3;
            //        output[i] = (char)temp;
            //    }

            //    switch (output[i])
            //    {
            //        case 'x':
            //            output[i] = 'a';
            //            break;
            //        case 'y':
            //            output[i] = 'b';
            //            break;
            //        case 'z':
            //            output[i] = 'c';
            //            break;
            //        case 'X':
            //            output[i] = 'A';
            //            break;
            //        case 'Y':
            //            output[i] = 'B';
            //            break;
            //        case 'Z':
            //            output[i] = 'C';
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //Console.WriteLine(output);

            //Q5
            //int[] num = new int[10];
            //int temp;
            //Console.WriteLine("Input ten integers");
            //for (int i = 0; i < 10; i++)
            //{
            //    num[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 1; j < 10-i; j++)
            //    {
            //        if (num[10-j]<num[10-j-1])
            //        {
            //            temp = num[10 - j];
            //            num[10 - j] = num[10 - j - 1];
            //            num[10 - j - 1] = temp;
            //        }
            //    }
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write(num[i]+" ");
            //}

            //Q6
            //Console.WriteLine("Input n: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //int sum = 1;
            //for (int i = 1; i < n; i++)
            //{
            //    sum = (sum + 1) * 2;
            //}
            //Console.WriteLine("Sum: "+sum);

            //Console.ReadKey();

            //Q7

            //int n = 0;
            //int count=0;
            //string str;
            //Console.WriteLine("Input the integers");
            //int[] num = new int[100];
            //while (true)
            //{
            //    str = Console.ReadLine();

            //    if (n==100 || str ==" ")
            //    {
            //        break;
            //    }

            //    num[n] = Convert.ToInt32(str);
            //    n++;
            //}
            //int min = num[0];
            //for (int i = 0; i < n; i++)
            //{
            //    if (num[i]<min)
            //    {
            //        min = num[i];
            //        count = i;
            //    }
            //}

            //int temp = num[0];
            //num[0] = min;
            //num[count] = temp;

            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(num[i] + " ");
            //}

            //Q8

            //int[] num=new int[10]{3,7,12,23,26,37,59,60,79,123};
            //int[] output = new int[11];
            //int count = 0;
            //for (int i = 0; i < 10; i++)
            //    {
            //        Console.Write(num[i] + " ");
            //    }
            //    Console.WriteLine("Input a number: ");
            //int input = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < 10; i++)
            //{
            //    if (num[i]<input)
            //    {
            //        output[i] = num[i];
            //    }
            //    else
            //    {
            //        output[i] = input;
            //        count = i;
            //        break;
            //    }

            //}
            //if (num[9] < input)
            //{
            //    output[10] = input;
            //}
            //else
            //{
            //    for (int i = count+1; i < 11; i++)
            //    {
            //        output[i] = num[i - 1];
            //    }
            //}
            //for (int i = 0; i < 11; i++)
            //{
            //    Console.Write(output[i] + " ");
            //}

            //Q11
            //Console.WriteLine("Input a string: ");
            //bool isHui = true;
            //string str = Console.ReadLine();

            //for (int i = 0; i < str.Length/2; i++)
            //{
            //    if (str[i] != str[str.Length-i-1])
            //    {
            //        isHui = false;
            //        break;
            //    }
            //}
            //Console.WriteLine(isHui);

            //Q12
            Console.WriteLine("Input a string: ");
            string str = Console.ReadLine();
            bool isAn = true;
            int condi = 0;
            int da = 0;
            int xiao = 0;
            int shu = 0;
            int te = 0;
            if (str.Length >= 8 && str.Length <= 16)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 'a' && str[i] <= 'z')
                    {
                        xiao = 1;
                    }
                    if (str[i] >= 'A' && str[i] <= 'Z')
                    {
                        da = 1;
                    }
                    if (str[i] >= '0' && str[i] <= '9')
                    {
                        shu = 1;
                    }
                    if (str[i] == '~' || str[i] == '!'|| str[i] =='@'|| str[i] == '#'|| str[i] == '$'|| str[i] == '%'|| str[i] == '^')
                    {
                        te = 1;
                    }
                }

                condi = xiao + da + shu + te;
                if (condi < 3)
                {
                    isAn = false;
                }
            }
            else
            {
                isAn = false;
            }
            Console.WriteLine(isAn);


            Console.ReadKey();
        }
    }
}
