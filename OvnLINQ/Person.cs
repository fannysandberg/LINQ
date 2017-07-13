using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvnLINQ
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int WorkPlaceID { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Age}, {WorkPlaceID}";
        }
    }
}
