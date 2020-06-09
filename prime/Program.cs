using System;
using System.Collections.Generic;
using ConsoleTables;
using System.Linq;

namespace avast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application will generate a multiplication table of prime numbers.");
            Console.WriteLine("Please enter the number of prime numbers you wish to see: ");
            var n = Convert.ToInt32(Console.ReadLine());

            var prime = new Prime();
            var primes = prime.GetPrimes(n + 1);
            string[] cols = { "Primes" };
            var table = new ConsoleTable(cols.Concat(primes.Select(i => i.ToString()).ToArray()).ToArray());
            foreach (var i in primes) {
                var row = new List<string>();
                row.Add(i.ToString());
                foreach (var j in primes) {
                    row.Add((i * j).ToString());
                }
                table.AddRow(row.ToArray());
            }
            table.Write();
        }
    }
}
