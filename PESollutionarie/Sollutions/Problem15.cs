using System;
using System.Collections.Generic;

namespace PESollutionarie.Sollutions
{
    class Problem15 : Problem
    {
        public override string Answer()
        {
            // Just a simple analysis combinatory problem.
            // For the example, we have to go in total 2 DOWN and 2 RIGHT
            // For the problem, 20 DOWN and 20 RIGHT
            //
            // Then for the example, permute the total with repetition: (2+2)!/(2! * 2!) = 6 distinct paths.
            // Then:
            // Answer = 40!/20!20! = A/B/B = answer
            // Let's try to calculate since C# doesn't provide a factorial function.
            // The trick to not get overflow is compute the expression only if necessary.
            // How to do that? Well one way may be factorize it first, and count the repeat for each prime number.
            Dictionary<int, int> A = FactorialDict(40);
            Console.WriteLine("A = " + PrintDictionary(A));
            Dictionary<int, int> B = FactorialDict(20);
            Console.WriteLine("B = " + PrintDictionary(B));
            Dictionary<int, int> C = DictDivide(A, B);
            Console.WriteLine("A/B = " + PrintDictionary(C));
            C = DictDivide(C, B);
            Console.WriteLine("A/B/B = " + PrintDictionary(C));

            return FactorialDictCompute(C).ToString();
        }

        // Returns an Dictionary where key is prime number, and value it's the repetition of it
        private Dictionary<int, int> FactorialDict(int n)
        {
            Dictionary<int, int> factorial = new Dictionary<int, int>();

            // Separate the 2 prime count from the loop for faster computation
            int count = 0, divider = 2;
            while (n / divider != 0)
            {
                count += n / divider;
                divider *= 2;
            }
            factorial[2] = count;

            for (int i = 3; i <= n; i+=2)
            {
                if (isPrime(i))
                {
                    count = 0;
                    divider = i;
                    // Counts the number of i¹, i², i³... that fits into n
                    while (n/divider != 0)
                    {
                        count += n / divider;
                        divider *= i;
                    }
                    factorial[i] = count;
                }
            }

            return factorial;
        }

        private string PrintDictionary(Dictionary<int,int> number)
        {
            string result = "";
            foreach (var kv in number)
            {
                result += kv.Key + "^" + kv.Value + " ";
            }
            return result;
        }

        private Dictionary<int, int> DictDivide(Dictionary<int, int> A, Dictionary<int, int> B)
        {
            Dictionary<int, int> C = new Dictionary<int, int>();
            foreach (var kv in A)
            {
                if (!C.ContainsKey(kv.Key))
                    C[kv.Key] = 0;
                C[kv.Key] += kv.Value;
                if (B.ContainsKey(kv.Key))
                    C[kv.Key] -= B[kv.Key];
            }
            // Add the remaining factors that only B may have
            foreach (var kv in B)
            {
                if (!A.ContainsKey(kv.Key))
                {
                    if (!C.ContainsKey(kv.Key))
                        C[kv.Key] = 0;
                    C[kv.Key] -= kv.Value;
                }
            }
            return C;
        }

        private Dictionary<int, int> DictMultiply(Dictionary<int, int> A, Dictionary<int, int> B)
        {
            Dictionary<int, int> C = new Dictionary<int, int>();
            foreach (var kv in A)
            {
                if (!C.ContainsKey(kv.Key))
                    C[kv.Key] = 0;
                C[kv.Key] += kv.Value;
                if (B.ContainsKey(kv.Key))
                    C[kv.Key] += B[kv.Key];
            }
            // Add the remaining factors that only B may have
            foreach (var kv in B)
            {
                if (!A.ContainsKey(kv.Key))
                {
                    if (!C.ContainsKey(kv.Key))
                        C[kv.Key] = 0;
                    C[kv.Key] += kv.Value;
                }
            }
            return C;
        }

        private long FactorialDictCompute(Dictionary<int, int> number)
        {
            long result = 1;
            foreach (var kv in number)
            {
                int factor = 1, times = kv.Value;
                while (times > 0)
                {
                    factor *= kv.Key;
                    times--;
                }
                result *= factor;
            }
            return result;
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


        public override void Solve()
        {
            Dictionary<int, int> A = FactorialDict(40);
            Dictionary<int, int> B = FactorialDict(20);
            //Dictionary<int, int> C = DictDivide(A, DictMultiply(B, B));
            Dictionary<int, int> C = DictDivide(DictDivide(A,B), B);
            return;
        }
    }
}
