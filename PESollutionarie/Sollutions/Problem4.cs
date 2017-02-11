using System;

namespace PESollutionarie.Sollutions
{
    class Problem4 : Problem
    {
        public override string Answer()
        {
            // Palindromo de 4 dig: abba. Como (a+b)-(b+a)=0 é múltiplo de 11. Se não sabe essa regra:
            // Numero abba = 1000a+100b+10b+a=1001a+110b=11(91a+10b)
            // Palidromo de 6 dig: abccba. Como (a+c+b)-(b+c+a) = 0, é múltiplo de 11.
            // XYZ * ABC <= 999 * 999 portanto o maior palindromo deve ter no max 6 digitos
            // O menor produto de 3 digitos tem no minimo 5 digitos: 100 * 100 = 10000
            // 300 * 400 já tem 6 dig então é razoavel acreditar que o palindromo que buscamos tem de fato 6 dig.
            // Então um dos membros de 3 digitos tem o fator de 11. O próximo fator tem mais q 1 dig, pois 11*9=99
            // Porém é menor que 91, pois 11*91=1001
            // É então um número entre 10 e 90. 
            //
            // Conclusão: Então basta testar para cada palindromo se ele é divisivel por 10 a 90. Se sim,
            // Ver se o segundo membro tem 3 digitos isto é, palindromo/ ((1ºMembro)*1000) = 0 (divisao inteira)
            // É sensato começar os digitos todos com 9 é diminuir o primeiro membro como 999, 998, 997 etc

            for (int a = 9; a > 0; a--)
            {
                for (int b = 9; b > -1; b--)
                {
                    for (int c = 9; c > -1; c--)
                    {
                        int pal = 100000 * a + 10000 * b + 1000 * c + 100 * c + 10 * b + a;
                        for (int k = 10; k < 90; k++)
                        {
                            if (pal % k == 0 && pal / (11 * k * 1000) == 0)
                            {
                                Console.WriteLine("Palindromo encontrado: {0}{1}Produto: {2}x{3}", pal, Environment.NewLine, 11*k, pal/(11*k));
                                return pal.ToString();
                            }

                        }
                    }
                }
            }

            return "";
        }

        public override void Solve()
        {
            for (int a = 9; a > 0; a--)
            {
                for (int b = 9; b > -1; b--)
                {
                    for (int c = 9; c > -1; c--)
                    {
                        int pal = 100000 * a + 10000 * b + 1000 * c + 100 * c + 10 * b + a;
                        for (int k = 10; k < 90; k++)
                        {
                            if (pal % k == 0 && pal / (11 * k * 1000) == 0)
                            {
                                return;
                            }

                        }
                    }
                }
            }

            return;
        }
    }
}
