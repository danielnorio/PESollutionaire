using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESollutionarie.Sollutions
{
    class Problem7 : Problem
    {
        public override string Answer()
        {
            // Nothing to see here. If some man found one bijection, closed formula between naturals and prime numbers
            // we would be doomed. Almost all security system and many features rely on prime numbers.
            long i = 3, primeCount = 1, until = 10001;
            for (; primeCount < until; i += 2)
            {
                if (isPrime(i))
                {
                    primeCount++;
                }
            }
            return (i-2).ToString();
        }

        public override void Solve()
        {
            Answer();
        }

        /// <summary>
        /// Test for naturals > 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private bool isPrime(long n)
        {
            if (n == 2) return true;
            else if (n % 2 == 0) return false;
            long max = Convert.ToInt64(Math.Sqrt(n));
            if (max % 2 == 0)
                max--;
            for (long i = max; i > 1; i -= 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
