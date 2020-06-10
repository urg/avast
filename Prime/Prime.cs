using System;
using System.Collections.Generic;
using System.Linq;

namespace avast
{
    public class Prime
    {
        public List<int> GetPrimes (int numberOfPrimes)
        {
            // prime gap analysis (https://en.wikipedia.org/wiki/Prime_gap) indicates avg tends towards e^(-k). Would need 
            // to factorize this, but also is an average and so would need to know max bound. 
            // Squaring the number appears to give a high enough bound
            // however, as we're going significantly past the limit, the performace saving of GetSieveOfEratosthenes
            // becomes less and so IncrementalSieveOfEratosthenes becomes more appealing
            // return GetSieveOfEratosthenes(numberOfPrimes * numberOfPrimes).Take(numberOfPrimes);

            return this.IncrementalSieveOfEratosthenes(numberOfPrimes);
        }

        /**
         * Implementation for IncrementalSieveOfEratosthenes based on code article
         * https://www.codevamping.com/2019/01/incremental-sieve-of-eratosthenes/ pseduoalgorithm
         */
        private List<int> IncrementalSieveOfEratosthenes (int numberOfPrimes)
        {
            if (numberOfPrimes < 1) {
                throw new ArgumentOutOfRangeException("IncrementalSieveOfEratosthenes must be >= 1");
            }

            // Key is the prime, Value is a Multiple of the Prime closest to current count
            var incrementalSieve = new Dictionary<int, int>();

            var i = 2;
            while (incrementalSieve.Count < numberOfPrimes) {
                var isPrime = true;
                foreach (var prime in incrementalSieve.Keys.ToList()) {
                    while (incrementalSieve[prime] < i) {
                        incrementalSieve[prime] += prime;
                    }

                    if (incrementalSieve[prime]== i) {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) {
                    incrementalSieve.Add(i, i);
                }

                i++;
            }

            var results = incrementalSieve.Select(item => item.Key).ToList();
            return results;
        }
        
        /**
         * Implementation for GetSieveOfEratosthenes based on Wikipedia pseduoalgorithm
         * https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
         */
        private List<int> GetSieveOfEratosthenes (int limit)
        {
            if (limit < 2) {
                throw new ArgumentException("GetSieveOfEratosthenes must be >= 2");
            }

            // Key is the possible prime; Value indicates if the Key is prime or not
            var sieve = new Dictionary<int, bool>();
            for (var i = 2; i <= limit; i++) {
                sieve.Add(i, true);
            }

            for (var i = 2; i <= Math.Floor(Math.Sqrt(limit)); i++) {
                if (sieve[i]) {
                    for (var j = i * i; j < limit; j += i) {
                        sieve[j] = false;
                    }
                }
            }

            var results = sieve.Where(item => item.Value).Select(item => item.Key).ToList();
            return results;
        }
    }
}
