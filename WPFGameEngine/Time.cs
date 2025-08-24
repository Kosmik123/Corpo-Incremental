namespace WPFGameEngine
{
    public static class Time
    {
        internal const int DeltaTimeMiliseconds = 20;

		public static double DeltaTimeDouble => deltaTimeDouble;
		public static float DeltaTime => deltaTime;
		public static float TimeScale { get; set; }
		public static double UnscaledDeltaTimeDouble
		{
			get => unscaledDeltaTimeDouble;
			internal set
			{
				unscaledDeltaTimeDouble = value;
				deltaTimeDouble = unscaledDeltaTimeDouble * TimeScale;
				deltaTime = (float)deltaTimeDouble;
			}
		}

		private static double unscaledDeltaTimeDouble;
        private static double deltaTimeDouble;
		
		private static float deltaTime;
    }
}
