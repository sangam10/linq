using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linq
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Phone[] Phones { get; set; }
    }
}