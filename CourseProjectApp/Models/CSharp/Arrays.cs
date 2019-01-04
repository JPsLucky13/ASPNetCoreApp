using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Models.CSharp
{
    public class Arrays
    {
        // Declare Array
        string[] firstArray;

        // Declare and Initialize Array
        string[] secondArray = new string[2];

        // Declare and Initialize Array Inline
        string[] thirdArray = { "FirstElement", "SecondElement", "ThirdElement"};

        public void ArrayMethod()
        {
            secondArray[0] = "First";
            secondArray[1] = "Second";

            foreach (var myElement in thirdArray)
            {
                Console.WriteLine(myElement);
            }
        }
    }
}
