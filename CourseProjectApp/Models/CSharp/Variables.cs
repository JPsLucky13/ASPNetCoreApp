using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Models.CSharp
{
    public class Variables
    {
        public Variables()
        {
            // Variables
            int i;
            double z;
            decimal d;
            bool f;
            string s;

            //Initilization of variables
            i = 100;
            z = 100.00;
            d = decimal.Parse(i.ToString());
            f = false;
            s = "First string";

            //Declare & Initialize
            string c = "Second String";

            //var
            var number = 5;
        }
    }
}
