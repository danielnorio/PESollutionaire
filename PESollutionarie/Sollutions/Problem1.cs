namespace PESollutionarie.Sollutions
{
    class Problem1 : Problem
    {
        public override string Answer()
        {
            // Background matemático:   Básico: https://en.wikipedia.org/wiki/Arithmetic_progression
            //                          Extra: https://en.wikipedia.org/wiki/Inclusion%E2%80%93exclusion_principle
            //
            // Este é um problema que envolve os conceitos de Progressão Aritmética e Intersecção de conjuntos.
            // Para identificar isso, temos as seguintes pistas no enunciado:
            //      - " that are multiples of 3 or 5" : Temos sequências de múltiplos, então é o conceito de PA
            //      - "Find the sum of all the multiples" : Soma dos múltiplos, então precisamos de soma de PA
            //
            // Agora a questão dos conjuntos entá no fato que temos duas PAs envolvidas; dos múltiplos de 3 e dos múltiplos de 5
            // Calcular cada uma das somas separadas pode ser feito pela fórmula: Sn=(a_1+a_n)*n/2
            // E um termo qualquer da PA é a_n = a_1+(n-1)r
            // 
            //
            // Mas quando calculamos a soma da PA de 3, estamos considerando os que fazem intersecção com a PA de 5 e os que não fazem
            // E  quando calculamos da soma da PA de 5, estamos considerando os que fazem intersecção com a PA de 3 e os que não fazem
            // Então calculamos a intersecção 2 vezes. Se queremos de ambos múltiplos portanto devemos subtrair a soma da intersecção (PA de 15)
            // Isso pode ser expresso pela fórmula do número de elementos da união: n(A U B) = n(A) + n(B) - n(A intersec B)
            // Essa fórmula é um caso particular do Príncipio da Inclusão e Exclusão. Se no problema fossem múltiplos de 3, 5 e 7 valeria
            // a pena a consulta desse príncipio.
            //
            // Ok então vamos montar nossa expressão final:
            //
            // Obs.. não temos "n" pois a_n é o maior número da PA < 1000
            // Pelo fato que divisão inteira em programação retorna arredondado para baixo, podemos achar o n para cada PA dividindo pela razão,
            // desde que o resto da divisão seja diferente de 0 (pois nesse caso, 1000 é múltiplo de r e ai o a_n calculado é 1000, que não é menor que 1000).
            // Neste caso basta então subtrair 1 do n calculado para pegar o múltiplo imediatamente menor que 1000.
            // Sejam:   a(n1): PA de 3
            //          b(n2): PA de 5
            //          c(n3): PA de 15
            // No caso que r=a_1, simplificamos: a_n = a_1 + (n-1)a_1 = n*a_1
            // Assim, a soma é: Sa(n) = (a_1+n*a_1)n/2=a_1 * (n+1) * n /2
            //
            // Então:
            //
            // Resposta = Sa(n1)+Sb(n2)-Sc(n3) = 3 * (n1+1) * n1 /2 + 5 * (n2+1) * n2 /2 - 15 * (n3+1) * n3 /2
            //

            int n1 = 1000 % 3 == 0 ? 1000 / 3 - 1 : 1000 / 3;
            int n2 = 1000 % 5 == 0 ? 1000 / 5 - 1 : 1000 / 5;
            int n3 = 1000 % 15 == 0 ? 1000 / 15 - 1 : 1000 / 15;

            int resposta = (3 * (n1 + 1) * n1 + 5 * (n2 + 1) * n2 - 15 * (n3 + 1) * n3) / 2;

            return resposta.ToString();
        }

        public override void Solve()
        {
            Answer();
        }
    }
}
