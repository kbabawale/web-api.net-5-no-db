using System;
using System.Collections.Generic;

namespace halogen
{
    public class ResponseClass
    {
        public List<int> evenNumbers { get; set; }
        public List<int> oddNumbers { get; set; }
        public List<int> numbersDivisibleBy3 { get; set; }
        public List<int> numbersDivisibleBy5 { get; set; }
        public List<int> numbersDivisibleBy7 { get; set; }
        public int mode { get; set; }
        public double mean { get; set; }
        public double average { get; set; }
        public decimal median { get; set; }
        public int sum { get; set; }
    }
}
