using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Models.CSharp
{
    public class Conditionals
    {
        public void conditional()
        {
            // If statement

            int first = 1;
            int second = 2;

            if (second > first)
            {
                Console.WriteLine("Second is greater than First");
            }
            else
            {
                Console.WriteLine("First is greater than Second");
            }

            // shorthand conditional (ternary operator)

            string value = "";
            value = (second > first) ? "second" : "first";
            Console.WriteLine(value);

            // Switch 

            int myCase = 2;

            switch (myCase)
            {
                case 1:
                    Console.WriteLine("1");
                    break;

                case 2:
                    Console.WriteLine("2");
                    break;

                default:
                    Console.WriteLine("BAD");
                    break;
            }

            // for loop
            for (int z = 0; z <= 20; z++)
            {
                Console.WriteLine(z);
            }

            //for each
            int[] collection = { 1, 2, 3, 4, 5 };
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            // while 
            int f = 0;
            while (f < 20)
            {
                Console.WriteLine(f);
                f++;
            }

            // Do while

            int d = 0;
            do
            {
                Console.WriteLine(d);
                d++;
            }
            while (d <= 60);

        }

    }
}
