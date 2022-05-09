using System;
using System.Collections.Generic;
using System.Numerics;
namespace prime
{
    internal class Program
    {
        static ulong DivsNum;
        static bool AlgorytmPrzykładowy(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }
        /*static bool AlgorytmPrzykładowyInstrumentacja(BigInteger Num)
        {
}
        static bool AlgorytmLepszy(BigInteger Num)
        {
}
        static bool AlgorytmLepszyInstrumentacja(BigInteger Num)
        {
}
        static bool AlgorytmJeszczeLepszy(BigInteger Num)
        {
}
        static bool AlgorytmJeszczeLepszyInstrumentacja(BigInteger Num)
        {
}*/
        static void Main(string[] args)
        {
            List<BigInteger> PrimeNumbs = new List<BigInteger>() { 101, 1009, 10091, 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 100914061339 };
            PrimeNumbs.Add(BigInteger.Parse("18870929470561300001893"));


            //BigInteger[] PrimeNums = new BigInteger[]{ 101, 1009, 10091, 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 100914061339 };
            
            // testy
            foreach (BigInteger number in PrimeNumbs)
            {
                if(AlgorytmPrzykładowy(number))
                Console.WriteLine("yep");
                else
                Console.WriteLine("nay");
            }
        }
    }
}
