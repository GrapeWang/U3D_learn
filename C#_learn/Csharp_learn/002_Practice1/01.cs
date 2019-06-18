using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            int enemyHp = 100;
            int enemyAttact = 90;
            int enemyGuard = 50;
            Console.WriteLine("Enemy HP:" + enemyHp.ToString() + "\n" + "Enemy Attack:" + enemyAttact.ToString() + "\n" + "Enemy Guard:" + enemyGuard.ToString() + "\n");
            Console.ReadKey();

            int a;
            int b;
            int temp;
            Console.WriteLine("Input your first integer: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input your second integer: ");
            b = Convert.ToInt32(Console.ReadLine());
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a + " " + b);
            Console.ReadKey();

            int a1;
            int a2;
            int a3;
            int a4;
            Console.WriteLine("Input four integers: ");
            a1 = Convert.ToInt32(Console.ReadLine());
            a2 = Convert.ToInt32(Console.ReadLine());
            a3 = Convert.ToInt32(Console.ReadLine());
            a4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The product is: " + a1 * a2 * a3 * a4);
            Console.ReadKey();

            int big3;
            int change3;
            int hundr;
            int tens;
            int digit;
            Console.WriteLine("Input a three-digit integer: ");
            big3 = Convert.ToInt32(Console.ReadLine());
            hundr = big3 / 100 %10;
            digit = big3 /1 % 10;
            tens = big3 / 10 % 10;
            change3 = digit * 100 + tens * 10 + hundr;
            Console.WriteLine("The converted integer is: "+ change3);
            Console.ReadKey();

            int upperbase;
            int lowerbase;
            int height;
            Console.WriteLine("Input the upper base, lower base and height: ");
            upperbase = Convert.ToInt32(Console.ReadLine());
            lowerbase = Convert.ToInt32(Console.ReadLine());
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The area is: "+ (upperbase+lowerbase)*height/2f);
            Console.ReadKey();

            double radius;
            double perimeter;
            double area; 
            double pi = 3.14;
            Console.WriteLine("Input the radius: ");
            radius = Convert.ToDouble(Console.ReadLine());
            perimeter = 2 * pi * radius;
            area = pi * radius * radius;
            Console.WriteLine("The perimeter is: "+ perimeter+"\n"+"The area is: "+ area+"\n");
            Console.ReadKey();
        }
    }
}
