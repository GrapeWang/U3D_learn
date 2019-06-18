using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Q1
            //int a1;
            //int a2;
            //int a3;
            //int a4;
            //int maxnum;
            //int minnum;
            //Console.WriteLine("Input four integers: ");
            //a1 = Convert.ToInt32(Console.ReadLine());
            //a2 = Convert.ToInt32(Console.ReadLine());
            //a3 = Convert.ToInt32(Console.ReadLine());
            //a4 = Convert.ToInt32(Console.ReadLine());
            //if (a1 < a2)
            //{
            //    minnum = a1;
            //    maxnum = a2;
            //}
            //else
            //{
            //    maxnum = a1;
            //    minnum = a2;
            //}

            //if (a3 < minnum)
            //{
            //    minnum = a3;
            //}
            //if (a4 < minnum)
            //{
            //    minnum = a4;
            //}

            //if (a3 > maxnum)
            //{
            //    maxnum = a3;
            //}
            //if (a4 > maxnum)
            //{
            //    maxnum = a4;
            //}
            //Console.WriteLine("Max is: " + maxnum+"\n");
            //Console.WriteLine("Min is: " + minnum + "\n");
            //Console.ReadKey();

            //Q2
            //Console.WriteLine("Input two integers:");
            //int b1 = Convert.ToInt32(Console.ReadLine());
            //int b2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Input 0-3:");
            //int sign = Convert.ToInt32(Console.ReadLine());
            //int res = 0;
            //switch (sign)
            //{
            //    case 0:
            //        res = b1 + b2;
            //        break;
            //    case 1:
            //        res = b1 - b2;
            //        break;
            //    case 2:
            //        res = b1 * b2;
            //        break;
            //    case 3:
            //        res = b1 / b2;
            //        break;
            //    default:
            //        Console.WriteLine("Something wrong!");
            //        break;

            //}
            //Console.WriteLine("Result is "+res+"\n");
            //Console.ReadKey();

            //Q3
            //int sum = 0;
            ////int c;
            //int count = 0;
            //for (int c = 1; c <= 1000; c++)
            //{
            //    if (c % 7 == 0)
            //    {
            //        sum += c;
            //        count++;
            //    }
            //    if (count == 5)
            //    {
            //        count = 0;
            //        Console.WriteLine(sum + "\n");
            //        sum = 0;
            //    }
            //}
            //Console.ReadKey();




            //Q4
            //int d;
            //double sqrt;
            //double pow;
            //for (d = 1; d <= 100; d++)
            //{
            //    pow = Math.Pow(d, 2);
            //    sqrt = Math.Sqrt(d);
            //    Console.WriteLine(pow +"  "+sqrt+ "\n");
            //}
            //Console.ReadKey();

            //Q5
            //int sum;
            //int adult = 0;
            //int yon0 = 2;
            //int yon1 = 0;
            //int yon2 = 0;
            //for (int i = 1; i <= 20; i++)
            //{
            //  adult =adult+yon2;
            //  yon2 = yon1;
            //  yon1 = yon0;
            //  yon0 = adult;
            //}

            //sum = adult + yon2 + yon1 + yon0;
            //Console.WriteLine(  "the number of rabbits: " +sum+ "\n");
            //Console.ReadKey();

            //Q6
            //int count=0;
            //for (int i = 1; i <=100; i++)
            //{
            //    if (i%3==0)
            //    {
            //        if (i%5!=0)
            //        {
            //            count++;
            //            Console.WriteLine(i + "\n");
            //        }
            //    }
            //}
            //Console.WriteLine("The number is: " + count+"\n");
            //Console.ReadKey();

            //Q7
            //bool isSushu = true;
            //int count=0;
            //for (int i = 2; i <= 1000; i++)
            //{
            //    isSushu = true;
            //    for (int j = 2; j < i; j++)
            //    {
            //        if (i%j==0)
            //        {
            //            isSushu = false;
            //            break;
            //        }
            //    }

            //    if (isSushu)
            //    {
            //        Console.WriteLine(i + "\n");
            //        count++;
            //    }
            //}
            //Console.WriteLine("The number is: " + count+"\n");
            //Console.ReadKey();

            //Q8
            //for (int i = 1; i < 10; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.WriteLine(i+"*" + j +"="+i*j+"\n");
            //    }
            //}
            //Console.ReadKey();

            //Q9
            //int c1 = 0;
            //int c2 = 0;
            //int c3 = 0;
            //int c4 = 0;
            //int c5 = 0;
            //int c6 = 0;
            //int res;
            //Random rd = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    res = rd.Next(1, 7);
            //    switch (res)
            //    {
            //        case 1:
            //            c1++;
            //            break;
            //        case 2:
            //            c2++;
            //            break;
            //        case 3:
            //            c3++;
            //            break;
            //        case 4:
            //            c4++;
            //            break;
            //        case 5:
            //            c5++;
            //            break;
            //        case 6:
            //            c6++;
            //            break;
            //    }
            //}
            //Console.WriteLine(c1 + " " + c2 + " " + c3 + " " + c4 + " " + c5 + " " + c6 + "\n");
            //Console.ReadKey();

            //Q10
            //Console.WriteLine("Input five capital letter:\n");
            //string str;
            //int i = 0;
            //while (i < 5)
            //{
            //    str = Console.ReadLine();
            //    if (str[0]>='A' && str[0]<='Z')
            //    {
            //        i++;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Wrong!Please re-input five capital letter:\n");
            //        i = 0;
            //    }
            //}
            //Console.ReadKey();

            int[] score = new int[2];
            score[2] = 2;
        }
    }
}
