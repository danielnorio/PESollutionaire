using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESollutionarie.Sollutions
{
    class Problem6 : Problem
    {
        public override string Answer()
        {
            // Mathematical background: https://en.wikipedia.org/wiki/Arithmetic_progression
            // Optional:    one thing that in my country they call "Arithmetic progression of higher order"
            //              Didn't found the correspondent term in english
            //________________________________________________________________________________________
            // So what's is an arithmetic progression of higher order?
            // It is a sequence which the differences between the terms is an A.P., 
            // else the difference of difference is, and so on.
            // So the common A.P. is an arithmetic progression of 1st order.
            // The sequence: 1, 2, 4, 7, 11, 16, 22, 29... is an arithmetic progression of 2st order.
            // The sequence: 5, 6, 8, 12, 19, 30, 56, 78, 107... is an arithmetic progression fo 3rd order.
            //
            // Exists a theorem that says that an A.P. of order n can be described as a polynomium of degree n
            // and it's sum by a polynomium of degree (n+1).
            // 
            // Then 1²,2²,3²,4²,5²,6²,7² = 1, 4, 9, 16, 25, 36, 49 and the differences: 3, 5, 7, 9, 11, 13 is an A.P., hence
            // this sequence may be described by a polynomium of degree 2, and it's sum as one of degree 3.
            //
            // In fact is f(n)=n², n = 1,2,3..
            //
            // It's sum actually appears quite often in some literatures, it can be used to prove some elementaries geometry
            // formulas. It is: F(n)=n(n+1)(2n+1)/6.
            //
            // But since i don't remember how to prove the theorem of A.P. i will derive that expression:
            //________________________________________________________________________________________________
            // Derivation:
            //
            // Let Sum of g(i) with i between 1 to n be written as S {g(i)} 
            // Let Sum of g(i) with i between x to y be written as S {x, y, g(i)} 
            //
            // Then S{i³}+(n+1)³ = S{1,n+1,i³} = S{0, n, (i+1)³}= 1 + S{(i+1)³} = 1+S{i³}+3S{i²}+3S{i}+S{1}
            // Hence: (n+1)³ = 1 + 3S{i²}+3S{i}+S{1}   (I)
            // - Evaluation of S{i}:
            //      S{i} --> i is an A.P (1, 2, 3, 4..n) then it's know that S{i}=n(n+1)/2. Actually you can still use the 
            //   same procedure above to obtain this result.
            // - Evaluation of S{1}:
            //       Sum of constant: S{1}= 1 * (n+1-1) = n
            //
            // Then: (n+1)³ = 1 +3S{i²}+3n(n+1)/2+n  <---> 3 S{i²} = (n+1)³-1-3n(n+1)/2-n = 1/2 [2n³+6n²+6n+2 -2 -3n²-3n-2n]
            // 3 S{i²} = 1/2 [2n³+3n²+n] = 1/2 n (2n²+3n+1) = 1/2 n(2n+1)(n+1)
            // Finally: S{i²} = n(n+1)(2n+1)/6
            //
            //
            // For the problem we must obtain (S{i})²-S{i²} = n²(n+1)²/4 - (2n³+3n²+n)/6 = 1/12 n (n + 1) (3 n + 2) (n - 1)
            long n = 100;
            return (n*(n + 1)*(3*n + 2)*(n - 1)/12).ToString();
        }

        public override void Solve()
        {
            Answer();
        }
    }
}
