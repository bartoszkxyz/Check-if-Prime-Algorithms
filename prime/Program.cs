using System;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
namespace prime
{
    internal class Program
    {
        //Deklaracja zmiennej instrumentacji i listy do sprawdzania
        static List<BigInteger> PrimeNumbs = new List<BigInteger>() { 101, 1009, 10091, 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 100914061333 };
        static ulong Instr;
        static double ElapsedSeconds;
        static List<bool> isPrime = new List<bool>();

        static void StoperPrzykladowy()
        {
            ElapsedSeconds = 0;
            long ElapsedTime=0,StartingTime,EndingTime;
                foreach (BigInteger number in PrimeNumbs)
                {
                        StartingTime = Stopwatch.GetTimestamp();
                        if (AlgorytmPrzykladowy(number))
                            Console.Write($"{number} \t Tak \t {Instr} \t ");
                        else
                            Console.Write($"{number} \t Nie \t {Instr} \t ");
                        EndingTime = Stopwatch.GetTimestamp();
                        ElapsedTime = EndingTime - StartingTime;
                        ElapsedSeconds = ElapsedTime * (1.0 / (12 * Stopwatch.Frequency));
                        Console.Write(ElapsedSeconds.ToString("F6")+"s \n");
                }
        }

        static void StoperPrzyzwoity()
        {
            ElapsedSeconds = 0;
            long ElapsedTime = 0, StartingTime, EndingTime;
            foreach (BigInteger number in PrimeNumbs)
            {
                StartingTime = Stopwatch.GetTimestamp();
                if (AlgorytmPrzyzwoity(number))
                    Console.Write($"{number} \t Tak \t {Instr} \t ");
                else
                    Console.Write($"{number} \t Nie \t {Instr} \t ");
                EndingTime = Stopwatch.GetTimestamp();
                ElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = ElapsedTime * (1.0 / (12 * Stopwatch.Frequency));
                Console.Write(ElapsedSeconds.ToString("F6") + "s \n");
            }
        }

        static void StoperOptymalny(List<BigInteger> Primes)
        {
            ElapsedSeconds = 0;
            long ElapsedTime = 0, StartingTime, EndingTime;
            foreach (BigInteger number in PrimeNumbs)
            {
                StartingTime = Stopwatch.GetTimestamp();
                if (AlgorytmOptymalny(number, Primes))
                    Console.Write($"{number} \t Tak \t {Instr} \t ");
                else
                    Console.Write($"{number} \t Nie \t {Instr} \t ");
                EndingTime = Stopwatch.GetTimestamp();
                ElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = ElapsedTime * (1.0 / (12 * Stopwatch.Frequency));
                Console.Write(ElapsedSeconds.ToString("F6") + "s \n");
            }
        }
        //funkcja generująca tablicę z liczbami pierwszymi od 0 do sqrt(ostatniej liczby testowej)
        static List<BigInteger> Generate(BigInteger Num) 
        {
            for (int i = 0; i <= Num + 1; i++) isPrime.Add(true);
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i <= Num; i++)
            {
                if (isPrime[i] == true)
                {
                    for(int j = i + i;j <= Num-1; j += i)
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

        //Algorytm Przykładowy + instrumentacja
        static bool AlgorytmPrzykladowy(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
            {
                Instr = 1;
                for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    Instr++;
                    if (Num % u == 0) return false;
                }
            }
            return true;
        }
        //Algorytm "przyzwoity" + instrumentacja
        static bool AlgorytmPrzyzwoity(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            //else if (Num % 3 == 0) return false;
            else
            {
                Instr = 1;
                for (BigInteger u = 3; u * u <= Num; u += 2)
                {
                    Instr++;
                    if (Num % u == 0 || Num % (u + 2) == 0) return false;
                }
                return true;
            }
        }

        //Algorytm optymalny + instrumentacja
        static bool AlgorytmOptymalny(BigInteger Num, List<BigInteger> list)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
                Instr = 1;
                for (int u = 0; list[u] * list[u] <= Num; u++)
                {
                    Instr++;
                    if (Num % list[u] == 0) return false;
                }
            return true;
        }
        /*        static bool AlgorytmOptymalnyInstrumentacja(BigInteger Num)
                {
        }*/
        static void Main(string[] args)
        {
            //PrimeNumbs.Add(BigInteger.Parse("18870929470561300001893"));
            int x = Convert.ToInt32(Math.Sqrt((long)PrimeNumbs[PrimeNumbs.Count - 1]));
            var Primes = Generate(x);


            // tests
            Console.WriteLine("Liczba \t CzyPierwsza \t Instrumentacja \t Czas ");
            //Example test
            Console.WriteLine("-- Example Test--");
            StoperPrzykladowy();
            //Wywołanie A Przyzwoitego
            Console.WriteLine("-- Acceptable Test --");
            StoperPrzyzwoity();
            //Wywołanie A Optymalnego
            Console.WriteLine("-- Optimal Test --");
            StoperOptymalny(Primes);
        }
    }
}
