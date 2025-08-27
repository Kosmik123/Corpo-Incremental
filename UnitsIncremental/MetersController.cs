using System.Collections.Generic;
using System.Data;

namespace UnitsIncremental
{
    public class MetersController : IUnitController
    {
        public event System.Action OnChanged;
        
        public double Distance
        {
            get => GetDimension(1);
            set => SetDimension(1, value);
        }
        
        public double Area
        {
            get => GetDimension(2);
            set => SetDimension(2, value);
		}

        public double Volume
        {
            get => GetDimension(3);
            set => SetDimension(3, value);
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

        public double Jolt
        {
            get => GetDerivative(3);
            set => SetDerivative(3, value);
        }

		private double GetDerivative(int order) => GetFromList(consecutiveDerivatives, order);
		private double GetDimension(int order) => GetFromList(consecutiveDimensions, order);

		private static double GetFromList(IReadOnlyList<double> list, int order)
		{
			order = ValidateOrder(order);
			if (order < list.Count)
			{
				return list[order];
			}
			else
			{
				return 0;
			}
		}

		private void SetDerivative(int order, double value) => SetInList(consecutiveDerivatives, order, value);
		private void SetDimension(int order, double value) => SetInList(consecutiveDimensions, order, value);

		private void SetInList(IList<double> list, int order, double value)
		{
			order = ValidateOrder(order);

			EnsureIndexExistsInList(list, order);
			list[order] = value;
			changed = true;
		}

		private static int ValidateOrder(int order)
		{
			if (order <= 0)
				throw new System.ArgumentOutOfRangeException(nameof(order), "Order must be greater than 0.");
			return order - 1;
		}

		private static void EnsureIndexExistsInList(IList<double> list, int order)
		{
			int lastOrder = list.Count - 1;
			if (lastOrder < order)
				for (int i = 0; i < order - lastOrder; i++)
					list.Add(0);
		}

		public void Tick(double deltaTime)
        {
            double halfDeltaTime = deltaTime * 0.5f;
            int lastOrder = consecutiveDerivatives.Count - 1;
            for (int i = lastOrder; i > 0; i--)
                consecutiveDerivatives[i - 1] += consecutiveDerivatives[i] * halfDeltaTime;

            Distance += Speed * deltaTime;

            for (int i = 1; i < lastOrder - 1; i++)
                consecutiveDerivatives[i - 1] += consecutiveDerivatives[i] * halfDeltaTime;
            
            if (changed)
            {
                changed = false;
                OnChanged?.Invoke();
            }        
        }

        private readonly List<double> consecutiveDimensions = new List<double>();
		private readonly List<double> consecutiveDerivatives = new List<double>();
        private bool changed = true;
    }
}
