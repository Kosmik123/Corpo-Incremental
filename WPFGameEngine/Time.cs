namespace WPFGameEngine
{
    public static class Time
    {
        public const int DeltaTimeMiliseconds = 20;
        public static double DeltaTimeDouble { get; internal set; }
        public static float DeltaTime => (float)DeltaTimeDouble;
    }
}
