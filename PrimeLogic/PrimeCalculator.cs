using System;
using System.Collections.Generic;

namespace PrimeLogic
{
    public class PrimeCalculator
    {
        
        public bool IsPrime(int p)
        {
            for (int d = 2; d < p; d++)
                if (p % d == 0) return false;
            return true;
        }

        public IEnumerable<int> GetAmountNeeded(int amountNeeded)
        {
            int p = 2;
            List<int> result = new List<int>();

            while (result.Count < amountNeeded)
            {
                if (IsPrime(p))
                    result.Add(p);
                p++;
            }

            return result;
        }

    }
}
