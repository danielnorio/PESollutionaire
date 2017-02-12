using System;

namespace PESollutionarie.Sollutions
{
    class Problem9 : Problem
    {
        public override string Answer()
        {
            // From triangle inequality a + b >= c <-> a+b+c = 1000 >= 2c <-> c <= 500. 
            // Then a, b < 500.
            // Since c may be much greater, let's start it descending
            // And a,b ascending
            for (int a = 1; a < 500; a++)
            {
                for (int b = 1; b < 500; b++)
                {
                    for (int c = 500; c > 0; c--)
                    {                          
                        if ((a + b + c == 1000) && (a * a + b * b == c * c))
                        {
                            Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);
                            return (a * b * c).ToString();
                        }
                    }
                }
            }
            return "";
        }

        public override void Solve()
        {
            for (int a = 1; a < 500; a++)
            {
                for (int b = 1; b < 500; b++)
                {
                    for (int c = 500; c > 0; c--)
                    {
                        if ((a + b + c == 1000) && (a * a + b * b == c * c))
                        {
                            return;
                        }
                    }
                }
            }
            return;
        }
    }
}
