using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Models.CSharp
{
    public class FirstClass
    {
        public string Value;

        private string _value;

        //Properties
        public string MainValue {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public FirstClass(string value)
        {
            Value = value;
        }

        public FirstClass()
        {

        }

        // Return Method

        public bool TrueFalse(int number)
        {
            if (number > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Void Method No Return Value
        public void NoReturn(string value)
        {
            Console.WriteLine($"This is my return value:{value}");
        }
    }
}
