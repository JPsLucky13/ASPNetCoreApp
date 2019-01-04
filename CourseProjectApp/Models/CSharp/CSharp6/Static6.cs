
using System;
using static System.Console;

namespace CourseProjectApp.Models.CSharp.CSharp6
{
    public class Static6
    {
        //Auto-Property Initializers
        //public string MyString { get; set; }
        //public int MyInt { get; set; }

        //public Static6()
        //{
        //    MyString = "";
        //    MyInt = 6;
        //}

        //C# 6

        public string MyString { get; } = "My Value";
        public int MyInt { get; set; } = 6;

        // C# 6 Expression Bodied Properties

        public string FirstName { get; } = "John";

        public string LastName { get; } = "Jacob";

        public string MyFullName => FirstName + " " + LastName;

        // C# 5 & below

        public string FullName2
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public static void FirstStaticMethod()
        {
            // C# 5 and below Statics

            //Console.WriteLine("Text");

            // C# 6 and below Statics
            WriteLine("Text");

            //String Interpolation

            string first = "My First";
            string second = "My Second";


            //C# 5
            WriteLine("{0} is my forst value. {1} is my second value", first, second);

            //C# 6
            WriteLine($"{first} is my first value. {second} is my second value.");

            //Null conditional Operator & Null Propagation

            string valuenull = "Has a value";

            //C# 5
            WriteLine(valuenull != null ? valuenull : "No value");

            //C# 6
            WriteLine(valuenull?.ToString() ?? "Null");

            //C# 6 Try Catch Async

            //try
            //{
            //    await 
            //}
            //catch (Exception e)
            //{
            //    await
            //}
            //finally
            //{
            //    await
            //}

        }

        // C# 6 Expression Bodied Methods
        private double add(double v, double a) => v + a;

        // C# 5 
        private double add2(double b, double c)
        {
            return b + c;
        }
    }
}
