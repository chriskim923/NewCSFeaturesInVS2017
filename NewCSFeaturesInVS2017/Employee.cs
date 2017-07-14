using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCSFeaturesInVS2017
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsManager { get; set; } = false;
        public int YearsWorked { get; set; } = 0;
    }
}
