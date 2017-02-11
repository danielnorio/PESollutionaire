using System;

namespace PESollutionarie.Sollutions
{
    class Problem3 : Problem
    {
        public override string Answer()
        {
            // O maior fator primo de um número não primo é menor que sua raiz quadrada
            // Seja n não primo, então n > 3 (pelo menos) e podemos escrever n=a*b tal que
            // 1 < a <= b < n. Agora se b >= a, então ab >= a² <---> n >= a² ---> a <= sqrt(n).
            // Então temos que é no máximo, sqrt(n)

            long numeroGrande = 600851475143;
            long max = Convert.ToInt64(Math.Sqrt(numeroGrande));
            // Pega o próximo ímpar
            if (max % 2 == 0)
                max--;
            // Checa de 2 em 2 por um divisor
            for (long i = max; i > 1; i -=2)
            {
                if (numeroGrande % i == 0)
                    if (ehPrimo(i))
                        return i.ToString(); 
            }
            return "";
        }
        
        private bool ehPrimo(long n)
        {
            if (n == 2) return true;
            else if (n % 2 == 0) return false;
            long max = Convert.ToInt64(Math.Sqrt(n));
            if (max % 2 == 0)
                max--;
            for (long i = max; i > 2; i -= 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public override void Solve()
        {
            Answer();
        }
    }
}
