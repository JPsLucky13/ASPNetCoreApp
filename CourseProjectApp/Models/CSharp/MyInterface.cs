using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProjectApp.Models.Interface;

namespace CourseProjectApp.Models.CSharp
{
    public class MyInterface : IInterface
    {
        private double amount;

        private string value;

        public MyInterface()
        {
            amount = 10.0;
            value = "My String Value!!";
        }

        public void ShowValue()
        {
            Console.WriteLine($"My value is:{value}");
        }

        public double GetValue()
        {
            return amount;
        }
    }

    public class MyInterface2 : IInterface
    {
        public double GetValue()
        {
            throw new NotImplementedException();
        }

        public void ShowValue()
        {
            throw new NotImplementedException();
        }
    }
}
