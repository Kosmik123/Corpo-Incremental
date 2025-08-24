namespace UnitsIncremental
{
	public class SecondsController : IUnitController
	{
		public event System.Action OnSecondsChanged;

		public double Seconds
		{
			get => seconds;
			set => seconds = value;
		}

		public void Tick(double deltaTime)
		{
			seconds += deltaTime;

			if (previousSeconds != seconds)
			{
				OnSecondsChanged?.Invoke();
				previousSeconds = seconds;
			}
		}

		private double previousSeconds = -1;
		private double seconds;
	}

	public class KilogramsController : IUnitController
	{
		public double Kilograms
		{
			get => kilograms;
			set => kilograms = value;
		}

		public void Tick(double deltaTime)
		{

		}

		private double kilograms;

	}
}
