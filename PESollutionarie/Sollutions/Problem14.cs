using System;
using System.Collections.Generic;

namespace PESollutionarie.Sollutions
{
    class Problem14 : Problem
    {
        private Dictionary<long, int> paths = new Dictionary<long, int>();

        public Problem14()
        {
            // Add 1 to the paths
            paths.Add(1, 1);
        }
        public override string Answer()
        {
            int maxChainSizeBelowMillion = 0;
            long maxChainStartNumberBelowMillion = 0;
            
            for (long i = 999999; i > 1; i--)
            {
                int chainSize = CollatzChainSize(i);
                if (chainSize > maxChainSizeBelowMillion)
                {
                    maxChainSizeBelowMillion = chainSize;
                    maxChainStartNumberBelowMillion = i;
                }
            }
            Console.WriteLine("The first 10 elements from the collection: ");
            for (int i = 1; i < 11; i++) Console.WriteLine("Value: {0}, Distance: {1}", i, paths[i]);
            long maxElement = 0;
            int maxElementDistance = 1;
            long maxDistanceElement = 0;
            int maxDistanceValue = 1;
            foreach(var kv in paths)
            {
                if (kv.Key > maxElement)
                {
                    maxElement = kv.Key;
                    maxElementDistance = kv.Value;
                }
                if (kv.Value > maxDistanceValue)
                {
                    maxDistanceElement = kv.Key;
                    maxDistanceValue = kv.Value;
                }
            }
            Console.WriteLine("Others additional informations:");
            Console.WriteLine("The biggest element in the collection: Value: {0}, Distance: {1}", maxElement, maxElementDistance);
            Console.WriteLine("MaxChain Size bellow 1 million: Value: {0}, Distance: {1}",maxChainStartNumberBelowMillion, paths[maxChainStartNumberBelowMillion]);
            Console.WriteLine("The biggest distance in the collection: Value: {0}, Distance: {1}", maxDistanceElement, maxDistanceValue);
            return maxChainStartNumberBelowMillion.ToString();
        }

        private int CollatzChainSize(long start)
        {
            if (paths.ContainsKey(start)) return paths[start]; 
            List<long> memory = new List<long>();
            memory.Add(start);
            long it = start;
            while (it != 1)
            {
                if (it % 2 == 0) it /= 2;
                else it = 3 * it + 1;
                memory.Add(it);
                if (paths.ContainsKey(it))
                {
                    for (int i = 0; i < memory.Count-1; i++)
                    {
                        paths.Add(memory[i], memory.Count - i + paths[it] - 1);
                    }
                    return memory.Count + paths[it];
                }
            }
            // Code never reached
            return memory.Count;
        }
        public override void Solve()
        {
            // Resets dictionary for sake of testing
            paths = new Dictionary<long, int>();
            paths.Add(1, 1);

            int maxChainSizeBelowMillion = 0;
            long maxChainStartNumberBelowMillion = 0;

            for (long i = 999999; i > 1; i--)
            {
                int chainSize = CollatzChainSize(i);
                if (chainSize > maxChainSizeBelowMillion)
                {
                    maxChainSizeBelowMillion = chainSize;
                    maxChainStartNumberBelowMillion = i;
                }
            }
            return;
        }
    }
}
