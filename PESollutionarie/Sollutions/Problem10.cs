using System;

namespace PESollutionarie.Sollutions
{
    class Problem10 : Problem
    {
        public override string Answer()
        {
            // Just sum it up without great optimizations. I'm lazy to implement the 6k+-1 property of prime numbers.
            long sum = 2, max = 2000000;
            for (long i = 3; i < max; i+=2)
            {
                if (isPrime(i)) sum += i;
            }
            return sum.ToString();
        }

        public override void Solve()
        {
            Answer();
        }
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
