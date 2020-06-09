using System;
using System.Collections.Generic;
using System.Linq;

namespace avast
{
    public class Prime
    {
        /**
         * 
         */
        public List<int> GetPrimes (int numberOfPrimes)
        {
            // prime gap analysis (https://en.wikipedia.org/wiki/Prime_gap) indicates avg tends towards e^(-k). Would need 
            // to factorize this and my maths are not good enough. squaring the number appears to give a high enough bound
            // however, as we're going significantly past the limit, the performace saving of GetSieveOfEratosthenes
            // becomes less and so IncrementalSieveOfEratosthenes becomes more appealing
            // return GetSieveOfEratosthenes(numberOfPrimes * numberOfPrimes).Take(numberOfPrimes);

            return this.IncrementalSieveOfEratosthenes(numberOfPrimes);
        }

        /**
         * Implementation for IncrementalSieveOfEratosthenes based on code article
         * https://www.codevamping.com/2019/01/incremental-sieve-of-eratosthenes/ pseduoalgorithm
         */
        public List<int> IncrementalSieveOfEratosthenes (int numberOfPrimes)
        {
            if (numberOfPrimes < 2) {
                throw new ArgumentException("IncrementalSieveOfEratosthenes must be >= 2");
            }

            var set = new Dictionary<int, int>();

            var i = 2;
            while (set.Count < numberOfPrimes) {
                var isPrime = true;
                foreach (var prime in set.Keys.ToList()) {
                    while (set[prime] < i) {
                        set[prime] += prime;
                    }
                    if (set[prime]== i) {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) {
                    set.Add(i, i);
                }

                i++;
            }

            var results = set.Select(item => item.Key).ToList();
            return results;
        }
        
        /**
         * Implementation for GetSieveOfEratosthenes based on Wikipedia pseduoalgorithm
         * https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
         */
        public List<int> GetSieveOfEratosthenes (int limit)
        {
            if (limit < 2) {
                throw new ArgumentException("GetSieveOfEratosthenes must be >= 2");
            }

            var set = new Dictionary<int, bool>();
            for (var i = 2; i <= limit; i++) {
                set.Add(i, true);
            }

            for (var i = 2; i <= Math.Floor(Math.Sqrt(limit)); i++) {
                if (set[i]) {
                    for (var j = i * i; j < limit; j += i) {
                        set[j] = false;
                    }
                }
            }

            var results = set.Where(item => item.Value).Select(item => item.Key).ToList();
            return results;
        }
    }
}
