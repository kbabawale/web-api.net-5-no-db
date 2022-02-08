using System;
using System.Collections.Generic;
using System.Linq;

namespace halogen
{
    public class ExcelMethodClass
    {
        public ExcelMethodClass()
        {
        }

        public static List<int> getEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();

            foreach (var i in numbers)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(i);
                }
            }

            return evenNumbers;
        }

        public static List<int> getOddNumbers(List<int> numbers)
        {
            List<int> oddNumbers = new List<int>();

            foreach (var i in numbers)
            {
                if (i % 2 != 0)
                {
                    oddNumbers.Add(i);
                }
            }

            return oddNumbers;
        }

        public static List<int> getNumbersDivisibleBy3(List<int> numbers)
        {
            List<int> Numbers = new List<int>();

            foreach (var i in numbers)
            {
                if (i % 3 == 0)
                {
                    Numbers.Add(i);
                }
            }

            return Numbers;
        }

        public static List<int> getNumbersDivisibleBy5(List<int> numbers)
        {
            List<int> Numbers = new List<int>();

            foreach (var i in numbers)
            {
                if (i % 5 == 0)
                {
                    Numbers.Add(i);
                }
            }

            return Numbers;
        }

        public static List<int> getNumbersDivisibleBy7(List<int> numbers)
        {
            List<int> Numbers = new List<int>();

            foreach (var i in numbers)
            {
                if (i % 7 == 0)
                {
                    Numbers.Add(i);
                }
            }

            return Numbers;
        }

        public static int findMode(List<int> numbers)
        {
            int Numbers = numbers.GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).Select(x => (int)x.Key).FirstOrDefault();

            return Numbers;
        }

        public static decimal findMedian(List<decimal> xs)
        {
            xs.Sort();
            return xs[xs.Count / 2];
        }
    }
}
