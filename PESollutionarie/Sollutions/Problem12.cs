using System;

namespace PESollutionarie.Sollutions
{
    class Problem12 : Problem
    {
        public override string Answer()
        {
            int triangular, n = 2;
            // Seleciona cada um dos triangulares
            while (true)
            {
                triangular = n * (n + 1) / 2;
                //Console.WriteLine("Testando " + n + "º triangular: " + triangular);
                int numDivisors = numDivisores(triangular);
                //Console.WriteLine("O " + n + "º triangular tem " + numDivisors + " divisores.");
                if (numDivisors > 500)
                {
                    Console.WriteLine("" + n + "º triangular: " + triangular);
                    Console.WriteLine("O " + n + "º triangular tem " + numDivisors + " divisores.");
                    return triangular.ToString();
                }
                else n++;
            }
        }

        public override void Solve()
        {
            int triangular, n = 2;
            // Seleciona cada um dos triangulares
            while (true)
            {
                triangular = n * (n + 1) / 2;
                int numDivisors = numDivisores(triangular);
                if (numDivisors > 500)
                    return;
                else n++;
            }
        }


        private int numDivisores(int numero)
        {
            int numFatores = 1, fator = 2, repeticao = 0;
            while (numero != 1)
            {
                //Se for divisivel decompõe e conta a repetição do fator
                if (numero % fator == 0)
                {
                    repeticao++;
                    numero /= fator;
                }
                else
                {
                    if (repeticao > 0)
                    {
                        numFatores *= (repeticao + 1);
                        repeticao = 0;
                    }
                    fator++;
                }
            }
            numFatores *= (repeticao + 1);
            return numFatores;
        }
        
    }
}
