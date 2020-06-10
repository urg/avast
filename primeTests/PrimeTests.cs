using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace avast.Tests
{
    [TestClass]
    public class Prime_IsPrimeShould
    {
        private readonly Prime _prime;

        public Prime_IsPrimeShould()
        {
            _prime = new Prime();
        }

        [TestMethod]
        public void GetPrimes_Count_ShouldReturnCount()
        {
            for (var i = 1; i < 100; i++) {
                var result = _prime.GetPrimes(i);
                Assert.AreEqual(i, result.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPrimes_Input0_ShouldThrowException()
        {
            Console.WriteLine("test");
            var result = _prime.GetPrimes(0);
        }

        [DataTestMethod]
        [DataRow(1, new int[] {2})]
        [DataRow(2, new int[] {2, 3})]
        [DataRow(3, new int[] {2, 3, 5})]
        [DataRow(4, new int[] {2, 3, 5, 7})]
        [DataRow(5, new int[] {2, 3, 5, 7, 11})]
        [DataRow(6, new int[] {2, 3, 5, 7, 11, 13})]
        [DataRow(7, new int[] {2, 3, 5, 7, 11, 13, 17})]
        [DataRow(8, new int[] {2, 3, 5, 7, 11, 13, 17, 19})]
        [DataRow(9, new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23})]
        [DataRow(10, new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29})]
        public void GetPrimes_KnownData_ShouldBeCorrect(int numberOfPrimes, int[] primes)
        {
            var result = _prime.GetPrimes(numberOfPrimes);
            var expected = new List<int>(primes);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
