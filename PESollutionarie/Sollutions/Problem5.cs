using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESollutionarie.Sollutions
{
    class Problem5 : Problem
    {
        public override string Answer()
        {
            // Essa questão é bem solucionável só por matemática, por construção de tal número:
            //
            // Queremos um número que seja divisível por 1 até 20. Como 20 é pequeno façamos desse jeito:
            // Tem que ter pelo menos só primos, a menor quantia possível
            // Então 2, 3, 5, 7, 11, 13, 17, 19 são fatores ---> N = 2*3*5*7*11*13*17*19... 
            // 4 não é divisor, então adicionamos um fator 2 ---> N = 2*2*3*5*7*11*13*17*19...
            // 6 já é divisor, pois temos 2 e 3
            // 8 não é ----> N = 2*2*2*3*5*7*11*13*17*19...
            // 9 não é ----> N = 2*2*2*3*3*5*7*11*13*17*19...
            // 10 já é pois temos 2 e 5
            // 12 já é pois temos 4 e 3
            // 14 já é
            // 15 já é
            // 16 não é pois falta um fator 2----> N = 2*2*2*2*3*3*5*7*11*13*17*19...
            // 18 já é pois temos 9 e 2
            // 20 já é
            // Pronto a resposta vai ser: 2*2*2*2*3*3*5*7*11*13*17*19
            // Tá fera, mas como faríamos se fosse pra ser divisivel até 100 por exemplo?
            // Bom ai é so notar que so acrescentamos um fator a mais nos expoentes de um primo: 2², 2³, 2^4, 3²...
            // Então ai é só verificar o maximo expoente de cada primo que é menor que 100, e invés de adicionar 2
            // adicionar 2^6 por exemplo:
            // 2 --> 2^6 é o max menor que 100 ---> N = 2^6
            // 3 --> 3^4 é o max menor que 100 ---> N = 2^6 * 3^4
            // 5 --> 5^2 é o max menor que 100 ---> N = 2^6 * 3^4 * 5^2
            // 7 --> 7^2 ---> N = 2^6 * 3^4 * 5^2 * 7^2
            // 11 --> 11 ---> N = 2^6 * 3^4 * 5^2 * 7^2 * 11
            // Como 11 > 7 a partir daqui não há necessidade de checar os expoentes, basta adicionar direto.
            // return (2 * 2 * 2 * 2 * 3 * 3 * 5 * 7 * 11 * 13 * 17 * 19).ToString();
            int ate = 20;
            int resultado = 1;
            for (int i = 2; i <= ate; i++)
            {
                if (ehPrimo(i))
                {
                    int exp = i;
                    while (i*exp <= ate) exp = i * exp;
                    resultado *= exp;
                }
            }
            return resultado.ToString();
        }

        public override void Solve()
        {
            Answer();
        }

        private bool ehPrimo(int n)
        {
            if (n == 2) return true;
            else if (n % 2 == 0) return false;
            if (n == 2) return true;
            else if (n % 2 == 0) return false;
            int max = Convert.ToInt32(Math.Sqrt(n));
            if (max % 2 == 0)
                max--;
            for (int i = max; i > 1; i -= 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
