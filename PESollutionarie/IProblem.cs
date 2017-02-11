namespace PESollutionarie
{
    interface IProblem
    {
        //Cálculo da resposta
        string Answer();

        //Mesmo algoritmo (use para profiling)
        void Solve();

        //Método que executa 100 vezes o Solve()
        double Profile();

    }
}
