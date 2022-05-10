using System;
using System.Collections.Generic;
using System.Numerics;
namespace prime
{
    internal class Program
    {
        static ulong DivsNum;
        static List<bool> isPrime = new List<bool>();
        static List<BigInteger> Generate(int Num) 
        {
            for (int i = 0; i <= Num + 1; i++) isPrime.Add(true);
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i <= Num; i++)
            {
                if (isPrime[i] == true)
                {
                    for(int j = i + i;j <= Num; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            isPrime[2] = false;

            List<BigInteger> list = new List<BigInteger>();
            for(int i = 0; i <=Num; i++)
            {
                if (isPrime[i]==true)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        static bool AlgorytmPrzykladowy(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
            {
                DivsNum = 1;
                for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    DivsNum++;
                    if (Num % u == 0) return false;
                }
            }
            return true;
        }

        /*static bool AlgorytmPrzykładowyInstrumentacja(BigInteger Num)
        {
}*/
        static bool AlgorytmLepszy(BigInteger Num)
        {
            DivsNum=4;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else if (Num % 3 == 0) return false;
            else
            {
                DivsNum = 1;
                for (BigInteger u = 5; u * u <= Num; u += 6)
                {
                    DivsNum++;
                    if (Num % u == 0 || Num % (u + 2) == 0) return false;
                }
                return true;
            }
        }
        /*static bool AlgorytmLepszyInstrumentacja(BigInteger Num)
        {
}*/
        static bool AlgorytmJeszczeLepszy(BigInteger Num, List<BigInteger> list)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
                DivsNum = 1;
                for (int u = 0; list[u] * list[u] <= Num; u++)
                {
                    DivsNum++;
                    if (Num % list[u] == 0) return false;
                }
            return true;
        }
        /*        static bool AlgorytmJeszczeLepszyInstrumentacja(BigInteger Num)
                {
        }*/
        static void Main(string[] args)
        {
            var PrimeNumbs = new List<BigInteger>() { 101, 1009, 10091, 100913, 1009139, 10091401, 100914061 };//, 1009140611, 10091406133, 100914061337, 100914061339 };
            //PrimeNumbs.Add(BigInteger.Parse("18870929470561300001893"));
            var Primes = Generate(200);


            // tests

            //Example test
            Console.WriteLine("-- Example --");
            foreach (BigInteger number in PrimeNumbs)
            {
                DivsNum = 0;
                if (AlgorytmPrzykladowy(number))
                    Console.WriteLine("yep " + DivsNum);
                else
                    Console.WriteLine("nay " + DivsNum);
            }

            //Primality test 
            Console.WriteLine("-- Primality --");
            foreach (BigInteger number in PrimeNumbs)
            {
                Console.Write(number);
                DivsNum = 0;
                if (AlgorytmLepszy(number))
                    Console.Write("= yep "+DivsNum);
                else
                    Console.Write("= nay "+DivsNum);
                Console.Write("\n");
            }
            
            //Primality test 2
            Console.WriteLine("-- Primality2 --");
            foreach (BigInteger number in PrimeNumbs)
            {
                Console.Write(number);
                DivsNum = 0;
                if (AlgorytmJeszczeLepszy(number, Primes))
                    Console.Write("= yep " + DivsNum);
                else
                    Console.Write("= nay " + DivsNum);
                Console.Write("\n");
            }
        }
    }
}
