using System;
using System.Diagnostics;
using System.Threading;

namespace PESollutionarie
{
    abstract class Problem : IProblem
    {
        /// <summary>
        /// Aqui você deve implementar a solução para o problema. 
        /// <para>Este método não será usado para profiling, então adicione mensagens no Console como quiser.</para>
        /// </summary>
        public abstract string Answer();

        public abstract void Solve();

        /// <summary>
        /// Aqui você deve implementar a solução otimizada, para o problema. 
        /// <para>Adicione apenas o algoritmo e nada mais. Este método é usado para o profiling.</para>
        /// </summary>
        public double Profile()
        {
            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // warm up 
            Solve();

            var watch = new Stopwatch();

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Start();
            for (int i = 0; i < 20; i++)
            {
                Solve();
            }
            watch.Stop();
            Console.WriteLine(" Tempo total de {0} ms para 20 iterações", watch.Elapsed.TotalMilliseconds);
            return (watch.Elapsed.TotalMilliseconds / 20);
        }
    }
}
