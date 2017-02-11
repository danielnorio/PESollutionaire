namespace PESollutionarie.Sollutions
{
    class Problem2 : Problem
    {
        public override string Answer()
        {
            // Background matemático: https://en.wikipedia.org/wiki/Recurrence_relation#Solving_homogeneous_linear_recurrence_relations_with_constant_coefficients
            // Vou tentar usar as  seguintes regras de soma:
            // I - impar
            // P - par
            // I + I = par
            // P + P = par
            // I + P = impar

            // Então se temos f(n-2) I, f(n-1) P, f(n) é I e f(n+1) é I, e então f(n+2) é P e pronto repetimos o padrão
            // Temos então o padrão de repetição IPI-IPI-IPI...
            // Então queremos somar os termos 1º, 4º, 7ª (contando a partir de 0º)... isto é termos de ordem 1+3n, n=0,1,2,3,4...
            // f(1+3n) = f(3n-1)+f(3n), n=1,2,3..
            //
            // f(3(n+1))=f(2+3n)+f(3n+1)  .... ok não achei nada..
            // Visto que os valores iniciais são 1 e 2 e não 1 e 1, não temos a Fib clássica, então não custa nada
            // tentar ver se a expressão fechada é mais bonita
            // f(n) = f(n-1)+f(n-2) , f(0)=1, f(1)=2, n >= 2
            // Pol caracteristico: x²= x+1
            // Raizes: r1 = [1+sqrt(5)]/2, r2 = [1-sqrt(5)]/2
            // Logo: f(n)= C1 r1^n + C2 r2^n
            // f(0)= 1 = C1+C2
            // f(1)= 2 = C1 [1+sqrt(5)]/2 + C2 [1-sqrt(5)]/2 
            // Ahh foda-se

            int a = 1;
            int b = 2;
            int sum = 0;
            while (b < 4000000)
            {
                sum = b % 2 == 0 ? sum+b : sum;
                int temp = a;
                a = b;
                b = temp + a;
            }   
            return sum.ToString();
        }

        public override void Solve()
        {
            Answer();
        }
    }
}
