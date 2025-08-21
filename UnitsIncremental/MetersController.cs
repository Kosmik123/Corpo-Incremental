using System;
using System.Collections.Generic;

namespace UnitsIncremental
{
    public class MetersController
    {
        private readonly List<double> consecutiveDerivatives = new List<double>();
        
        public double Distance
        {
            get => GetDerivative(0);
            set => SetDerivative(0, value);
        }
        
        public double Speed
        {
            get => GetDerivative(1);
            set => SetDerivative(1, value);
        }
        
        public double Acceleration
        {
            get => GetDerivative(2);
            set => SetDerivative(2, value);
        }

        private double GetDerivative(int order)
        {
            if (consecutiveDerivatives.Count > 0)
            {
                return consecutiveDerivatives[order];
            }
            else
            {
                return 0;
            }
        }

        private void SetDerivative(int order, double value)
        {
            int lastOrder = consecutiveDerivatives.Count - 1;
            if (lastOrder < order)
                for (int i = 0; i < order - lastOrder; i++)
                    consecutiveDerivatives.Add(0);

            consecutiveDerivatives[order] = value;
        }

        public void Tick()
        {
            int lastOrder = consecutiveDerivatives.Count - 1;
            for (int i = lastOrder; i > 0; i--)
                consecutiveDerivatives[i - 1] += 0.5 * consecutiveDerivatives[i];

            for (int i = 1; i < lastOrder - 1; i++)
                consecutiveDerivatives[i - 1] += 0.5 * consecutiveDerivatives[i];
        }
    }
}
